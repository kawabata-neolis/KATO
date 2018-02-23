SELECT RTRIM(dbo.f_getメーカー名(メーカーコード))
		 + ' ' + RTRIM(dbo.f_get中分類名(大分類コード,中分類コード))
		 + ' ' + Rtrim(ISNULL(Ｃ１,'')) 
		 + ' ' + Rtrim(ISNULL(Ｃ２,''))
		 + ' ' + Rtrim(ISNULL(Ｃ３,''))
		 + ' ' + Rtrim(ISNULL(Ｃ４,''))
		 + ' ' + Rtrim(ISNULL(Ｃ５,''))
		 + ' ' + Rtrim(ISNULL(Ｃ６,'')) AS 商品名, 
		 数量 AS 数量, 
		 NULL AS 得意先名, 
		 承認年月日 AS 納期, 
		 dbo.f_get担当者名(担当者コード) AS 受注者 
FROM 出庫依頼 
WHERE 削除 = 'N' 
		AND 承認 = 'Y' 
		AND 処理済 = '0' 
ORDER BY 担当者コード 
