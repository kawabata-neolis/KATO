MERGE INTO 運賃 AS A
USING
    (
        SELECT
            @p0 AS 伝票番号
           ,@p1 AS 受注番号
           ,@p2 AS 運賃
           ,@p3 AS 削除
           ,@p4 AS 登録日時
           ,@p5 AS 登録ユーザー名
           ,@p6 AS 更新日時
           ,@p7 AS 更新ユーザー名
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