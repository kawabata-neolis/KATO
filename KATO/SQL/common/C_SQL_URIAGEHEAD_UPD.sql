﻿MERGE INTO [KATO].[dbo].売上ヘッダ AS A
USING
    (
        SELECT
            @0 AS 伝票番号
           ,@1 AS 伝票年月日
           ,@2 AS 得意先コード
           ,@3 AS 得意先名
           ,@4 AS 郵便番号
           ,@5 AS 住所１
           ,@6 AS 住所２
           ,@7 AS 取引区分
           ,@8 AS 担当者コード
           ,@9 AS 営業所コード
           ,@10 AS 摘要コード
           ,@11 AS 摘要欄
           ,@12 AS 納入方法
           ,@13 AS 税抜合計金額
           ,@14 AS 消費税
           ,@15 AS 税込合計金額
           ,@16 AS 粗利額
           ,@17 AS 請求書発行フラグ
           ,@18 AS 伝票発行フラグ
           ,@19 AS 直送先コード
           ,@20 AS 直送先名
           ,@21 AS 直送先郵便番号
           ,@22 AS 直送先住所１
           ,@23 AS 直送先住所２
           ,@24 AS 削除
           ,@25 AS 登録日時
           ,@26 AS 登録ユーザー名
           ,@27 AS 更新日時
           ,@28 AS 更新ユーザー名
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        伝票年月日 = B.伝票年月日
       ,得意先コード = B.得意先コード
       ,得意先名 = B.得意先名
       ,郵便番号 = B.郵便番号
       ,住所１ = B.住所１
       ,住所２ = B.住所２
       ,取引区分 = B.取引区分
       ,担当者コード = B.担当者コード
       ,営業所コード = B.営業所コード
       ,摘要コード = B.摘要コード
       ,摘要欄 = B.摘要欄
       ,納入方法 = B.納入方法
       ,税抜合計金額 = B.税抜合計金額
       ,消費税 = B.消費税
       ,税込合計金額 = B.税込合計金額
       ,粗利額 = B.粗利額
       ,請求書発行フラグ = B.請求書発行フラグ
       ,伝票発行フラグ = B.伝票発行フラグ
       ,直送先コード = B.直送先コード
       ,直送先名 = B.直送先名
       ,直送先郵便番号 = B.直送先郵便番号
       ,直送先住所１ = B.直送先住所１
       ,直送先住所２ = B.直送先住所２
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        伝票番号
       ,伝票年月日
       ,得意先コード
       ,得意先名
       ,郵便番号
       ,住所１
       ,住所２
       ,取引区分
       ,担当者コード
       ,営業所コード
       ,摘要コード
       ,摘要欄
       ,納入方法
       ,税抜合計金額
       ,消費税
       ,税込合計金額
       ,粗利額
       ,請求書発行フラグ
       ,伝票発行フラグ
       ,直送先コード
       ,直送先名
       ,直送先郵便番号
       ,直送先住所１
       ,直送先住所２
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.伝票番号
       ,B.伝票年月日
       ,B.得意先コード
       ,B.得意先名
       ,B.郵便番号
       ,B.住所１
       ,B.住所２
       ,B.取引区分
       ,B.担当者コード
       ,B.営業所コード
       ,B.摘要コード
       ,B.摘要欄
       ,B.納入方法
       ,B.税抜合計金額
       ,B.消費税
       ,B.税込合計金額
       ,B.粗利額
       ,B.請求書発行フラグ
       ,B.伝票発行フラグ
       ,B.直送先コード
       ,B.直送先名
       ,B.直送先郵便番号
       ,B.直送先住所１
       ,B.直送先住所２
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;