SELECT *,dbo.f_getメーカー名(仕入明細.メーカーコード) AS メーカー名 
FROM 仕入明細 
WHERE 伝票番号= '{0}' AND 削除='N' 
ORDER BY 行番号