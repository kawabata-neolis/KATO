SELECT Rtrim(ISNULL(Ｃ１, '')) AS 型番,
       現在在庫数 AS ﾌﾘｰ在庫,
	   売上数量 AS 売上数,
	   仕入数量 AS 仕入数,
	   発注残数量 AS 発注残,
	   ＭＯ発注指示数 AS 発注指,
	   ＭＯ発注数 AS 発注数,
	   ＭＯ発注単価 AS 単価,
	   ROUND(ＭＯ発注数*ＭＯ発注単価,0,0) AS 金額,
	   納期,
	   取引先コード AS ｺｰﾄﾞ,
	   dbo.f_get取引先名称(取引先コード) AS 仕向け先名,
	   発注担当者コード,
	   RTRIM(dbo.f_get注番文字FROM担当者('0003')) + CAST(発注番号 AS varchar(8)) AS 発注番号, 
	   発注番号 AS 発注番号2,
	   商品コード,
	   Rtrim(ISNULL(Ｃ１,'')) AS Ｃ１,
	   Rtrim(ISNULL(Ｃ２,'')) AS Ｃ２,
	   Rtrim(ISNULL(Ｃ３,'')) AS Ｃ３,
	   Rtrim(ISNULL(Ｃ４,'')) AS Ｃ４,
	   Rtrim(ISNULL(Ｃ５,'')) AS Ｃ５,
	   Rtrim(ISNULL(Ｃ６,'')) AS Ｃ６
FROM ＭＯ 
WHERE 年月度 = '{0}' 
	  AND メーカーコード = '{1}' 
	  AND 大分類コード = '{2}' 
	  {3} 
	  AND 確定フラグ = '0' 
	  AND 削除 = 'N'  
	  AND ＭＯ発注数 <> 0 
ORDER BY 型番