SELECT マスタ権限,閲覧権限,利益率権限 
FROM 担当者 
WHERE ログインＩＤ='{0}'  
	  AND 削除='N'
