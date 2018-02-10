SELECT a.グループコード , a.グループ名
FROM グループ a
WHERE a.削除 = 'N'
ORDER BY a.グループコード