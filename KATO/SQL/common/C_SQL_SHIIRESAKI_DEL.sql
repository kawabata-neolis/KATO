MERGE INTO 仕入先 AS A
USING
    (
        SELECT
		    @p0 AS 仕入先コード
    ) AS B
ON
    (
        A.仕入先コード = B.仕入先コード
    )
WHEN MATCHED THEN
    DELETE
;