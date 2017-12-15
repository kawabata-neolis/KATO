MERGE INTO 会社処理条件 AS A
USING
    (
        SELECT
		    @p0  AS 会社コード
    ) AS B
ON
    (
        A.会社コード = B.会社コード
    )
WHEN MATCHED THEN
    DELETE
;