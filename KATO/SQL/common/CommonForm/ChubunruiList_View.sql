SELECT 中分類コード, 中分類名, 補助名称
FROM 中分類 
WHERE 削除 = 'N' 
      AND 大分類コード = '{0}'