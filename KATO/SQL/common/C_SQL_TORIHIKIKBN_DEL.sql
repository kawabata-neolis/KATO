MERGE INTO 取引区分 AS A
USING
    (
        SELECT
		    @p0  AS 取引区分コード

    ) AS B
ON
    (
        A.取引区分コード = B.取引区分コード
    )
WHEN MATCHED THEN
    DELETE
;