﻿MERGE INTO 出庫明細 AS A
USING
    (
        SELECT
            @p0 AS 伝票番号
           ,@p1 AS 行番号
           ,@p2 AS 商品コード
           ,@p3 AS メーカーコード
           ,@p4 AS 大分類コード
           ,@p5 AS 中分類コード
           ,@p6 AS Ｃ１
           ,@p7 AS Ｃ２
           ,@p8 AS Ｃ３
           ,@p9 AS Ｃ４
           ,@p10 AS Ｃ５
           ,@p11 AS Ｃ６
           ,@p12 AS 数量
           ,@p13 AS 単価
           ,@p14 AS 備考
           ,@p15 AS 出庫倉庫
           ,@p16 AS 受注番号
           ,@p17 AS 出庫予定日
           ,@p18 AS 出庫済フラグ
           ,@p19 AS 削除
           ,@p20 AS 登録日時
           ,@p21 AS 登録ユーザー名
           ,@p22 AS 更新日時
           ,@p23 AS 更新ユーザー名
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.行番号 = B.行番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        商品コード = B.商品コード
       ,メーカーコード = B.メーカーコード
       ,大分類コード = B.大分類コード
       ,中分類コード = B.中分類コード
       ,Ｃ１ = B.Ｃ１
       ,Ｃ２ = B.Ｃ２
       ,Ｃ３ = B.Ｃ３
       ,Ｃ４ = B.Ｃ４
       ,Ｃ５ = B.Ｃ５
       ,Ｃ６ = B.Ｃ６
       ,数量 = B.数量
       ,単価 = B.単価
       ,備考 = B.備考
       ,出庫倉庫 = B.出庫倉庫
       ,受注番号 = B.受注番号
       ,出庫予定日 = B.出庫予定日
       ,出庫済フラグ = B.出庫済フラグ
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        伝票番号
       ,行番号
       ,商品コード
       ,メーカーコード
       ,大分類コード
       ,中分類コード
       ,Ｃ１
       ,Ｃ２
       ,Ｃ３
       ,Ｃ４
       ,Ｃ５
       ,Ｃ６
       ,数量
       ,単価
       ,備考
       ,出庫倉庫
       ,受注番号
       ,出庫予定日
       ,出庫済フラグ
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.伝票番号
       ,B.行番号
       ,B.商品コード
       ,B.メーカーコード
       ,B.大分類コード
       ,B.中分類コード
       ,B.Ｃ１
       ,B.Ｃ２
       ,B.Ｃ３
       ,B.Ｃ４
       ,B.Ｃ５
       ,B.Ｃ６
       ,B.数量
       ,B.単価
       ,B.備考
       ,B.出庫倉庫
       ,B.受注番号
       ,B.出庫予定日
       ,B.出庫済フラグ
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;