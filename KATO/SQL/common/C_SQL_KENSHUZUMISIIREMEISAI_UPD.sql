MERGE INTO [KATO].[dbo].検収済仕入明細 AS A
USING
    (
        SELECT
            @0 AS 伝票番号
           ,@1 AS 行番号
           ,@2 AS 検収済
           ,@3 AS 登録日時
           ,@4 AS 登録ユーザー名
           ,@5 AS 更新日時
           ,@6 AS 更新ユーザー名
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.行番号 = B.行番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        検収済 = B.検収済
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        伝票番号
       ,行番号
       ,検収済
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.伝票番号
       ,B.行番号
       ,B.検収済
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;