﻿MERGE INTO 棚番 AS A
USING
    (
        SELECT
		    @p0  AS 棚番
           ,@p1  AS 棚番名
           ,@p2  AS 削除
           ,@p3  AS 登録日時
           ,@p4  AS 登録ユーザー名
           ,@p5  AS 更新日時
           ,@p6  AS 更新ユーザー名

    ) AS B
ON
    (
        A.棚番 = B.棚番
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    棚番名         = B.棚番名
	   ,削除           = B.削除
	   ,更新日時       = B.更新日時
	   ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        棚番
       ,棚番名
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.棚番
       ,B.棚番名
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;