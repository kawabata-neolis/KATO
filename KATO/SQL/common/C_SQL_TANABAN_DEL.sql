MERGE INTO [KATO].[dbo].棚番 AS A
USING
    (
        SELECT
		    @p0  AS 棚番

    ) AS B
ON
    (
        A.棚番 = B.棚番
    )
WHEN MATCHED THEN
    DELETE
;