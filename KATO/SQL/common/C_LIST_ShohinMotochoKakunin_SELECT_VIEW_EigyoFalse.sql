SELECT DISTINCT 
       A.伝票年月日,
	   A.伝票番号,
	   A.行番号,
	   A.取引区分名,
	   A.名前,
	   A.入庫数,
	   A.出庫数,
	   A.在庫数,
	   A.単価,
	   (SELECT 定価
	    FROM 商品
		WHERE 商品.商品コード = A.商品コード
			  AND 商品.削除 = 'N'
	   ) AS 定価,
	   (SELECT 仕入単価
	    FROM 商品
		WHERE 商品.商品コード = A.商品コード
			  AND 商品.削除 = 'N'
		) AS 仕入単価,
	   (SELECT 建値仕入単価
	    FROM 商品
		WHERE 商品.商品コード = A.商品コード
			  AND 商品.削除 = 'N'
		) AS 建値仕入単価,
		

		(CASE A.取引区分   
						   -- 売上
						   WHEN '11' THEN (SELECT 売上明細.受注番号
											FROM 売上明細
											WHERE 売上明細.伝票番号 = A.伝票番号 
											AND 売上明細.行番号 = A.行番号
											)
						   -- 仕入
						   WHEN '21' THEN (SELECT 発注.受注番号
											 FROM (
											 		SELECT 発注番号
													FROM 仕入明細
													WHERE 仕入明細.伝票番号 = A.伝票番号
													AND 仕入明細.行番号 = A.行番号
											 	  ) S,
												  発注
											 WHERE 発注.発注番号 = S.発注番号
											)
						   -- 出庫
 						   WHEN '41' THEN (SELECT 出庫明細.受注番号
											 FROM 出庫明細
											 WHERE 出庫明細.伝票番号 = A.伝票番号
											 AND 出庫明細.行番号 = A.行番号
 						   					)
						   -- 入庫(原価減・在庫増)
						   WHEN '42' THEN (SELECT 出庫明細.受注番号
											 FROM 出庫明細
											 WHERE 出庫明細.伝票番号 = A.伝票番号
											 AND 出庫明細.行番号 = A.行番号
 						   					)					   
						   -- 入庫(原価減のみ)  
						   WHEN '44' THEN (SELECT 出庫明細.受注番号
											 FROM 出庫明細
											 WHERE 出庫明細.伝票番号 = A.伝票番号
											 AND 出庫明細.行番号 = A.行番号
 						   					)
						   -- 加工品出庫
						   WHEN '43' THEN (SELECT 出庫明細.受注番号
											 FROM 出庫明細
											 WHERE 出庫明細.伝票番号 = A.伝票番号
											 AND 出庫明細.行番号 = A.行番号
 						   					)
						   -- 移動出
						   WHEN '51' THEN A.伝票番号
						   -- 移動入
						   WHEN '52' THEN A.伝票番号
						   -- 棚卸
						   WHEN '55' THEN A.伝票番号
							ELSE '' END
		) AS 受注番号,
	   A.表示順

FROM (
	SELECT 伝票年月日,伝票番号,行番号,取引区分名,名前,入庫数,出庫数,0 as 在庫数,単価, 商品コード, 表示順, 取引区分
	FROM 商品在庫元帳_VIEW
	WHERE 商品コード = '{0}'
		AND 伝票年月日 >= '{2}'
		AND 伝票年月日 <= '{3}'
	)A

ORDER BY 伝票年月日,表示順,伝票番号,行番号
