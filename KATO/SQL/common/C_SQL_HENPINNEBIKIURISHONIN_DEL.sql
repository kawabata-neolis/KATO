MERGE INTO [KATO].[dbo].返品値引売上承認 AS A
USING
    (
        SELECT
            @0 AS 受注番号
    ) AS B
ON
    (
        A.受注番号 = B.受注番号
    )
WHEN MATCHED THEN
    DELETE
;