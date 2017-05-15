MERGE INTO [KATO].[dbo].商品仕入履歴TMP AS A
USING
    (
        SELECT
		    @p0 AS ID
    ) AS B
ON
    (
        A.ID = B.ID
    )
WHEN MATCHED THEN
    DELETE
;