MERGE INTO 商品売上履歴TMP AS A
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