﻿MERGE INTO 返品値引売上承認 AS A
USING
    (
        SELECT
            @p0 AS 受注番号
    ) AS B
ON
    (
        A.受注番号 = B.受注番号
    )
WHEN MATCHED THEN
    DELETE
;