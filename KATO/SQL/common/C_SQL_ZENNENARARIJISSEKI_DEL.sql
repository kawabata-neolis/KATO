﻿MERGE INTO 前年粗利実績 AS A
USING
    (
        SELECT
		    @p0 AS 取引先コード
    ) AS B
ON
    (
        A.取引先コード = B.取引先コード
    )
WHEN MATCHED THEN
    DELETE
;