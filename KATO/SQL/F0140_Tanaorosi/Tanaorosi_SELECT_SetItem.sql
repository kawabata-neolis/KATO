SELECT 中分類コード, メーカーコード, 品名型番, 棚卸数量, 棚番, 指定日在庫 ,備考
FROM 棚卸記入表
WHERE 棚卸年月日 = '{0}' AND 商品コード = '{1}'