MERGE INTO [KATO].[dbo].取引先経理情報 AS A
USING
    (
        SELECT
            @0 AS 取引先コード
           ,@1 AS 情報区分
           ,@2 AS 年月日
           ,@3 AS 残高
           ,@4 AS 金額１
           ,@5 AS 金額２
           ,@6 AS 金額３
           ,@7 AS 登録日時
           ,@8 AS 登録ユーザー名
           ,@9 AS 更新日時
           ,@10 AS 更新ユーザー名
    ) AS B
ON
    (
        A.取引先コード = B.取引先コード
    AND A.情報区分 = B.情報区分
    AND A.年月日 = B.年月日
    )
WHEN MATCHED THEN
    UPDATE
    SET
        残高 = B.残高
       ,金額１ = B.金額１
       ,金額２ = B.金額２
       ,金額３ = B.金額３
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
       取引先コード
       ,情報区分
       ,年月日
       ,残高
       ,金額１
       ,金額２
       ,金額３
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.取引先コード
       ,B.情報区分
       ,B.年月日
       ,B.残高
       ,B.金額１
       ,B.金額２
       ,B.金額３
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;