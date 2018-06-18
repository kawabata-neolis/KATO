SELECT 
 SUM(ROUND(在庫数量*評価単価,0,1)) AS 評価金額,
 SUM(在庫数量*仮単価) AS 仮金額 
FROM 商品仕入単価履歴TMP2
WHERE 在庫年月日='{0}'
AND 在庫数量 >= 0
