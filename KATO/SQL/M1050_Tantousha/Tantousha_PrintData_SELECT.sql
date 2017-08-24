SELECT a.担当者コード ,a.担当者名, b.営業所名,a.更新日時,a.注番文字, c.グループ名, a.年間売上目標
FROM 担当者 a, 営業所 b , グループ c
WHERE a.削除 = 'N'
AND b.営業所コード = a.営業所コード
AND b.削除 = 'N'
AND c.グループコード = a.グループコード
AND c.削除 = 'N'
ORDER BY 担当者コード
