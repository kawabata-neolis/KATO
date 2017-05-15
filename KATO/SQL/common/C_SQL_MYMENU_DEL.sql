MERGE INTO [KATO].[dbo].マイメニュー AS A
USING
    (
        SELECT
		    @p0 AS ユーザー名
           ,@p1 AS メニューＮＯ

    ) AS B
ON
    (
        A.ユーザー名 = B.ユーザー名
    AND A.メニューＮＯ = B.メニューＮＯ
    )
WHEN MATCHED THEN
    DELETE
;