﻿MERGE INTO 棚卸調整 AS A
USING
    (
        SELECT
		    @p0 AS ＩＤ
    ) AS B
ON
    (
        A.ＩＤ = B.ＩＤ
    )
WHEN MATCHED THEN
    DELETE
;