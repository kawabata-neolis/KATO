SELECT *, dbo.f_getメーカー名(メーカーコード) AS メーカー名
FROM 発注
WHERE 発注番号 = '{0}'
	  AND 削除 = 'N'