﻿MERGE INTO [KATO].[dbo].前年売上実績 AS A
USING
    (
        SELECT
            @p0 AS 取引先コード
           ,@p1 AS 金額１
           ,@p2 AS 金額２
           ,@p3 AS 金額３
           ,@p4 AS 金額４
           ,@p5 AS 金額５
           ,@p6 AS 金額６
           ,@p7 AS 金額７
           ,@p8 AS 金額８
           ,@p9 AS 金額９
           ,@p10 AS 金額１０
           ,@p11 AS 金額１１
           ,@p12 AS 金額１２
    ) AS B
ON
    (
        A.取引先コード = B.取引先コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
        金額１ = B.金額１
       ,金額２ = B.金額２
       ,金額３ = B.金額３
       ,金額４ = B.金額４
       ,金額５ = B.金額５
       ,金額６ = B.金額６
       ,金額７ = B.金額７
       ,金額８ = B.金額８
       ,金額９ = B.金額９
       ,金額１０ = B.金額１０
       ,金額１１ = B.金額１１
       ,金額１２ = B.金額１２
WHEN NOT MATCHED THEN
    INSERT(
        取引先コード
       ,金額１
       ,金額２
       ,金額３
       ,金額４
       ,金額５
       ,金額６
       ,金額７
       ,金額８
       ,金額９
       ,金額１０
       ,金額１１
       ,金額１２
    )
    VALUES
    (
	    B.取引先コード
       ,B.金額１
       ,B.金額２
       ,B.金額３
       ,B.金額４
       ,B.金額５
       ,B.金額６
       ,B.金額７
       ,B.金額８
       ,B.金額９
       ,B.金額１０
       ,B.金額１１
       ,B.金額１２
    )
;