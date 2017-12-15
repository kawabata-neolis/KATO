MERGE INTO カレンダ AS A
USING
    (
        SELECT
            @p0 AS カレンダＩＤ
           ,@p1 AS 年度
           ,@p2 AS 月度
           ,@p3 AS 年月日
           ,@p4 AS コメント
           ,@p5 AS D01
           ,@p6 AS D02
           ,@p7 AS D03
           ,@p8 AS D04
           ,@p9 AS D05
           ,@p10 AS D06
           ,@p11 AS D07
           ,@p12 AS D08
           ,@p13 AS D09
           ,@p14 AS D10
           ,@p15 AS D11
           ,@p16 AS D12
           ,@p17 AS D13
           ,@p18 AS D14
           ,@p19 AS D15
           ,@p20 AS D16
           ,@p21 AS D17
           ,@p22 AS D18
           ,@p23 AS D19
           ,@p24 AS D20
           ,@p25 AS D21
           ,@p26 AS D22
           ,@p27 AS D23
           ,@p28 AS D24
           ,@p29 AS D25
           ,@p30 AS D26
           ,@p31 AS D27
           ,@p32 AS D28
           ,@p33 AS D29
           ,@p34 AS D30
           ,@p35 AS D31
           ,@p36 AS 登録日時
           ,@p37 AS 登録ユーザー名
           ,@p38 AS 更新日時
           ,@p39 AS 更新ユーザー名

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