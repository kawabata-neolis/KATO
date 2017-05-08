MERGE INTO [KATO].[dbo].取引先経理情報 AS A
USING
    (
        SELECT
		    @0 AS 取引先コード
           ,@1 AS 情報区分
           ,@2 AS 年月日
    ) AS B
ON
    (
        A.取引先コード = B.取引先コード
    AND A.情報区分 = B.情報区分
    AND A.年月日 = B.年月日
    )
WHEN MATCHED THEN
    DELETE
;