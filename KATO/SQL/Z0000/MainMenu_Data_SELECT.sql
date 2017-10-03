SELECT a.メニューＮＯ,a.ＰＧ番号,a.ＰＧ名,b.ＦＬ１,b.ＦＬ２
FROM マイメニュー a,メニュー b
WHERE ユーザー名 = '{0}'
AND a.ＰＧ番号=b.ＰＧ番号
ORDER BY  メニューＮＯ