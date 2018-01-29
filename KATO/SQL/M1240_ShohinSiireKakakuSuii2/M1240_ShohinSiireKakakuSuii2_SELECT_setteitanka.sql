SELECT
 SUM(在庫数量*仮単価) AS 仮金額
FROM [KATO].[dbo].商品仕入単価履歴TMP2
WHERE 在庫年月日='{0}'
