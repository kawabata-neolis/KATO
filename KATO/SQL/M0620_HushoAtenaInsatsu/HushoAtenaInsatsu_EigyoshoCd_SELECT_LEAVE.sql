SELECT 取引先名称,
	   郵便番号 ,
	   住所１,
	   住所２,
	   Ａ郵便番号 ,
	   Ａ住所１,
	   Ａ住所２,
	   領収書送付先名,
	   領収書送付郵便番号 ,
	   領収書送付住所１,
	   領収書送付住所２,
	   請求書送付先名,
	   請求書送付郵便番号 ,
	   請求書送付住所１,
	   請求書送付住所２
FROM 取引先
WHERE 削除 = 'N'
AND 取引先コード ='{0}'
