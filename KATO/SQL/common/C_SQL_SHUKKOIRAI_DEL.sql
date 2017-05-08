MERGE INTO [KATO].[dbo].出庫依頼 AS A
USING
    (
        SELECT
		    @0 AS 伝票番号
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    DELETE
;