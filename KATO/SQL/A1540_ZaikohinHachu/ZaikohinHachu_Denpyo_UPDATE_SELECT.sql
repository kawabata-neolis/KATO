UPDATE 伝票番号
SET 最終番号 = 最終番号 + 1, 更新日時 = GETDATE()
WHERE テーブル名 = '{0}'

SELECT 最終番号
FROM 伝票番号
WHERE テーブル名 = '{0}'
