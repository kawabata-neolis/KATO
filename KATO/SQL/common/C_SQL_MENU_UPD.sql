MERGE INTO [KATO].[dbo].マイメニュー AS A
USING
    (
        SELECT
            @0 AS ＰＧ番号
           ,@1 AS ＰＧ名
           ,@2 AS 権限
           ,@3 AS 使用中止
           ,@4 AS ＦＬ１
           ,@5 AS ＦＬ２
           ,@6 AS ＦＬ３
           ,@7 AS コメント
    ) AS B
ON
    (
        A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
       ＰＧ名 = B.ＰＧ名
       ,権限 = B.権限
       ,使用中止 = B.使用中止
       ,ＦＬ１ = B.ＦＬ１
       ,ＦＬ２ = B.ＦＬ２
       ,ＦＬ３ = B.ＦＬ３
       ,コメント = B.コメント


WHEN NOT MATCHED THEN
    INSERT(
        ＰＧ番号
       ,ＰＧ名
       ,権限
       ,使用中止
       ,ＦＬ１
       ,ＦＬ２
       ,ＦＬ３
       ,コメント
    )
    VALUES
    (
	    B.ＰＧ番号
       ,B.ＰＧ名
       ,B.権限
       ,B.使用中止
       ,B.ＦＬ１
       ,B.ＦＬ２
       ,B.ＦＬ３
       ,B.コメント
    )
;