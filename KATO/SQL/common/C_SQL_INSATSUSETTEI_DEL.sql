MERGE INTO [KATO].[dbo].印刷設定 AS A
USING
    (
        SELECT
            @0 AS ユーザー名
           ,@1 AS ＰＧ番号
    ) AS B
ON
    (
        A.ユーザー名 = B.ユーザー名
    AND A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    DELETE
;