MERGE INTO [KATO].[dbo].商品仕入単価履歴TMP2 AS A
USING
    (
        SELECT
		    @p0 AS 在庫年月日
           ,@p1 AS 商品コード
    ) AS B
ON
    (
        A.在庫年月日 = B.在庫年月日
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;