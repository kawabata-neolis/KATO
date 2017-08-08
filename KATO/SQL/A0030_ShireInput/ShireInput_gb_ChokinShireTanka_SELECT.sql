SELECT H.伝票年月日,M.仕入単価 
FROM 仕入ヘッダ H,仕入明細 M 
WHERE H.削除='N' and M.削除='N' AND H.伝票番号=M.伝票番号 AND  M.商品コード= '{0}' 
ORDER BY H.伝票年月日 DESC