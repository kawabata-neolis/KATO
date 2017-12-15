﻿MERGE INTO 商品仕入単価履歴TMP2 AS A
USING
    (
        SELECT
		    @p0 AS 在庫年月日
           ,@p1 AS 商品コード
           ,@p2 AS 売上
           ,@p3 AS 仕入
           ,@p4 AS 型番
           ,@p5 AS 在庫数量
           ,@p6 AS 仕入単価
           ,@p7 AS 定価
           ,@p8 AS 評価単価
           ,@p9 AS 掛率
           ,@p10 AS 仮単価
           ,@p11 AS 仮掛率
           ,@p12 AS 最終売上日
           ,@p13 AS 最終売上単価
           ,@p14 AS 売掛率
           ,@p15 AS 最終仕入日
           ,@p16 AS 最終仕入単価
           ,@p17 AS 入掛率
           ,@p18 AS 直近仕入単価
    ) AS B
ON
    (
        A.在庫年月日 = B.在庫年月日
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    売上 = B.売上
       ,仕入 = B.仕入
       ,型番 = B.型番
       ,在庫数量 = B.在庫数量
       ,仕入単価 = B.仕入単価
       ,定価 = B.定価
       ,評価単価 = B.評価単価
       ,掛率 = B.掛率
       ,仮単価 = B.仮単価
       ,仮掛率 = B.仮掛率
       ,最終売上日 = B.最終売上日
       ,最終売上単価 = B.最終売上単価
       ,売掛率 = B.売掛率
       ,最終仕入日 = B.最終仕入日
       ,最終仕入単価 = B.最終仕入単価
       ,入掛率 = B.入掛率
       ,直近仕入単価 = B.直近仕入単価
WHEN NOT MATCHED THEN
    INSERT(
        在庫年月日
       ,商品コード
       ,売上
       ,仕入
       ,型番
       ,在庫数量
       ,仕入単価
       ,定価
       ,評価単価
       ,掛率
       ,仮単価
       ,仮掛率
       ,最終売上日
       ,最終売上単価
       ,売掛率
       ,最終仕入日
       ,最終仕入単価
       ,入掛率
       ,直近仕入単価
    )
    VALUES
    (
	    B.在庫年月日
       ,B.商品コード
       ,B.売上
       ,B.仕入
       ,B.型番
       ,B.在庫数量
       ,B.仕入単価
       ,B.定価
       ,B.評価単価
       ,B.掛率
       ,B.仮単価
       ,B.仮掛率
       ,B.最終売上日
       ,B.最終売上単価
       ,B.売掛率
       ,B.最終仕入日
       ,B.最終仕入単価
       ,B.入掛率
       ,B.直近仕入単価
    )
;