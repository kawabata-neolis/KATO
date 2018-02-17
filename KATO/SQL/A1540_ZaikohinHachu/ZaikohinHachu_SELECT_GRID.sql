SELECT a.発注番号,
       a.注番,
	   dbo.f_getメーカー名(a.メーカーコード) as メーカー名,
	   dbo.f_get中分類名(a.大分類コード,a.中分類コード) as 中分類名,
	   RTRIM(ISNULL(a.Ｃ１,'')) + ' ' + 
	   RTRIM(ISNULL(a.Ｃ２,'')) + ' ' + 
	   RTRIM(ISNULL(a.Ｃ３,'')) + ' ' +
	   RTRIM(ISNULL(a.Ｃ４,'')) + ' ' +
	   RTRIM(ISNULL(a.Ｃ５,'')) + ' ' +
	   RTRIM(ISNULL(a.Ｃ６,'')) as 型番,
	   a.発注数量,a.納期
FROM 在庫品発注 a
WHERE 仕入先コード = '{0}'
	  AND a.削除 ='N'
 ORDER BY a.納期