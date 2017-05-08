MERGE INTO [KATO].[dbo].担当者 AS A
USING
    (
        SELECT
		    @p0  AS 担当者コード
    ) AS B
ON
    (
        A.担当者コード = B.担当者コード
    )
WHEN MATCHED THEN
    DELETE
;