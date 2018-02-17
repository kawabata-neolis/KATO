SELECT 担当者名
 , TBL.受注計
 , TBL.発注計
 , TBL.仕入計
 , TBL.売上計
 , TBL.入庫計
 , TBL.出庫計
 , (TBL.受注計 + TBL.発注計 + TBL.仕入計 + TBL.売上計 + TBL.入庫計 + TBL.出庫計) AS 担当計
FROM (
      SELECT 担当者コード,
             dbo.f_get担当者名(担当者コード) AS 担当者名,
             dbo.f_担当者別伝票カウント_受注(ログインＩＤ, '{0}', '{1}') AS 受注計,
             dbo.f_担当者別伝票カウント_発注(ログインＩＤ, '{0}', '{1}') AS 発注計,
             dbo.f_担当者別伝票カウント_仕入(ログインＩＤ, '{0}', '{1}') AS 仕入計,
             dbo.f_担当者別伝票カウント_売上(ログインＩＤ, '{0}', '{1}') AS 売上計,
             dbo.f_担当者別伝票カウント_入庫(ログインＩＤ, '{0}', '{1}') AS 入庫計,
             dbo.f_担当者別伝票カウント_出庫(ログインＩＤ, '{0}', '{1}') AS 出庫計
      FROM 担当者
      WHERE 削除 = 'N'
        AND 担当者コード >='{2}'
	    AND 担当者コード <='{3}'
     ) AS TBL
ORDER BY TBL.担当者コード
