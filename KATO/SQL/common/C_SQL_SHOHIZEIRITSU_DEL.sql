MERGE INTO [KATO].[dbo].消費税率 AS A
USING
    (
        SELECT
		    @p0  AS 適用開始年月日

    ) AS B
ON
    (
        A.適用開始年月日 = B.適用開始年月日
    )
WHEN MATCHED THEN
    DELETE
;