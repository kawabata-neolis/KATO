MERGE INTO [KATO].[dbo].カレンダ AS A
USING
    (
        SELECT
		    @0 AS カレンダＩＤ
           ,@1 AS 年度
           ,@2 AS 月度

    ) AS B
ON
    (
        A.カレンダＩＤ = B.カレンダＩＤ
    AND A.年度 = B.年度
    AND A.月度 = B.月度
    )
WHEN MATCHED THEN
    DELETE
;