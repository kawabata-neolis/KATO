SELECT ＰＧ番号,ＰＧ名,コメント
FROM メニュー 
WHERE ＰＧ番号 < 147 OR ＰＧ番号 > 150 AND ＰＧ番号 < 600 AND 使用中止='N'
ORDER BY ＰＧ番号 ASC