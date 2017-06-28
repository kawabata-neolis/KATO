SELECT 支払年月日, dbo.f_get取引先名称(仕入先コード) as 仕入先名, 支払額, 伝票番号
FROM 支払
WHERE 削除 = 'N'
 ORDER BY 支払年月日 DESC , 仕入先コード