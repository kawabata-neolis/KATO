SELECT * 
FROM 出庫依頼
WHERE 削除 = 'N'
	AND 承認 = 'Y'
	AND 処理済 = '0'
	AND 出庫倉庫 = '{0}'
