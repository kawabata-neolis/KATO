SELECT 伝票年月日,伝票番号,行番号,取引区分名,名前,入庫数,出庫数,0 as 在庫数,単価
FROM 商品在庫元帳_VIEW
WHERE 商品コード = '{0}'
	AND 倉庫 = '{1}'
	AND 伝票年月日 >= '{2}'
	AND 伝票年月日 <= '{3}'
ORDER BY 伝票年月日,表示順,伝票番号,行番号