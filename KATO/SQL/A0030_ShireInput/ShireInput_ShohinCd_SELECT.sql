SELECT 商品コード FROM 商品 
WHERE 削除='N' 
AND メーカーコード= '{0}' 
AND 大分類コード= '{1}'
AND 中分類コード= '{2}'
AND REPLACE(ISNULL(Ｃ１,'')+ISNULL(Ｃ２,'')+ISNULL(Ｃ３,'')+ISNULL(Ｃ４,'')+ISNULL(Ｃ５,'')+ISNULL(Ｃ６,'') ,' ' ,'')= '{3}'
