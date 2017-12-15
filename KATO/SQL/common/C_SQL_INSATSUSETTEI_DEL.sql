MERGE INTO 印刷設定 AS A
USING
    (
        SELECT
            @p0 AS ユーザー名
           ,@p1 AS ＰＧ番号
    ) AS B
ON
    (
        A.ユーザー名 = B.ユーザー名
    AND A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    DELETE
;