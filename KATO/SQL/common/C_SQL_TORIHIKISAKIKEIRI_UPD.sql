MERGE INTO 取引先経理情報 AS A
USING
    (
        SELECT
            @p0 AS 取引先コード
           ,@p1 AS 情報区分
           ,@p2 AS 年月日
           ,@p3 AS 残高
           ,@p4 AS 金額１
           ,@p5 AS 金額２
           ,@p6 AS 金額３
           ,@p7 AS 登録日時
           ,@p8 AS 登録ユーザー名
           ,@p9 AS 更新日時
           ,@p10 AS 更新ユーザー名
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