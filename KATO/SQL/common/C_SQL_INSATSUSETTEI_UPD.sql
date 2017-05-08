MERGE INTO [KATO].[dbo].印刷設定 AS A
USING
    (
        SELECT
            @0 AS ユーザー名
           ,@1 AS ＰＧ番号
           ,@2 AS プリンタ名
           ,@3 AS 出力用紙サイズ
           ,@4 AS Ｎアップ
           ,@5 AS 両面印刷
    ) AS B
ON
    (
        A.ユーザー名 = B.ユーザー名
    AND A.ＰＧ番号 = B.ＰＧ番号
    )
WHEN MATCHED THEN
    UPDATE
    SET
        プリンタ名 = B.プリンタ名
       ,出力用紙サイズ = B.出力用紙サイズ
       ,Ｎアップ = B.Ｎアップ
       ,両面印刷 = B.両面印刷

WHEN NOT MATCHED THEN
    INSERT(
        ユーザー名
       ,ＰＧ番号
       ,プリンタ名
       ,出力用紙サイズ
       ,Ｎアップ
       ,両面印刷
    )
    VALUES
    (
	    B.ユーザー名
       ,B.ＰＧ番号
       ,B.プリンタ名
       ,B.出力用紙サイズ
       ,B.Ｎアップ
       ,B.両面印刷
    )
;