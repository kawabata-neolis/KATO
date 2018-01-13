SELECT Rtrim(ISNULL(Ｃ１,'')) + ' ' +
	   Rtrim(ISNULL(Ｃ２,'')) + ' ' +
	   Rtrim(ISNULL(Ｃ３,'')) + ' ' +
	   Rtrim(ISNULL(Ｃ４,'')) + ' ' +
	   Rtrim(ISNULL(Ｃ５,'')) + ' ' +
	   Rtrim(ISNULL(Ｃ６,'')) AS 品名・規格, 
	   ＭＯ発注数 AS 数量, 
	   ＭＯ発注単価 AS 発注単価, 
	   納期, 
	   dbo.f_get取引先名称(取引先コード) AS 仕向け先, 
	   RTRIM(dbo.f_get注番文字FROM担当者('0003')) + CAST(発注番号 AS varchar(8)) AS 注番 
FROM ＭＯ
WHERE 年月度 = '{0}' AND 
	  メーカーコード = '{1}' AND 
	  大分類コード = '{2}' AND 
	  中分類コード = '{3}' AND 
	  確定フラグ  = '0' AND 
	  削除 = 'N' AND 
	  ＭＯ発注数 > 0
