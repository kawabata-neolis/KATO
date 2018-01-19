SELECT CASE 承認フラグ WHEN '0' THEN 'N' 
								ELSE 'Y' END AS 承認, 
       受注.受注番号, 
       納期, 
	   得意先名称  AS 得意先, 
 	   (
 	   		SELECT メーカー名 
 			FROM メーカー 
 			WHERE メーカー.メーカーコード = 受注.メーカーコード
 	   ) AS ﾒｰｶｰ, 
 	   RTRIM(ISNULL(Ｃ１,''))AS 型番, 
 	   受注数量 AS 数量, 
 	   受注単価, 
 	   仕入単価, 
 	   NULLIF( ROUND(((NULLIF(受注単価,0) - 仕入単価)/ NULLIF(受注単価,0)) * 100,1)
 	   ,0)AS 利益率, 
 	   注番, 
 	   社内メモ, 
 	   dbo.f_get担当者名(受注者コード) AS 担当者 
FROM 受注, 利益率承認
WHERE 削除 ='N'	  
	  AND 受注.受注番号 = 利益率承認.受注番号 
 	  AND ((売上済数量 = 0) OR (売上済数量 < 受注数量)) 
	  AND ABS(売上済数量) < ABS(受注数量) 
	  {0}
ORDER BY 納期 , 得意先, 受注.受注番号
