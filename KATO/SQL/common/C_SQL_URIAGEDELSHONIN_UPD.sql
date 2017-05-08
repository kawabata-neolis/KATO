MERGE INTO [KATO].[dbo].売上削除承認 AS A
USING
    (
        SELECT
            @0 AS 伝票番号
           ,@1 AS 承認
           ,@2 AS 登録日時
           ,@3 AS 登録ユーザー名
           ,@4 AS 更新日時
           ,@5 AS 更新ユーザー名
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        承認 = B.承認
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        伝票番号
       ,承認
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.伝票番号
       ,B.承認
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;