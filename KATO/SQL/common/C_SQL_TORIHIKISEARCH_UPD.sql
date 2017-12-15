MERGE INTO 取引先コード検索 AS A
USING
    (
        SELECT
            @p0 AS 取引先コード
           ,@p1 AS 取引先名称
           ,@p2 AS カナ
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