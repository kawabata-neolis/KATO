/*
{0}:年月日Start
{1}:年月日End
{2}:プログラム内で追加したAND条件
{3}:ORDER BY
*/

SELECT *
FROM (
      SELECT 
       sh.伝票年月日,
       sh.伝票番号,
       sm.行番号,
       sm.メーカーコード,
       m.メーカー名 AS メーカー,
       RTRIM(ISNULL(cb.中分類名,'')) +  ' '  +  Rtrim(ISNULL(sm.Ｃ１,'')) AS 品名型式 ,
       sm.数量,
       sm.仕入単価,
       sm.仕入金額,
       sm.備考,
       dbo.f_get受注番号_得意先名FROM受注 (dbo.f_get発注番号_受注番号FROM発注(sm.発注番号)) AS 出荷先名,
       sh.仕入先コード,
       sh.仕入先名,
       sm.発注番号,
       dbo.f_get発注番号から発注担当者(sm.発注番号) AS 発注担当,
       dbo.f_get担当者名(sh.担当者コード) AS 仕入担当,
       dbo.f_get発注番号_受注番号FROM発注(sm.発注番号) AS 受注番号,
       dbo.f_get受注番号から受注単価(dbo.f_get発注番号_受注番号FROM発注(sm.発注番号)) AS 受注単価,
       dbo.f_get受注番号から受注金額(dbo.f_get発注番号_受注番号FROM発注(sm.発注番号)) AS 受注金額,
       dbo.f_get受注番号_受注年月日FROM受注(dbo.f_get発注番号_受注番号FROM発注(sm.発注番号)) AS 受注日,
       dbo.f_get担当者名(dbo.f_get受注番号_受注者コードFROM受注(dbo.f_get発注番号_受注番号FROM発注(sm.発注番号))) AS 受注担当,
       dbo.f_get担当者名(t.担当者コード) AS 営業担当
      FROM dbo.仕入ヘッダ AS sh ,dbo.仕入明細 AS sm, dbo.メーカー AS m, dbo.中分類 AS cb, dbo.取引先 AS t
      WHERE sh.削除 = 'N' 
        AND sm.削除 = 'N'
        AND m.削除 = 'N'
        AND cb.削除 = 'N'
        AND t.削除 = 'N'
        AND sh.伝票番号 = sm.伝票番号
        AND sm.メーカーコード = m.メーカーコード
        AND sm.大分類コード = cb.大分類コード
        AND sm.中分類コード = cb.中分類コード
        AND sh.仕入先コード = t.取引先コード
        AND sh.伝票年月日 >= '{0}'
        AND sh.伝票年月日 <= '{1}'
       {2}
     ) AS TBL
{3}
