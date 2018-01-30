SELECT
 商品コード,
 仮単価
FROM [KATO].[dbo].[商品仕入単価履歴TMP2]
WHERE 在庫年月日='{0}'
ORDER BY 商品コード
