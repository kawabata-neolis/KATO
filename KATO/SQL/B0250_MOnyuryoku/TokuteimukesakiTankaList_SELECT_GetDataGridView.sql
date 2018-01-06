SELECT 得意先コード,
       dbo.f_get取引先名称(得意先コード) AS 仕向先,
	   dbo.f_getメーカー名(dbo.f_get商品コードからメーカーコード(商品コード)) AS ﾒｰｶｰ, 
	   型番,
	   単価, 
	   dbo.f_get商品コードから最終仕入日(商品コード) AS 最終仕入日, 
	   仕入先コード, 
	   商品コード 
FROM 特定向先単価 

WHERE 削除 = 'N' 
{0} 
ORDER BY 型番, 単価,仕入先コード ASC
