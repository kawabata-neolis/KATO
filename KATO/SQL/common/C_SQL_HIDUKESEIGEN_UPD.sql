﻿MERGE INTO 日付制限 AS A
USING
    (
        SELECT
            @p0 AS 画面ＮＯ
           ,@p1 AS 営業所コード
           ,@p2 AS 最小年月日
           ,@p3 AS 最大年月日
           ,@p4 AS 削除
           ,@p5 AS 登録日時
           ,@p6 AS 登録ユーザー名
           ,@p7 AS 更新日時
           ,@p8 AS 更新ユーザー名
    ) AS B
ON
    (
        A.画面ＮＯ = B.画面ＮＯ
    AND A.営業所コード = B.営業所コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
        最小年月日 = B.最小年月日
       ,最大年月日 = B.最大年月日
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        画面ＮＯ
       ,営業所コード
       ,最小年月日
       ,最大年月日
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.画面ＮＯ
       ,B.営業所コード
       ,B.最小年月日
       ,B.最大年月日
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;