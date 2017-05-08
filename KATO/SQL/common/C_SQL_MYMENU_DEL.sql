MERGE INTO [KATO].[dbo].マイメニュー AS A
USING
    (
        SELECT
		    @0 AS ユーザー名
           ,@1 AS メニューＮＯ

    ) AS B
ON
    (
        A.ユーザー名 = B.ユーザー名
    AND A.メニューＮＯ = B.メニューＮＯ
    )
WHEN MATCHED THEN
    DELETE
;