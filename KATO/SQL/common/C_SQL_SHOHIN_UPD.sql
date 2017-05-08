﻿MERGE INTO [KATO].[dbo].商品 AS A
USING
    (
        SELECT
		    @p0  AS 商品コード
		   ,@p1  AS メーカーコード
		   ,@p2  AS 大分類コード
		   ,@p3  AS 中分類コード
		   ,@p4  AS Ｃ１
		   ,@p5  AS Ｃ２
		   ,@p6  AS Ｃ３
		   ,@p7  AS Ｃ４
		   ,@p8  AS Ｃ５
		   ,@p9  AS Ｃ６
		   ,@p10 AS 発注区分
		   ,@p11 AS 標準売価
		   ,@p12 AS 仕入単価
		   ,@p13 AS 在庫管理区分
		   ,@p14 AS 棚番本社
		   ,@p15 AS 棚番岐阜
		   ,@p16 AS メモ
		   ,@p17 AS 評価単価
		   ,@p18 AS 定価
		   ,@p19 AS 箱入数
		   ,@p20 AS 削除
		   ,@p21 AS 登録日時
		   ,@p22 AS 登録ユーザー名
		   ,@p23 AS 更新日時
		   ,@p24 AS 更新ユーザー名
    ) AS B
ON
    (
        A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
	   メーカーコード = B.メーカーコード
	  ,大分類コード   = B.大分類コード
	  ,中分類コード   = B.中分類コード
	  ,Ｃ１           = B.Ｃ１
	  ,Ｃ２           = B.Ｃ２
	  ,Ｃ３           = B.Ｃ３
	  ,Ｃ４           = B.Ｃ４
	  ,Ｃ５           = B.Ｃ５
	  ,Ｃ６           = B.Ｃ６
	  ,発注区分       = B.発注区分
	  ,標準売価       = B.標準売価
	  ,仕入単価       = B.仕入単価
	  ,在庫管理区分   = B.在庫管理区分
	  ,棚番本社       = B.棚番本社
	  ,棚番岐阜       = B.棚番岐阜
	  ,メモ           = B.メモ
	  ,評価単価       = B.評価単価
	  ,定価           = B.定価
	  ,箱入数         = B.箱入数
	  ,削除           = B.削除
	  ,更新日時       = B.更新日時
	  ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        商品コード
       ,メーカーコード
       ,大分類コード
       ,中分類コード
       ,Ｃ１
       ,Ｃ２
       ,Ｃ３
       ,Ｃ４
       ,Ｃ５
       ,Ｃ６
       ,発注区分
       ,標準売価
       ,仕入単価
       ,在庫管理区分
       ,棚番本社
       ,棚番岐阜
       ,メモ
       ,評価単価
       ,定価
       ,箱入数
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.商品コード
       ,B.メーカーコード
       ,B.大分類コード
       ,B.中分類コード
       ,B.Ｃ１
       ,B.Ｃ２
       ,B.Ｃ３
       ,B.Ｃ４
       ,B.Ｃ５
       ,B.Ｃ６
       ,B.発注区分
       ,B.標準売価
       ,B.仕入単価
       ,B.在庫管理区分
       ,B.棚番本社
       ,B.棚番岐阜
       ,B.メモ
       ,B.評価単価
       ,B.定価
       ,B.箱入数
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;