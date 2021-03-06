﻿MERGE INTO 返品値引売上承認 AS A
USING
    (
        SELECT
            @p0 AS 受注番号
           ,@p1 AS 承認フラグ
           ,@p2 AS 登録日時
           ,@p3 AS 登録ユーザー名
           ,@p4 AS 更新日時
           ,@p5 AS 更新ユーザー名

    ) AS B
ON
    (
        A.受注番号 = B.受注番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        承認フラグ = B.承認フラグ
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        受注番号
       ,承認フラグ
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.受注番号
       ,B.承認フラグ
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;