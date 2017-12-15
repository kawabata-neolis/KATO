MERGE INTO マイメニュー AS A
USING
    (
        SELECT
		    @p0 AS ＰＧ番号
    ) AS B
ON
    (
        A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    DELETE
;