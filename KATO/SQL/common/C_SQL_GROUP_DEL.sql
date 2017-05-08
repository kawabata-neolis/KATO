MERGE INTO [KATO].[dbo].グループ AS A
USING
    (
        SELECT
            @p0  AS グループコード
    ) AS B
ON
    (
        A.グループコード = B.グループコード
    )
WHEN MATCHED THEN
    DELETE
;