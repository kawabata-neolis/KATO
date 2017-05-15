MERGE INTO [KATO].[dbo].運賃 AS A
USING
    (
        SELECT
		    @p0 AS 伝票番号
           ,@p1 AS 受注番号
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.受注番号 = B.受注番号
    )
WHEN MATCHED THEN
    DELETE
;