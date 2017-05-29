MERGE INTO [KATO].[dbo].消費税率 AS A
USING
    (
        SELECT
		    @p0  AS 適用開始年月日
           ,@p1  AS 消費税率
           ,@p2  AS 削除
           ,@p3  AS 登録日時
           ,@p4  AS 登録ユーザー名
           ,@p5  AS 更新日時
           ,@p6  AS 更新ユーザー名

    ) AS B
ON
    (
        A.適用開始年月日 = B.適用開始年月日
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    適用開始年月日 = B.適用開始年月日
	   ,消費税率       = B.消費税率
	   ,削除       　　= B.削除
	   ,更新日時       = B.更新日時
	   ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        適用開始年月日
       ,消費税率
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.適用開始年月日
       ,B.消費税率
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;