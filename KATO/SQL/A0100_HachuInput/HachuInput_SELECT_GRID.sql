SELECT a.発注番号,
       a.注番,
	   dbo.f_getメーカー名(a.メーカーコード) as メーカー名,
	   dbo.f_get中分類名(a.大分類コード,a.中分類コード) as 中分類名,
	   RTRIM(ISNULL(a.Ｃ１,'')) as 型番,
	   a.発注数量,a.納期,
	   a.仕入先名称 AS 仕入先名
FROM 発注 a
WHERE 仕入先コード = '{0}'
	  AND a.発注フラグ =0
	  AND a.削除 ='N'
 ORDER BY a.納期