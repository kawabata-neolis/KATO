SELECT 仮商品.商品コード,
       大分類.大分類名,
	   中分類.中分類名,
	   メーカー.メーカー名 AS メーカー,
	   ISNULL(仮商品.Ｃ１, '') AS 品名,
	   本社在庫.在庫数 AS 本社在庫,
	   本社在庫.フリー在庫数未来 AS 本社ﾌﾘｰ,
	   岐阜在庫.在庫数 AS 岐阜在庫,
	   岐阜在庫.フリー在庫数未来 AS 岐阜ﾌﾘｰ,
	   仮商品.更新ユーザー名 AS メモ,
	   仮商品.定価,
	   仮商品.仕入単価,
	   仮商品.コメント,
	   仮商品.標準売価,
	   仮商品.評価単価,
	   仮商品.建値仕入単価,
	   仮商品.棚番本社,
	   仮商品.棚番岐阜
FROM 大分類,
	 中分類,
	 メーカー,
	 仮商品 LEFT OUTER JOIN 在庫数 AS 本社在庫 ON 仮商品.商品コード = 本社在庫.商品コード
	 AND 本社在庫.営業所コード = '0001' LEFT OUTER JOIN 在庫数 AS 岐阜在庫 ON 仮商品.商品コード = 岐阜在庫.商品コード
	 AND 岐阜在庫.営業所コード = '0002'
WHERE 仮商品.大分類コード = 大分類.大分類コード 
	  AND 仮商品.大分類コード = 中分類.大分類コード
	  AND 仮商品.中分類コード = 中分類.中分類コード
	  AND 仮商品.メーカーコード = メーカー.メーカーコード
	  AND 仮商品.削除 = 'N'
	  {0}