MERGE INTO [KATO].[dbo].商品売上履歴TMP AS A
USING
    (
        SELECT
		    @0 AS ID
           ,@1 AS 商品コード
           ,@2 AS 売上単価
           ,@3 AS 売上日
    ) AS B
ON
    (
        A.ID = B.ID
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    商品コード = B.商品コード
       ,売上単価 = B.売上単価
       ,売上日 = B.売上日
WHEN NOT MATCHED THEN
    INSERT(
        商品コード
       ,売上単価
       ,仕入日
    )
    VALUES
    (
        B.商品コード
       ,B.売上単価
       ,B.売上日
    )
;