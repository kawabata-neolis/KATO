﻿MERGE INTO [中分類] AS A
USING
    (
        SELECT
		    @p0  AS 大分類コード
           ,@p1  AS 中分類コード
           ,@p2  AS 中分類名
           ,@p3  AS 補助名称
           ,@p4  AS 削除
           ,@p5  AS 登録日時
           ,@p6  AS 登録ユーザー名
           ,@p7  AS 更新日時
           ,@p8  AS 更新ユーザー名

    ) AS B
ON
    (
        A.大分類コード = B.大分類コード
	AND A.中分類コード = B.中分類コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    中分類名       = B.中分類名
	   ,補助名称       = B.補助名称
	   ,削除           = B.削除
	   ,更新日時       = B.更新日時
	   ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        大分類コード
       ,中分類コード
       ,中分類名
       ,補助名称
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.大分類コード
       ,B.中分類コード
       ,B.中分類名
       ,B.補助名称
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;