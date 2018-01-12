SELECT DISTINCT 得意先コード 
FROM 入金 
WHERE 伝票番号= '{0}' AND 
	  削除='N'
