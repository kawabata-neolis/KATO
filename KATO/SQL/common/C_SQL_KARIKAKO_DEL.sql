MERGE INTO 仮加工 AS A
USING
    (
        SELECT
            @p0 AS 発注番号
    ) AS B
ON
    (
        A.発注番号 = B.発注番号
    )
WHEN MATCHED THEN
    DELETE
;