MERGE INTO [直送先] AS A
USING
    (
        SELECT
		    @p0  AS 得意先コード
           ,@p1  AS 直送先コード

    ) AS B
ON
    (
        A.得意先コード = B.得意先コード
	AND A.直送先コード = B.直送先コード
    )
WHEN MATCHED THEN
    DELETE
;