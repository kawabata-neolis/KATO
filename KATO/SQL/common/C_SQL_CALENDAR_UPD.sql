MERGE INTO [KATO].[dbo].カレンダ AS A
USING
    (
        SELECT
            @0 AS カレンダＩＤ
           ,@1 AS 年度
           ,@2 AS 月度
           ,@3 AS 年月日
           ,@4 AS コメント
           ,@5 AS D01
           ,@6 AS D02
           ,@7 AS D03
           ,@8 AS D04
           ,@9 AS D05
           ,@10 AS D06
           ,@11 AS D07
           ,@12 AS D08
           ,@13 AS D09
           ,@14 AS D10
           ,@15 AS D11
           ,@16 AS D12
           ,@17 AS D13
           ,@18 AS D14
           ,@19 AS D15
           ,@20 AS D16
           ,@21 AS D17
           ,@22 AS D18
           ,@23 AS D19
           ,@24 AS D20
           ,@25 AS D21
           ,@26 AS D22
           ,@27 AS D23
           ,@28 AS D24
           ,@29 AS D25
           ,@30 AS D26
           ,@31 AS D27
           ,@32 AS D28
           ,@33 AS D29
           ,@34 AS D30
           ,@35 AS D31
           ,@36 AS 登録日時
           ,@37 AS 登録ユーザー名
           ,@38 AS 更新日時
           ,@39 AS 更新ユーザー名

    ) AS B
ON
    (
        A.カレンダＩＤ = B.カレンダＩＤ
    AND A.年度 = B.年度
    AND A.月度 = B.月度
    )
WHEN MATCHED THEN
    UPDATE
    SET
       年月日 = B.年月日
       ,コメント = B.コメント
       ,D01 = B.D01
       ,D02 = B.D02
       ,D03 = B.D03
       ,D04 = B.D04
       ,D05 = B.D05
       ,D06 = B.D06
       ,D07 = B.D07
       ,D08 = B.D08
       ,D09 = B.D09
       ,D10 = B.D10
       ,D11 = B.D11
       ,D12 = B.D12
       ,D13 = B.D13
       ,D14 = B.D14
       ,D15 = B.D15
       ,D16 = B.D16
       ,D17 = B.D17
       ,D18 = B.D18
       ,D19 = B.D19
       ,D20 = B.D20
       ,D21 = B.D21
       ,D22 = B.D22
       ,D23 = B.D23
       ,D24 = B.D24
       ,D25 = B.D25
       ,D26 = B.D26
       ,D27 = B.D27
       ,D28 = B.D28
       ,D29 = B.D29
       ,D30 = B.D30
       ,D31 = B.D31
       ,更新日時 = B.更新日時
       ,更新ユーザー名 = B.更新ユーザー名
WHEN NOT MATCHED THEN
    INSERT(
        カレンダＩＤ
       ,年度
       ,月度
       ,年月日
       ,コメント
       ,D01
       ,D02
       ,D03
       ,D04
       ,D05
       ,D06
       ,D07
       ,D08
       ,D09
       ,D10
       ,D11
       ,D12
       ,D13
       ,D14
       ,D15
       ,D16
       ,D17
       ,D18
       ,D19
       ,D20
       ,D21
       ,D22
       ,D23
       ,D24
       ,D25
       ,D26
       ,D27
       ,D28
       ,D29
       ,D30
       ,D31
       ,登録日時
       ,登録ユーザー名
       ,更新日時
       ,更新ユーザー名
    )
    VALUES
    (
	    B.カレンダＩＤ
       ,B.年度
       ,B.月度
       ,B.年月日
       ,B.コメント
       ,B.D01
       ,B.D02
       ,B.D03
       ,B.D04
       ,B.D05
       ,B.D06
       ,B.D07
       ,B.D08
       ,B.D09
       ,B.D10
       ,B.D11
       ,B.D12
       ,B.D13
       ,B.D14
       ,B.D15
       ,B.D16
       ,B.D17
       ,B.D18
       ,B.D19
       ,B.D20
       ,B.D21
       ,B.D22
       ,B.D23
       ,B.D24
       ,B.D25
       ,B.D26
       ,B.D27
       ,B.D28
       ,B.D29
       ,B.D30
       ,B.D31
       ,B.登録日時
       ,B.登録ユーザー名
       ,B.更新日時
       ,B.更新ユーザー名
    )
;