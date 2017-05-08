MERGE INTO [KATO].[dbo].マイメニュー AS A
USING
    (
        SELECT
            @0 AS ユーザー名
           ,@1 AS メニューＮＯ
           ,@2 AS ＰＧ番号
           ,@3 ASＰＧ名
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