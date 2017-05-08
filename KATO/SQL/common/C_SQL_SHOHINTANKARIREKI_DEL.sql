MERGE INTO [KATO].[dbo].商品仕入単価履歴 AS A
USING
    (
        SELECT
		    @0 AS 商品コード
           ,@2 AS 登録日時
    ) AS B
ON
    (
        A.商品コード = B.商品コード
    AND A.登録日時 = B.登録日時
    )
WHEN MATCHED THEN
    DELETE
;