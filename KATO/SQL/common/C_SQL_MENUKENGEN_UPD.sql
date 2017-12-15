MERGE INTO メニュー権限 AS A
USING
    (
        SELECT
            @p0 AS 担当者コード
           ,@p1 AS ＰＧ番号
           ,@p2 AS ＰＧ名
           ,@p3 AS 権限

    ) AS B
ON
    (
        A.担当者コード = B.担当者コード
    AND A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
       ＰＧ名 = B.ＰＧ名
       ,権限 = B.権限
WHEN NOT MATCHED THEN
    INSERT(
        担当者コード
       ,ＰＧ番号
       ,ＰＧ名
       ,権限
    )
    VALUES
    (
	    B.担当者コード
       ,B.ＰＧ番号
       ,B.ＰＧ名
       ,B.権限
    )
;