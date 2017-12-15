MERGE INTO 商品 AS A
USING
    (
        SELECT
		    @p0  AS 商品コード
    ) AS B
ON
    (
        A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;