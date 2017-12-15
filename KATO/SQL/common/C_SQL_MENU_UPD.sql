MERGE INTO マイメニュー AS A
USING
    (
        SELECT
            @p0 AS ＰＧ番号
           ,@p1 AS ＰＧ名
           ,@p2 AS 権限
           ,@p3 AS 使用中止
           ,@p4 AS ＦＬ１
           ,@p5 AS ＦＬ２
           ,@p6 AS ＦＬ３
           ,@p7 AS コメント
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