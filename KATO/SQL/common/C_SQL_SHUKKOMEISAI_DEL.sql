MERGE INTO 出庫明細 AS A
USING
    (
        SELECT
		    @p0 AS 伝票番号
           ,@p1 AS 行番号
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.行番号 = B.行番号
    )
WHEN MATCHED THEN
    DELETE
;