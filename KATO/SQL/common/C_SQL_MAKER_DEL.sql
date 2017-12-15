MERGE INTO メーカー AS A
USING
    (
        SELECT
		    @p0  AS メーカーコード

    ) AS B
ON
    (
        A.メーカーコード = B.メーカーコード
    )
WHEN MATCHED THEN
    DELETE
;