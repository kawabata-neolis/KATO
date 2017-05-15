MERGE INTO [KATO].[dbo].商品別利益率 AS A
USING
    (
        SELECT
		    @p0 AS 得意先コード
           ,@p1 AS 商品コード
           ,@p2 AS 利益率
           ,@p3 AS 単価
           ,@p4 AS 設定
           ,@p5 AS 削除
           ,@p6 AS 登録日時
           ,@p7 AS 登録ユーザー名
           ,@p8 AS 更新日時
           ,@p9 AS 更新ユーザー名
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