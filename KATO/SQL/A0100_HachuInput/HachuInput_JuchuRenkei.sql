SELECT 受注数量,本社出庫数,岐阜出庫数
FROM 受注
WHERE 削除='N'
	  AND 受注番号= '{0}'