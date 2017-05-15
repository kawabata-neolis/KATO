MERGE INTO [KATO].[dbo].マイメニュー AS A
USING
    (
        SELECT
            @p0 AS ユーザー名
           ,@p1 AS メニューＮＯ
           ,@p2 AS ＰＧ番号
           ,@p3 ASＰＧ名
    ) AS B
ON
    (
        A.ユーザー名 = B.ユーザー名
    AND A.メニューＮＯ = B.メニューＮＯ
    )
WHEN MATCHED THEN
    UPDATE
    SET
       ＰＧ番号= B.ＰＧ番号
       ,ＰＧ名= B.ＰＧ名

WHEN NOT MATCHED THEN
    INSERT(
        ユーザー名
       ,メニューＮＯ
       ,ＰＧ番号
       ,ＰＧ名
    )
    VALUES
    (
	    B.ユーザー名
       ,B.メニューＮＯ
       ,B.ＰＧ番号
       ,B.ＰＧ名
    )
;