SELECT 入金年月日, dbo.f_get取引先名称(得意先コード) as 得意先名, 入金額, 伝票番号
FROM 入金
WHERE 削除 = 'N' AND 得意先コード = '{0}'
 ORDER BY 入金年月日 DESC , 得意先コード