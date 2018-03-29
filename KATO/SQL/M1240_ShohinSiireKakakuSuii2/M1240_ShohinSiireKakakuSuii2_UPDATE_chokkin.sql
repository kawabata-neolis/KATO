UPDATE 商品仕入単価履歴TMP2
SET 仮単価 = 直近仕入単価
FROM 商品
WHERE 在庫年月日 = '{0}'
AND 商品仕入単価履歴TMP2.商品コード = 商品.商品コード
AND 商品.削除 = 'N'
{1}
