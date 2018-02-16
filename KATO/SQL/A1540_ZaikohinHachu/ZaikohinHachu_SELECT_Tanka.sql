	 SELECT 発注単価, MAX(更新日時) as 日時
	 FROM 発注
 	 WHERE 商品コード = '{0}' AND 登録日時 between DATEADD(month, -6, GETDATE()) AND GETDATE()
 	 GROUP BY 発注単価
 	 ORDER BY 日時 DESC
