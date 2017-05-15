﻿MERGE INTO [KATO].[dbo].出庫ヘッダ AS A
USING
    (
        SELECT
            @p0 AS 伝票番号
           ,@p1 AS 伝票年月日
           ,@p2 AS 仕入先コード
           ,@p3 AS 取引区分
           ,@p4 AS 担当者コード
           ,@p5 AS 営業所コード
           ,@p6 AS 削除
           ,@p7 AS 登録日時
           ,@p8 AS 登録ユーザー名
           ,@p9 AS 更新日時
           ,@p10 AS 更新ユーザー名
           ,@p11 AS 仕入先名称
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        伝票年月日 = B.伝票年月日
       ,仕入先コード = B.仕入先コード
       ,取引区分 = B.取引区分
       ,担当者コード = B.担当者コード
       ,営業所コード = B.営業所コード
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
       ,仕入先名称 = B.仕入先名称
WHEN NOT MATCHED THEN
    INSERT(
       管伝票番号
       ,伝票年月日
       ,仕入先コード
       ,取引区分
       ,担当者コード
       ,営業所コード
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
       ,仕入先名称
    )
    VALUES
    (
	    B.伝票番号
       ,B.伝票年月日
       ,B.仕入先コード
       ,B.取引区分
       ,B.担当者コード
       ,B.営業所コード
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
       ,B.仕入先名称
    )
;