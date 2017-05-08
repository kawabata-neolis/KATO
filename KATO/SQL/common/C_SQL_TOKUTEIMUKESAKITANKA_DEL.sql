MERGE INTO [KATO].[dbo].特定向先単価 AS A
USING
    (
        SELECT
		    @0 AS 仕入先コード
           ,@1 AS 得意先コード
           ,@2 AS 商品コード
    ) AS B
ON
    (
        A.仕入先コード = B.仕入先コード
	AND A.得意先コード = B.得意先コード
	AND A.商品コード   = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;