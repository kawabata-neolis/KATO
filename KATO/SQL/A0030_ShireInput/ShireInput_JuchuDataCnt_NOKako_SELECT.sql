SELECT COUNT(*) FROM 受注 J,発注 H WHERE J.受注番号= '{0}' AND J.受注番号=H.受注番号
AND REPLACE(ISNULL(J.Ｃ１,'')+ISNULL(J.Ｃ２,'')+ISNULL(J.Ｃ３,'')+ISNULL(J.Ｃ４,'')+ISNULL(J.Ｃ５,'')+ISNULL(J.Ｃ６,'') ,' ' ,'')= '{1}'
