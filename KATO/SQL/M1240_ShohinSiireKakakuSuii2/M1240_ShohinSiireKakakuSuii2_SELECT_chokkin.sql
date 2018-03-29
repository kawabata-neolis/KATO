SELECT
 SUM(在庫数量*直近仕入単価) AS 直近仕入金額
FROM 商品仕入単価履歴TMP2 AS a, 
     商品 AS b
WHERE 在庫年月日='{0}'
AND a.商品コード = b.商品コード
AND b.削除 = 'N'
{1}
