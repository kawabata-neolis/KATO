﻿MERGE INTO [KATO].[dbo].商品売上履歴TMP AS A
USING
    (
        SELECT
		    @0 AS ID
    ) AS B
ON
    (
        A.ID = B.ID
    )
WHEN MATCHED THEN
    DELETE
;