SELECT 取引先コード ,取引先名称, カナ,郵便番号,住所１,住所２,電話番号,ＦＡＸ番号
FROM 取引先
WHERE 削除 = 'N'
ORDER BY 取引先コード
