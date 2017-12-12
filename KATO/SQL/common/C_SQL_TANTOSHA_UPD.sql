﻿MERGE INTO [KATO].[dbo].担当者 AS A
USING
    (
        SELECT
            @p0 AS 担当者コード
           ,@p1 AS 担当者名
           ,@p2 AS ログインＩＤ
           ,@p3 AS 営業所コード
           ,@p4 AS 注番文字
           ,@p5 AS グループコード
           ,@p6 AS 年間売上目標
           ,@p7 AS マスタ権限
           ,@p8 AS 閲覧権限
           ,@p9 AS 利益率権限
           ,@p10 AS 役職コード
           ,@p11 AS 表示
           ,@p12 AS 削除
           ,@p13 AS 登録日時
           ,@p14 AS 登録ユーザー名
           ,@p15 AS 更新日時
           ,@p16 AS 更新ユーザー名
    ) AS B
ON
    (
        A.担当者コード = B.担当者コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
担当者名 = B.担当者名
       ,ログインＩＤ = B.ログインＩＤ
       ,営業所コード = B.営業所コード
       ,注番文字 = B.注番文字
       ,グループコード = B.グループコード
       ,年間売上目標 = B.年間売上目標
       ,マスタ権限 = B.マスタ権限
       ,閲覧権限 = B.閲覧権限
       ,利益率権限 = B.利益率権限
	   ,役職コード = B.役職コード
	   ,表示 = B.表示
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        担当者コード
       ,担当者名
       ,ログインＩＤ
       ,営業所コード
       ,注番文字
       ,グループコード
       ,年間売上目標
       ,マスタ権限
       ,閲覧権限
       ,利益率権限
	   ,役職コード
	   ,表示
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    担当者コード
       ,B.担当者名
       ,B.ログインＩＤ
       ,B.営業所コード
       ,B.注番文字
       ,B.グループコード
       ,B.年間売上目標
       ,B.マスタ権限
       ,B.閲覧権限
       ,B.利益率権限
	   ,B.役職コード
	   ,B.表示
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名

    )
;