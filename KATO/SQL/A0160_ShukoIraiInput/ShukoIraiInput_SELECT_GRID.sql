SELECT 伝票番号,
	   依頼年月日 AS 依頼日,
	   dbo.f_get担当者名(担当者コード) AS 担当者名,
	   dbo.f_get営業所名(出庫倉庫)  AS 出庫営業所,
	   dbo.f_get中分類名(大分類コード,中分類コード) AS 中分類名,
	   RTRIM(ISNULL(Ｃ１,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ２,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ３,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ４,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ５,'')) + ' ' + 
	   RTRIM(ISNULL(Ｃ６,'')) AS 型番,
	   数量
FROM 出庫依頼
WHERE 処理済 = '0'
	  AND 削除 ='N'
	  {0}
