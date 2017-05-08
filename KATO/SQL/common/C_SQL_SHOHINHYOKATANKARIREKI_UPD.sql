MERGE INTO [KATO].[dbo].商品評価単価履歴 AS A
USING
    (
        SELECT
		    @0 AS 商品コード
           ,@1 AS 評価単価
           ,@2 AS 登録日時
    ) AS B
ON
    (
        A.商品コード = B.商品コード
    AND A.登録日時 = B.登録日時
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    評価単価 = B.評価単価
WHEN NOT MATCHED THEN
    INSERT(
        商品コード
       ,評価単価
       ,登録日時
    )
    VALUES
    (
	    B.商品コード
       ,B.評価単価
       ,B.登録日時
    )
;