SELECT DISTINCT dbo.f_get売上削除承認(a.伝票番号) AS 承認, 
a.伝票番号 AS 受注番号,
a.伝票年月日,
a.伝票年月日 AS 納期, 
a.得意先名  AS 得意先, 
c.メーカー名 AS ﾒｰｶｰ, 
RTRIM(ISNULL(b.Ｃ１,''))AS 型番,  
b.数量, 
b.売上単価 AS 受注単価, 
b.仕入単価, 
ROUND(((NULLIF(b.売上単価,0) - 仕入単価)/ NULLIF(b.売上単価,0)) * 100,1)
AS 利益率, 
b.備考 AS 注番,
dbo.f_get担当者名(担当者コード) AS 担当者
FROM 売上ヘッダ a ,売上明細 b, メーカー c, 中分類 d, 売上削除承認 e
WHERE a.削除 = 'N' AND b.削除 = 'N' AND
      a.伝票番号 = b.伝票番号 AND
b.メーカーコード = c.メーカーコード AND 
b.大分類コード = d.大分類コード AND 
b.中分類コード = d.中分類コード AND
a.伝票番号 = e.伝票番号 AND 
--a.伝票年月日 <='{0}' AND 
a.伝票年月日 >='{0}'
{1}
ORDER BY 伝票年月日 DESC, 得意先, 受注番号
