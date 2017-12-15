MERGE INTO 発注 AS A
USING
    (
        SELECT
            @p0 AS 仕入先コード
    ) AS B
ON
    (
        A.画面ＮＯ = B.仕入先コード
    )
WHEN MATCHED THEN
    DELETE
;