MERGE INTO [KATO].[dbo].日付制限 AS A
USING
    (
        SELECT
            @0 AS 画面ＮＯ
           ,@1 AS 営業所コード
    ) AS B
ON
    (
        A.画面ＮＯ = B.画面ＮＯ
    AND A.営業所コード = B.営業所コード
    )
WHEN MATCHED THEN
    DELETE
;