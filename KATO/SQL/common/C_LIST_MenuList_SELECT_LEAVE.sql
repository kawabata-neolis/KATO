SELECT ＰＧ番号,ＰＧ名,コメント
FROM メニュー 
WHERE 使用中止='N' 
	  AND ＰＧ番号 = '{0}'
ORDER BY ＰＧ番号 ASC