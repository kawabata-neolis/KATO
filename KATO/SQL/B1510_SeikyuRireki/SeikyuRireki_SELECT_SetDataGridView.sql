SELECT 得意先コード,
       (
			SELECT 取引先.取引先名称 
			FROM 取引先 
			WHERE 取引先.取引先コード = 請求履歴.得意先コード
	   )AS 取引先名称,
	   請求年月日,
	   前回請求額,
	   入金額,
	   繰越額,
	   売上額,
	   消費税,
	   今回請求額 
FROM 請求履歴 
{0} 
{1} 
{2} 
{3} 
ORDER BY 請求年月日 DESC, 得意先コード ASC
