MERGE INTO [KATO].[dbo].伝票番号 AS A
USING
    (
        SELECT
            @p0  AS テーブル名
    ) AS B
ON
    (
        A.テーブル名 = B.テーブル名
    )
WHEN MATCHED THEN
    DELETE
;