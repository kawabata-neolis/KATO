MERGE INTO 営業所 AS A
USING
    (
        SELECT
		    @p0  AS 営業所コード

    ) AS B
ON
    (
        A.営業所コード = B.営業所コード
    )
WHEN MATCHED THEN
    DELETE
;