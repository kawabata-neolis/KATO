﻿MERGE INTO 初期設定 AS A
USING
    (
        SELECT
            @p0 AS 項目名
           ,@p1 AS 設定値
           ,@p2 AS コメント
    ) AS B
ON
    (
        A.項目名 = B.項目名
    )
WHEN MATCHED THEN
    UPDATE
    SET
        設定値 = B.設定値
       ,コメント = B.コメント
WHEN NOT MATCHED THEN
    INSERT(
        項目名
       ,設定値
       ,コメント
    )
    VALUES
    (
	    B.項目名
       ,B.設定値
       ,B.コメント
    )
;