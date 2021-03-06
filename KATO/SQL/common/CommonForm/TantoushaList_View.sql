SELECT 担当者.担当者コード, 
       担当者.担当者名, 
	   担当者.営業所コード,
	   担当者.注番文字, 
	   グループ.グループ名,
	   担当者.年間売上目標
FROM 担当者, グループ
WHERE 担当者.削除='N' AND 
	  担当者.グループコード = グループ.グループコード 
	  {0}
ORDER BY 担当者.グループコード, 担当者.役職コード, 担当者.担当者コード