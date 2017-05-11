﻿MERGE INTO [KATO].[dbo].在庫一覧データ AS A
USING
    (
        SELECT
		    @0 AS 営業所コード
           ,@1 AS 商品コード
    ) AS B
ON
    (
        A.営業所コード = B.営業所コード
    AND A.商品コード = B.商品コード
    )
WHEN MATCHED THEN
    DELETE
;