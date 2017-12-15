MERGE INTO 商品分類別利益率 AS A
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