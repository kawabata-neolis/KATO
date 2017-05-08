MERGE INTO [KATO].[dbo].取引先コード検索 AS A
USING
    (
        SELECT
            @0 AS 取引先コード
           ,@1 AS 取引先名称
           ,@2 AS カナ
    ) AS B
ON
    (
        A.取引先コード = B.取引先コード
    )
WHEN MATCHED THEN
    UPDATE
    SET
        取引先名称 = B.取引先名称
       ,カナ = B.カナ
WHEN NOT MATCHED THEN
    INSERT(
        取引先コード
       ,取引先名称
       ,カナ
    )
    VALUES
    (
	    B.取引先コード
       ,B.取引先名称
       ,B.カナ
    )
;