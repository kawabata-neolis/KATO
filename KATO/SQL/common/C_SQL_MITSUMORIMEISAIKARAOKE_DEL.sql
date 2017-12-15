MERGE INTO 見積明細カラオケ AS A
USING
    (
        SELECT
            @p0 AS 行番号
    ) AS B
ON
    (
        A.行番号 = B.行番号
    )
WHEN MATCHED THEN
    DELETE
;