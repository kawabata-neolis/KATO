MERGE INTO 取引先経理情報 AS A
USING
    (
        SELECT
		    @p0 AS 取引先コード
           ,@p1 AS 情報区分
           ,@p2 AS 年月日
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