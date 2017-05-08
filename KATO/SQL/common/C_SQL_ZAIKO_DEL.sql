MERGE INTO [KATO].[dbo].在庫 AS A
USING
    (
        SELECT
		    @0 AS 在庫年月日
           ,@1 AS 営業所コード
           ,@2 AS 商品コード
    ) AS B
ON
    (
        A.在庫年月日 = B.在庫年月日
    AND A.営業所コード = B.営業所コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;