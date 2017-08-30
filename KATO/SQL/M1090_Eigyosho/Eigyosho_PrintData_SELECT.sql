SELECT 営業所コード,営業所名,更新日時
FROM 営業所
WHERE 削除 = 'N'
ORDER BY 営業所コード
