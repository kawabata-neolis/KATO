SELECT 商品コード,SUM(M.数量) AS 売上数, H.伝票年月日
FROM 売上明細 M ,売上ヘッダ H
WHERE H.伝票番号=M.伝票番号
AND H.削除='N'
AND M.削除='N'
AND H.伝票年月日>= '{0}'
AND H.伝票年月日<= '{1}'
AND H.取引区分	IN ('11','12','13','14','15','16','17','18')
GROUP BY 商品コード, 伝票年月日
ORDER BY 商品コード
