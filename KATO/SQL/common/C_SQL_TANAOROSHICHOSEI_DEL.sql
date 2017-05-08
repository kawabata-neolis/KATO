MERGE INTO [KATO].[dbo].棚卸調整 AS A
USING
    (
        SELECT
		    @0 AS ＩＤ
    ) AS B
ON
    (
        A.ＩＤ = B.ＩＤ
    )
WHEN MATCHED THEN
    DELETE
;