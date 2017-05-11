﻿MERGE INTO [KATO].[dbo].MO AS A
USING
    (
        SELECT
            @0 AS 年月度
           ,@1 AS 仕入先コード
           ,@2 AS 商品コード
           ,@3 AS メーカーコード
           ,@4 AS 大分類コード
           ,@5 AS 中分類コード
           ,@6 AS Ｃ１
           ,@7 AS Ｃ２
           ,@8 AS Ｃ３
           ,@9 AS Ｃ４
           ,@10 AS Ｃ５
           ,@11 AS Ｃ６
           ,@12 AS 現在在庫数
           ,@13 AS 売上数量
           ,@14 AS 仕入数量
           ,@15 AS 発注残数量
           ,@16 AS 受注残数量
           ,@17 AS ＭＯ発注指示数
           ,@18 AS ＭＯ発注数
           ,@19 AS ＭＯ発注単価
           ,@20 AS 納期
           ,@21 AS 取引先コード
           ,@22 AS 発注番号
           ,@23 AS 確定フラグ
           ,@24 AS 削除
           ,@25 AS 登録日時
           ,@26 AS 登録ユーザー名
           ,@27 AS 更新日時
           ,@28 AS 更新ユーザー名
    ) AS B
ON
    (
        A.年月度 = B.年月度
    AND A.商品コード = B.商品コード
    AND A.取引先コード = B.取引先コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
       仕入先コード = B.仕入先コード
       ,メーカーコード = B.メーカーコード
       ,大分類コード = B.大分類コード
       ,中分類コード = B.中分類コード
       ,Ｃ１ = B.Ｃ１
       ,Ｃ２ = B.Ｃ２
       ,Ｃ３ = B.Ｃ３
       ,Ｃ４ = B.Ｃ４
       ,Ｃ５ = B.Ｃ５
       ,Ｃ６ = B.Ｃ６
       ,現在在庫数 = B.現在在庫数
       ,売上数量 = B.売上数量
       ,仕入数量 = B.仕入数量
       ,発注残数量 = B.発注残数量
       ,受注残数量 = B.受注残数量
       ,ＭＯ発注指示数 = B.ＭＯ発注指示数
       ,ＭＯ発注数 = B.ＭＯ発注数
       ,ＭＯ発注単価 = B.ＭＯ発注単価
       ,納期 = B.納期
       ,発注番号 = B.発注番号
       ,確定フラグ = B.確定フラグ
       ,削除 = B.削除
       ,登録日時 = B.登録日時
       ,登録ユーザー名 = B.登録ユーザー名
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名

WHEN NOT MATCHED THEN
    INSERT(
        年月度
       ,仕入先コード
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
       ,現在在庫数
       ,売上数量
       ,仕入数量
       ,発注残数量
       ,受注残数量
       ,ＭＯ発注指示数
       ,ＭＯ発注数
       ,ＭＯ発注単価
       ,納期
       ,取引先コード
       ,発注番号
       ,確定フラグ
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名


    )
    VALUES
    (
	    B.年月度
       ,B.仕入先コード
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
       ,B.現在在庫数
       ,B.売上数量
       ,B.仕入数量
       ,B.発注残数量
       ,B.受注残数量
       ,B.ＭＯ発注指示数
       ,B.ＭＯ発注数
       ,B.ＭＯ発注単価
       ,B.納期
       ,B.取引先コード
       ,B.発注番号
       ,B.確定フラグ
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;