SELECT *
FROM (
	SELECT a.発注番号,
		CASE WHEN a.加工区分='0' THEN '発注' ELSE '加工' END AS 区分,
		a.発注年月日 AS 日付,
		RTRIM(dbo.f_get注番文字FROM担当者 (発注者コード)) + CAST(発注番号 AS varchar(8)) AS 注番,
		dbo.f_getメーカー名(a.メーカーコード) + 
		' ' + dbo.f_get中分類名(a.大分類コード,a.中分類コード) +  
		' ' + Rtrim(ISNULL(a.Ｃ１,''))+ 
		' ' + Rtrim(ISNULL(a.Ｃ２,''))+ 
		' ' + Rtrim(ISNULL(a.Ｃ３,''))+ 
		' ' + Rtrim(ISNULL(a.Ｃ４,''))+ 
		' ' + Rtrim(ISNULL(a.Ｃ５,''))+ 
		' ' + Rtrim(ISNULL(a.Ｃ６,'')) AS 型番,
		a.発注数量 AS 数量,
		a.発注単価 AS 単価,
		a.納期,
		dbo.f_get取引先名称(a.仕入先コード) AS 仕入先名,
		dbo.f_get発注番号から仕入日(a.発注番号) AS 仕入日,
		a.仕入済数量 AS 仕入数量,
		a.登録日時
	FROM 発注 a
	WHERE a.受注番号 = '{0}' 
		  AND a.削除 ='N'
	-- 	  
	UNION ALL

	SELECT a.伝票番号,
		   CASE a.取引区分 WHEN '41' THEN '出庫' WHEN '43' THEN '加工出庫'  WHEN '42' THEN '入庫(原在)'   WHEN '44' THEN '入庫(原)' END AS 区分,
		   a.伝票年月日,
		   b.備考,
		   dbo.f_getメーカー名(b.メーカーコード) 
		   + ' ' + dbo.f_get中分類名(b.大分類コード,b.中分類コード) +  ' '  +  Rtrim(ISNULL(b.Ｃ１,'')) 
		   + ' ' + Rtrim(ISNULL(b.Ｃ２,''))
		   + ' ' + Rtrim(ISNULL(b.Ｃ３,''))
		   + ' ' + Rtrim(ISNULL(b.Ｃ４,''))
		   + ' ' + Rtrim(ISNULL(b.Ｃ５,''))
	       + ' ' + Rtrim(ISNULL(b.Ｃ６,'')),
	       b.数量,
	       b.単価,
	       b.出庫予定日,
	       dbo.f_get取引先名称(a.仕入先コード) AS 仕入先名,
	       NULL,
	       NULL,
	       b.登録日時
	FROM 出庫ヘッダ a,出庫明細 b
	WHERE a.伝票番号 = b.伝票番号 
		  AND a.削除 ='N'
		  AND b.削除 ='N'
		  AND b.受注番号 = '{0}'
) Z
ORDER BY 登録日時
