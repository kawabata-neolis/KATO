MERGE INTO 業種 AS A
USING
    (
        SELECT
		    @p0  AS 業種コード

    ) AS B
ON
    (
        A.業種コード = B.業種コード
    )
WHEN MATCHED THEN
    DELETE
;