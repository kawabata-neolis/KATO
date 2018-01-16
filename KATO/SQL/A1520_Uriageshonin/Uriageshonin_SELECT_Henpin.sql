SELECT 受注番号,
       納期,
	   得意先名称  AS 得意先, 
	   (
	   		SELECT メーカー名
			FROM メーカー
			WHERE メーカー.メーカーコード = 受注.メーカーコード
	   ) AS ﾒｰｶｰ, 
	   dbo.f_get中分類名(大分類コード,中分類コード) + ' ' + 
	   RTRIM(ISNULL(Ｃ１,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ２,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ３,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ４,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ５,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ６,'')) AS 型番,  
	   受注数量 AS 数量,
	   受注単価,
	   仕入単価,
	   ROUND(((NULLIF(受注単価,0) - 仕入単価)/ NULLIF(受注単価,0)) * 100,1)
	   AS 利益率,
	   注番,
	   社内メモ,
	   dbo.f_get担当者名(受注者コード) AS 担当者
FROM 受注
WHERE 削除 ='N' AND 
	  ABS(売上済数量) < ABS(受注数量) AND 
	  (受注数量<0 ) 
	  {0}
ORDER BY 納期 