UPDATE 発注
SET 発注金額=ROUND(発注単価*発注数量,0,1)
WHERE 発注番号 = '{0}'
