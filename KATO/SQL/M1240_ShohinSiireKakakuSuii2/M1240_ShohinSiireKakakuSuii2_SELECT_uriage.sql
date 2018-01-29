SELECT
 商品コード,
 売上日,
 売上単価
FROM [KATO].[dbo].[商品売上履歴ＴＭＰ]
WHERE 商品コード='{0}'
ORDER BY 売上日 DESC
