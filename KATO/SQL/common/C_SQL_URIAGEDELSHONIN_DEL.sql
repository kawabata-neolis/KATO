﻿MERGE INTO 売上削除承認 AS A
USING
    (
        SELECT
		    @p0 AS 伝票番号
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    )
WHEN MATCHED THEN
    DELETE
;