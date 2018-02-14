SELECT 
  menu.ＰＧ名 AS ＰＧ名,
  tanto.担当者コード AS 担当者コード,
  tanto.担当者名 AS 担当者名,
  kengen.権限 AS 権限
FROM 
  メニュー権限 AS kengen,
  担当者 AS tanto,
  (SELECT ＰＧ番号, ＰＧ名
   FROM メニュー
   WHERE ＰＧ番号 = {0}) AS menu
WHERE
  kengen.ＰＧ番号 = menu.ＰＧ番号
AND 
  kengen.担当者コード = tanto.担当者コード
AND
  tanto.表示 = 1
AND
  tanto.削除 = 'N'

