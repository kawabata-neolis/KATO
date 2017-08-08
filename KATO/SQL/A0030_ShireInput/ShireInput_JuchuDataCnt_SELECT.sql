SELECT COUNT(*) 
FROM 受注 J,発注 H 
WHERE J.受注番号= '{0}' AND J.受注番号=H.受注番号 AND H.加工区分='1'