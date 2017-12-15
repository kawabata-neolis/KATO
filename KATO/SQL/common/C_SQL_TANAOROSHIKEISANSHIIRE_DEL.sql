MERGE INTO 棚卸計算_仕入 AS A
USING
    (
        SELECT
		    @p0 AS 年月日
           ,@p1 AS 営業所コード
           ,@p2 AS 商品コード
    ) AS B
ON
    (
        A.年月日 = B.年月日
    AND A.営業所コード = B.営業所コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;