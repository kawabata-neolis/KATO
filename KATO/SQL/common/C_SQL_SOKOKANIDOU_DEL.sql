MERGE INTO [KATO].[dbo].倉庫間移動 AS A
USING
    (
        SELECT
		    @0 AS 伝票番号
           ,@1 AS 処理番号
           ,@2 AS 取引区分
    ) AS B
ON
    (
        A.伝票番号 = B.伝票番号
    AND A.処理番号 = B.処理番号
    AND A.取引区分 = B.取引区分
    )
WHEN MATCHED THEN
    DELETE
;