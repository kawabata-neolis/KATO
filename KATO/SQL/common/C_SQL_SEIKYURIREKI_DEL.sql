﻿MERGE INTO 請求履歴 AS A
USING
    (
        SELECT
		    @p0 AS 得意先コード
           ,@p1 AS 請求年月日
    ) AS B
ON
    (
        A.得意先コード = B.得意先コード
    AND A.請求年月日 = B.請求年月日
    )
WHEN MATCHED THEN
    DELETE
;