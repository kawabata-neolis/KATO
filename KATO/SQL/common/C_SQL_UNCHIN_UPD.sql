MERGE INTO [KATO].[dbo].運賃 AS A
USING
    (
        SELECT
            @0 AS 伝票番号
           ,@1 AS 受注番号
           ,@2 AS 運賃
           ,@3 AS 削除
           ,@4 AS 登録日時
           ,@5 AS 登録ユーザー名
           ,@6 AS 更新日時
           ,@7 AS 更新ユーザー名
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.受注番号 = B.受注番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        運賃 = B.運賃
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        伝票番号
       ,受注番号
       ,運賃
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.伝票番号
       ,B.受注番号
       ,B.運賃
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;