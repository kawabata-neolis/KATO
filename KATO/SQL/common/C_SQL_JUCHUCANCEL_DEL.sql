﻿MERGE INTO [KATO].[dbo].受注キャンセル AS A
USING
    (
        SELECT
		    @0 AS 管理ＮＯ
    ) AS B
ON
    (
        A.管理ＮＯ = B.管理ＮＯ
    )
WHEN MATCHED THEN
    DELETE
;