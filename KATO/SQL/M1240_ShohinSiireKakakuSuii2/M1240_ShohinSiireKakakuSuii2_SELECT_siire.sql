SELECT
 商品コード,
 仕入日,
 仕入単価
FROM 商品仕入履歴ＴＭＰ
WHERE 商品コード='{0}'
ORDER BY 仕入日 DESC
