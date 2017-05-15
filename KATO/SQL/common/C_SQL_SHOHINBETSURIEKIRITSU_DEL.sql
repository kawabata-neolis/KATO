MERGE INTO [KATO].[dbo].商品別利益率 AS A
USING
    (
        SELECT
		    @p0 AS 得意先コード
           ,@p1 AS 商品コード
    ) AS B
ON
    (
        A.得意先コード = B.得意先コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;