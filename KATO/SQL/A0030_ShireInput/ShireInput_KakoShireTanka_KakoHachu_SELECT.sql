SELECT SUM(発注単価*発注数量) 
FROM 発注 
WHERE 削除='N' AND 受注番号= '{0}' AND 加工区分='1'