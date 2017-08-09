SELECT *
FROM 消費税率
WHERE 適用開始年月日 = (SELECT MAX(適用開始年月日)
						FROM 消費税率 
						WHERE (適用開始年月日 <='{0}'))
