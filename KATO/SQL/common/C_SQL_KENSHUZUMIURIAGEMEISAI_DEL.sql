MERGE INTO [KATO].[dbo].検収済売上明細 AS A
USING
    (
        SELECT
            @0 AS 伝票番号
           ,@1 AS 行番号
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.行番号 = B.行番号
    )
WHEN MATCHED THEN
    DELETE
;