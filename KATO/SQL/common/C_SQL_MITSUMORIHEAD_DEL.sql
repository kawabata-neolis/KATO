MERGE INTO 見積ヘッド AS A
USING
    (
        SELECT
            @p0 AS 見積書番号
    ) AS B
ON
    (
        A.見積書番号 = B.見積書番号
    )
WHEN MATCHED THEN
    DELETE
;