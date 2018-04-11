SELECT CASE 利益率承認.承認フラグ WHEN '0' THEN 'N' 
								ELSE 'Y' END AS 承認, 
       受注.受注番号, 
       受注.納期, 
	   受注.得意先名称  AS 得意先, 
 	   (
 	   		SELECT メーカー名 
 			FROM メーカー 
 			WHERE メーカー.メーカーコード = 受注.メーカーコード
 	   ) AS ﾒｰｶｰ, 
 	   RTRIM(ISNULL(Ｃ１,''))AS 型番, 
 	   受注.受注数量 AS 数量, 
 	   受注.受注単価, 
 	   受注.仕入単価, 
 	   NULLIF( ROUND(((NULLIF(受注.受注単価,0) - 受注.仕入単価)/ NULLIF(受注.受注単価,0)) * 100,1),0)AS 利益率, 
 	   受注.注番, 
 	   受注.社内メモ, 
 	   dbo.f_get担当者名(受注.受注者コード) AS 担当者 ,
	   (
			SELECT 定価
			FROM 商品
			WHERE 商品.商品コード = 受注.商品コード
	   ) AS 定価,
	   '' AS 掛率,
	   (
			SELECT B.仕入単価
			FROM(
						SELECT  ROW_NUMBER() OVER(ORDER BY A.伝票年月日 DESC) AS 行番号, A.仕入単価
						FROM
						(
								SELECT H.伝票年月日,M.仕入単価 
								FROM 仕入ヘッダ H,仕入明細 M 
								WHERE H.削除='N' and M.削除='N' AND H.伝票番号=M.伝票番号 AND  M.商品コード= 受注.商品コード 					
						) A
			) B
			WHERE 行番号 = '1'
	   ) AS 直近仕入単価

FROM 受注, 利益率承認
WHERE 削除 ='N'	  
	  AND 受注.受注番号 = 利益率承認.受注番号 
 	  AND ((売上済数量 = 0) OR (売上済数量 < 受注数量)) 
	  AND ABS(売上済数量) < ABS(受注数量) 
	  {0}
ORDER BY 納期 , 得意先, 受注.受注番号
