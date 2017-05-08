MERGE INTO [KATO].[dbo].[大分類] AS A
USING
    (
        SELECT
            @p0  AS 大分類コード
    ) AS B
ON
    (
        A.大分類コード = B.大分類コード
    )
WHEN MATCHED THEN
    DELETE
;