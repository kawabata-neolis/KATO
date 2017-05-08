MERGE INTO [KATO].[dbo].商品分類別利益率 AS A
USING
    (
        SELECT
		    @0 AS ID
    ) AS B
ON
    (
        A.ID = B.ID
    )
WHEN MATCHED THEN
    DELETE
;