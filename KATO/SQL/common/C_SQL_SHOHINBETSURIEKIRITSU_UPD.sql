MERGE INTO [KATO].[dbo].商品別利益率 AS A
USING
    (
        SELECT
		    @0 AS 得意先コード
           ,@1 AS 商品コード
           ,@2 AS 利益率
           ,@3 AS 単価
           ,@4 AS 設定
           ,@5 AS 削除
           ,@6 AS 登録日時
           ,@7 AS 登録ユーザー名
           ,@8 AS 更新日時
           ,@9 AS 更新ユーザー名
    ) AS B
ON
    (
        A.得意先コード = B.得意先コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    利益率 = B.利益率
       ,単価 = B.単価
       ,設定 = B.設定
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        得意先コード
       ,商品コード
       ,利益率
       ,単価
       ,設定
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.得意先コード
       ,B.商品コード
       ,B.利益率
       ,B.単価
       ,B.設定
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;