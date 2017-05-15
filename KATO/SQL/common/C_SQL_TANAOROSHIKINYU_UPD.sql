﻿MERGE INTO [KATO].[dbo].棚番 AS A
USING
    (
        SELECT
		    @p0 AS 棚卸年月日
           ,@p1 AS 営業所コード
           ,@p2 AS 営業所名
           ,@p3 AS 棚番
           ,@p4 AS 大分類コード
           ,@p5 AS 大分類名
           ,@p6 AS 中分類コード
           ,@p7 AS 中分類名
           ,@p8 AS メーカーコード
           ,@p9 AS メーカー名
           ,@p10 AS 商品コード
           ,@p11 AS 品名型番
           ,@p12 AS 指定日在庫
           ,@p13 AS 棚卸数量
           ,@p14 AS 更新区分
           ,@p15 AS 登録日時
           ,@p16 AS 登録ユーザー名
           ,@p17 AS 更新日時
           ,@p18 AS 更新ユーザー名
    ) AS B
ON
    (
        A.棚卸年月日 = B.棚卸年月日
    AND A.営業所コード = B.営業所コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    営業所名 = B.営業所名
       ,棚番 = B.棚番
       ,大分類コード = B.大分類コード
       ,大分類名 = B.大分類名
       ,中分類コード = B.中分類コード
       ,中分類名 = B.中分類名
       ,メーカーコード = B.メーカーコード
       ,メーカー名 = B.メーカー名
       ,品名型番 = B.品名型番
       ,指定日在庫 = B.指定日在庫
       ,棚卸数量 = B.棚卸数量
       ,更新区分 = B.更新区分
       ,登録日時 = B.登録日時
       ,登録ユーザー名 = B.登録ユーザー名
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        棚卸年月日
       ,営業所コード
       ,営業所名
       ,棚番
       ,大分類コード
       ,大分類名
       ,中分類コード
       ,中分類名
       ,メーカーコード
       ,メーカー名
       ,商品コード
       ,品名型番
       ,指定日在庫
       ,棚卸数量
       ,更新区分
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.棚卸年月日
       ,B.営業所コード
       ,B.営業所名
       ,B.棚番
       ,B.大分類コード
       ,B.大分類名
       ,B.中分類コード
       ,B.中分類名
       ,B.メーカーコード
       ,B.メーカー名
       ,B.商品コード
       ,B.品名型番
       ,B.指定日在庫
       ,B.棚卸数量
       ,B.更新区分
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;