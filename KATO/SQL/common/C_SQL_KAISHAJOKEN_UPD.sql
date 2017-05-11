﻿MERGE INTO [KATO].[dbo].会社処理条件 AS A
USING
    (
        SELECT
            @0  AS 会社コード
           ,@1  AS 会社名
           ,@2  AS 郵便番号
           ,@3  AS 住所１
           ,@4  AS 住所２
           ,@5  AS 代表者名
           ,@6  AS 電話番号
           ,@7  AS ＦＡＸ
           ,@8  AS 期首月
           ,@9  AS 開始年月日
           ,@10 AS 終了年月日
           ,@11 AS 削除
           ,@12 AS 登録日時
           ,@13 AS 登録ユーザー名
           ,@14 AS 更新日時
           ,@15 AS 更新ユーザー名

    ) AS B
ON
    (
        A.会社コード = B.会社コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
       会社名 = B.会社名
       ,郵便番号 = B.郵便番号
       ,住所１ = B.住所１
       ,住所２ = B.住所２
       ,代表者名 = B.代表者名
       ,電話番号 = B.電話番号
       ,ＦＡＸ = B.ＦＡＸ
       ,期首月 = B.期首月
       ,開始年月日 = B.開始年月日
       ,終了年月日 = B.終了年月日
       ,削除 = B.削除
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名


WHEN NOT MATCHED THEN
    INSERT(
        会社コード
       ,会社名
       ,郵便番号
       ,住所１
       ,住所２
       ,代表者名
       ,電話番号
       ,ＦＡＸ
       ,期首月
       ,開始年月日
       ,終了年月日
       ,削除
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.会社コード
       ,B.会社名
       ,B.郵便番号
       ,B.住所１
       ,B.住所２
       ,B.代表者名
       ,B.電話番号
       ,B.ＦＡＸ
       ,B.期首月
       ,B.開始年月日
       ,B.終了年月日
       ,B.削除
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名

    )
;