MERGE INTO [KATO].[dbo].仕入先 AS A
USING
    (
        SELECT
		    @0 AS 仕入先コード
    ) AS B
ON
    (
        A.仕入先コード = B.仕入先コード
    )
WHEN MATCHED THEN
    DELETE
;