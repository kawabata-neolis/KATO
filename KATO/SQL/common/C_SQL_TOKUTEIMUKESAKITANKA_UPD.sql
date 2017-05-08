MERGE INTO [KATO].[dbo].特定向先単価 AS A
USING
    (
        SELECT
		    @0 AS 仕入先コード
           ,@1 AS 得意先コード
           ,@2 AS 商品コード
           ,@3 AS 型番
           ,@4 AS 単価
           ,@5 AS 削除
           ,@6 AS 登録日時
           ,@7 AS 登録ユーザー名
           ,@8 AS 更新日時
           ,@9 AS 更新ユーザー名

    ) AS B
ON
    (
        A.仕入先コード = B.仕入先コード
	AND A.得意先コード = B.得意先コード
	AND A.商品コード   = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    型番           = B.型番
	   ,単価           = B.単価
	   ,削除           = B.削除
	   ,更新日時       = B.更新日時
	   ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        仕入先コード
       ,得意先コード
       ,商品コード
       ,型番
       ,単価
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.仕入先コード
       ,B.得意先コード
       ,B.商品コード
       ,B.型番
       ,B.単価
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;