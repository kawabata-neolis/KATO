SELECT a.伝票年月日, a.伝票番号, b.行番号, 
       [KATO].[dbo].[f_getメーカー名](b.メーカーコード) AS メーカー,
       RTRIM(ISNULL([KATO].[dbo].[f_get中分類名](b.大分類コード,b.中分類コード),'')) +  ' '  +  Rtrim(ISNULL(b.Ｃ１,'')) AS 品名型式,
		b.数量,b.仕入単価,b.仕入金額,
		b.商品コード,b.備考,
		[KATO2].[dbo].[f_get検収仕入フラグ](a.伝票番号,b.行番号) AS 検収状態

FROM [KATO2].[dbo].[仕入ヘッダ] AS a ,[KATO2].[dbo].[仕入明細] AS b
WHERE a.削除 = 'N' AND b.削除 = 'N'
AND a.仕入先コード = '{0}'
AND a.伝票番号 = b.伝票番号
AND a.伝票年月日 >= '{1}'
AND a.伝票年月日 <= '{2}'
{3}
{4}
