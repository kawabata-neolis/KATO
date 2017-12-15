MERGE INTO 日付制限 AS A
USING
    (
        SELECT
            @p0 AS 画面ＮＯ
           ,@p1 AS 営業所コード
    ) AS B
ON
    (
        A.画面ＮＯ = B.画面ＮＯ
    AND A.営業所コード = B.営業所コード
    )
WHEN MATCHED THEN
    DELETE
;