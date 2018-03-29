SELECT
 SUM(在庫数量*仮単価) AS 仮金額
FROM 商品仕入単価履歴TMP2
WHERE 在庫年月日='{0}'
AND 商品コード NOT IN(
                       SELECT a.商品コード
                       FROM 商品仕入単価履歴TMP2 AS a,
                            商品 AS b
                       WHERE 在庫年月日='{0}'
                       AND a.商品コード = b.商品コード
                       AND b.削除 = 'N'
                       {1}
                     )
