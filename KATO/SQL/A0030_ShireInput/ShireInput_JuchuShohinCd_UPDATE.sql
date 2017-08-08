UPDATE 受注 
SET 商品コード= '{0}'
WHERE 受注番号= '{1}'
AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')='{2}'
