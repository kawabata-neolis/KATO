MERGE INTO [KATO].[dbo].特定向先単価 AS A
USING
    (
        SELECT
		    @p0 AS 仕入先コード
           ,@p1 AS 得意先コード
           ,@p2 AS 商品コード
           ,@p3 AS 型番
           ,@p4 AS 単価
           ,@p5 AS 削除
           ,@p6 AS 登録日時
           ,@p7 AS 登録ユーザー名
           ,@p8 AS 更新日時
           ,@p9 AS 更新ユーザー名

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