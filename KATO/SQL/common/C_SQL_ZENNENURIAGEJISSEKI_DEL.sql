MERGE INTO [KATO].[dbo].前年売上実績 AS A
USING
    (
        SELECT
		    @0 AS 取引先コード
    ) AS B
ON
    (
        A.取引先コード = B.取引先コード
    )
WHEN MATCHED THEN
    DELETE
;