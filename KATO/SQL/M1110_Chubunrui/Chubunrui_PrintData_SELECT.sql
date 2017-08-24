SELECT a.大分類コード ,b.大分類名, a.中分類コード , a.中分類名
FROM 中分類 a, 大分類 b
WHERE a.削除 = 'N'
AND b.大分類コード = a.大分類コード
AND b.削除 = 'N'
ORDER BY a.大分類コード, a.中分類コード