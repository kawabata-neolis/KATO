﻿MERGE INTO 出庫依頼 AS A
USING
    (
        SELECT
            @p0 AS 依頼年月日
           ,@p1 AS 伝票番号
           ,@p2 AS 担当者コード
           ,@p3 AS 営業所コード
           ,@p4 AS 出庫倉庫
           ,@p5 AS 商品コード
           ,@p6 AS メーカーコード
           ,@p7 AS 大分類コード
           ,@p8 AS 中分類コード
           ,@p9 AS Ｃ１
           ,@p10 AS Ｃ２
           ,@p11 AS Ｃ３
           ,@p12 AS Ｃ４
           ,@p13 AS Ｃ５
           ,@p14 AS Ｃ６
           ,@p15 AS 数量
           ,@p16 AS 単価
           ,@p17 AS 承認年月日
           ,@p18 AS 承認
           ,@p19 AS 処理済
           ,@p20 AS 削除
           ,@p21 AS 登録日時
           ,@p22 AS 登録ユーザー名
           ,@p23 AS 更新日時
           ,@p24 AS 更新ユーザー名
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        伝票番号 = B.伝票番号
       ,担当者コード = B.担当者コード
       ,営業所コード = B.営業所コード
       ,出庫倉庫 = B.出庫倉庫
       ,商品コード = B.商品コード
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
       ,承認年月日 = B.承認年月日
       ,承認 = B.承認
       ,処理済 = B.処理済
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名

WHEN NOT MATCHED THEN
    INSERT(
        依頼年月日
       ,伝票番号
       ,担当者コード
       ,営業所コード
       ,出庫倉庫
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
       ,承認年月日
       ,承認
       ,処理済
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.依頼年月日
       ,B.伝票番号
       ,B.担当者コード
       ,B.営業所コード
       ,B.出庫倉庫
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
       ,B.承認年月日
       ,B.承認
       ,B.処理済
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;