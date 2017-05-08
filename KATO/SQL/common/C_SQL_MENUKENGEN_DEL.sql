MERGE INTO [KATO].[dbo].メニュー権限 AS A
USING
    (
        SELECT
		    @0 AS 担当者コード
           ,@1 AS ＰＧ番号
    ) AS B
ON
    (
        A.担当者コード = B.担当者コード
    AND A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    DELETE
;