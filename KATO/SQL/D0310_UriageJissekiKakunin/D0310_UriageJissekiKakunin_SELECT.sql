/*
{0}:年月日Start
{1}:年月日End
{2}:プログラム内で追加したAND条件
{3}:ORDER BY
*/

SELECT *
FROM (
      SELECT
       (CASE WHEN uh.伝票発行フラグ = '1' THEN '済' ELSE '' END) AS 印,
       uh.伝票年月日,
       uh.伝票番号,
       um.行番号,
       um.メーカーコード,
       m.メーカー名 AS メーカー,
       RTRIM(ISNULL(cb.中分類名, '')) + ' ' + Rtrim(ISNULL(um.Ｃ１, '')) AS 品名型式,
       um.数量,
       um.売上単価 AS 単価,
       um.売上金額,
       dbo.f_get受注番号_仕入単価FROM受注(um.受注番号) AS 原価,
       um.数量 * dbo.f_get受注番号_仕入単価FROM受注(um.受注番号) AS 原価金額,
       um.売上金額 - (um.数量 * dbo.f_get受注番号_仕入単価FROM受注(um.受注番号) + dbo.f_get受注番号_運賃FROM運賃(um.受注番号)) AS 粗利額,
       dbo.f_get受注番号_運賃FROM運賃(um.受注番号) AS 運賃,
       um.商品コード,
       um.備考,
       dbo.f_get受注番号_発注先名FROM発注(um.受注番号) AS 仕入先名,
       uh.得意先名,
       um.受注番号,
       dbo.f_get担当者名(dbo.f_get受注番号_受注者コードFROM受注(um.受注番号)) AS 受注担当,
       dbo.f_get受注番号から最終仕入先日(um.受注番号) AS 仕入日,
       dbo.f_get受注番号から発注番号FROM発注(um.受注番号) AS 発注番号,
       dbo.f_get担当者名(t.担当者コード) AS 営業担当,
       dbo.f_get担当者名(uh.担当者コード) AS 入力者名,
       dbo.f_get商品別利益率_単価(uh.得意先コード, um.商品コード) AS 設定単価
     FROM dbo.売上ヘッダ AS uh, dbo.売上明細 AS um, dbo.メーカー AS m , dbo.中分類 AS cb, dbo.取引先 AS t
     WHERE uh.削除 = 'N'
       AND um.削除 = 'N'
       AND m.削除 = 'N'
       AND cb.削除 = 'N'
       AND t.削除 = 'N'
       AND uh.伝票番号 = um.伝票番号
       AND um.メーカーコード = m.メーカーコード
       AND um.大分類コード = cb.大分類コード
       AND um.中分類コード = cb.中分類コード
       AND uh.得意先コード = t.取引先コード
       AND uh.伝票年月日 >= '{0}'
       AND uh.伝票年月日 <= '{1}'
       {2}
     ) AS TBL
{3}
