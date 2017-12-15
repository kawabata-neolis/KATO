MERGE INTO 商品仕入単価履歴 AS A
USING
    (
        SELECT
		    @p0 AS 商品コード
           ,@p1 AS 仕入単価
           ,@p2 AS 登録日時
    ) AS B
ON
    (
        A.商品コード = B.商品コード
    AND A.登録日時 = B.登録日時
    )
WHEN MATCHED THEN
    UPDATE
    SET
	   仕入単価 = B.仕入単価
WHEN NOT MATCHED THEN
    INSERT(
        商品コード
       ,仕入単価
       ,登録日時
    )
    VALUES
    (
	    B.商品コード
       ,B.仕入単価
       ,B.登録日時
    )
;