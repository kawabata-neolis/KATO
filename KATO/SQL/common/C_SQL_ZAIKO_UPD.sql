MERGE INTO [KATO].[dbo].在庫 AS A
USING
    (
        SELECT
            @0 AS 在庫年月日
           ,@1 AS 営業所コード
           ,@2 AS 商品コード
           ,@3 AS 在庫数
           ,@4 AS 棚番
           ,@5 AS 削除
           ,@6 AS 登録日時
           ,@7 AS 登録ユーザー名
           ,@8 AS 更新日時
           ,@9 AS 更新ユーザー名
    ) AS B
ON
    (
        A.在庫年月日 = B.在庫年月日
    AND A.営業所コード = B.営業所コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
        在庫数 = B.在庫数
       ,棚番 = B.棚番
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        在庫年月日
       ,営業所コード
       ,商品コード
       ,在庫数
       ,棚番
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.在庫年月日
       ,B.営業所コード
       ,B.商品コード
       ,B.在庫数
       ,B.棚番
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;