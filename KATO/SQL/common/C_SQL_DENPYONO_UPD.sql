MERGE INTO 伝票番号 AS A
USING
    (
        SELECT
            @p0 AS テーブル名
           ,@p1 AS 最終番号
           ,@p2 AS 更新日時
    ) AS B
ON
    (
        A.テーブル名 = B.テーブル名
    )
WHEN MATCHED THEN
    UPDATE
    SET
	    最終番号 = B.最終番号
       ,更新日時 = B.更新日時
WHEN NOT MATCHED THEN
    INSERT(
        テーブル名
       ,最終番号
       ,更新日時
    )
    VALUES
    (
	    B.テーブル名
       ,B.最終番号
       ,B.更新日時
    )
;