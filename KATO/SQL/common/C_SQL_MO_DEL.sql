MERGE INTO [KATO].[dbo].MO AS A
USING
    (
        SELECT
		    @0 AS 年月度
           ,@1 AS 商品コード
           ,@2 AS 取引先コード

    ) AS B
ON
    (
        A.年月度 = B.年月度
    AND A.商品コード = B.商品コード
    AND A.取引先コード = B.取引先コード
    )
WHEN MATCHED THEN
    DELETE
;