SELECT 商品.商品コード,
	   大分類.大分類名,
	   中分類.中分類名,
	   メーカー.メーカー名 AS メーカー,
	   ISNULL(商品.Ｃ１, '') AS 品名,
	   本社在庫.在庫数 AS 本社在庫, 
	   本社在庫.フリー在庫数 AS 本社ﾌﾘｰ, 
	   岐阜在庫.在庫数 AS 岐阜在庫, 
	   岐阜在庫.フリー在庫数 AS 岐阜ﾌﾘｰ, 
	   商品.メモ,
	   商品.定価,
	   商品.仕入単価,
	   商品.コメント
FROM 大分類,
     中分類,
	 メーカー,
	 商品 LEFT OUTER JOIN 在庫数 AS 本社在庫 ON 商品.商品コード = 本社在庫.商品コード 
	 AND 本社在庫.営業所コード = '0001' LEFT OUTER JOIN 在庫数 AS 岐阜在庫 ON 商品.商品コード = 岐阜在庫.商品コード 
	 AND 岐阜在庫.営業所コード = '0002' 
WHERE 商品.大分類コード = 大分類.大分類コード 
	  AND 商品.大分類コード = 中分類.大分類コード 
	  AND 商品.中分類コード = 中分類.中分類コード 
	  AND 商品.メーカーコード = メーカー.メーカーコード 
	  AND 商品.メーカーコード = メーカー.メーカーコード 
	  AND 商品.削除 = 'N'