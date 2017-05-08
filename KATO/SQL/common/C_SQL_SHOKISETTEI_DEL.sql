MERGE INTO [KATO].[dbo].初期設定 AS A
USING
    (
        SELECT
		    @0 AS 項目名
    ) AS B
ON
    (
        A.項目名 = B.項目名
    )
WHEN MATCHED THEN
    DELETE
;