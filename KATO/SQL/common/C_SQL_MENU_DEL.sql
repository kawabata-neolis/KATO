MERGE INTO [KATO].[dbo].マイメニュー AS A
USING
    (
        SELECT
		    @0 AS ＰＧ番号
    ) AS B
ON
    (
        A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    DELETE
;