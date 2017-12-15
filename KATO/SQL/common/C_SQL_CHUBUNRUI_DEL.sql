MERGE INTO [中分類] AS A
USING
    (
        SELECT
		    @p0  AS 大分類コード
           ,@p1  AS 中分類コード

    ) AS B
ON
    (
        A.大分類コード = B.大分類コード
	AND A.中分類コード = B.中分類コード
    )
WHEN MATCHED THEN
    DELETE
;