MERGE INTO 商品仕入履歴TMP AS A
USING
    (
        SELECT
		    @p0 AS ID
           ,@p1 AS 商品コード
           ,@p2 AS 仕入単価
           ,@p3 AS 仕入日
    ) AS B
ON
    (
        A.ID = B.ID
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    商品コード = B.商品コード
       ,仕入単価 = B.仕入単価
       ,仕入日 = B.仕入日
WHEN NOT MATCHED THEN
    INSERT(
        商品コード
       ,仕入単価
       ,仕入日
    )
    VALUES
    (
        B.商品コード
       ,B.仕入単価
       ,B.仕入日
    )
;