MERGE INTO 売上ヘッダ AS A
USING
    (
        SELECT
		    @p0 AS 伝票番号
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    DELETE
;