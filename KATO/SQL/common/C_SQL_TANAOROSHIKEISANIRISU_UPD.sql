MERGE INTO 棚卸計算_移動入数 AS A
USING
    (
        SELECT
            @p0 AS 年月日
           ,@p1 AS 営業所コード
           ,@p2 AS 商品コード
           ,@p3 AS 在庫数
    ) AS B
ON
    (
        A.年月日 = B.年月日
    AND A.営業所コード = B.営業所コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
        在庫数 = B.在庫数
WHEN NOT MATCHED THEN
    INSERT(
        年月日
       ,営業所コード
       ,商品コード
       ,在庫数
    )
    VALUES
    (
	    B.年月日
       ,B.営業所コード
       ,B.商品コード
       ,B.在庫数
    )
;