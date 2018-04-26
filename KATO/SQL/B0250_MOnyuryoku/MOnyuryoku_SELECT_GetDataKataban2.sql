SELECT Rtrim(ISNULL(ＭＯ.Ｃ１, '')) AS 型番,
       ＭＯ.現在在庫数 AS ﾌﾘ在庫,
       ＭＯ.売上数量 AS 売上数,
       ＭＯ.仕入数量 AS 仕入数,
       ＭＯ.発注残数量 AS 発注残,
       ＭＯ.ＭＯ発注指示数 AS 発注指,
       ＭＯ.ＭＯ発注数 AS 発注数,
       ＭＯ.ＭＯ発注単価 AS 単価,
       ROUND(ＭＯ.ＭＯ発注数*ＭＯ.ＭＯ発注単価,0,0) AS 金額,
       ＭＯ.納期,
       ＭＯ.取引先コード AS ｺｰﾄﾞ,
       RTRIM(取引先.取引先名称) AS 仕向け先名,
       ＭＯ.発注担当者コード,
       担当者.担当者名 AS 発注担当者,
       '{5}' + CAST(発注番号 AS varchar(8)) AS 発注番号, 
       ＭＯ.発注番号 AS 発注番号2,
       ＭＯ.商品コード,
       Rtrim(ISNULL(ＭＯ.Ｃ１,'')) AS Ｃ１,
       Rtrim(ISNULL(ＭＯ.Ｃ２,'')) AS Ｃ２,
       Rtrim(ISNULL(ＭＯ.Ｃ３,'')) AS Ｃ３,
       Rtrim(ISNULL(ＭＯ.Ｃ４,'')) AS Ｃ４,
       Rtrim(ISNULL(ＭＯ.Ｃ５,'')) AS Ｃ５,
       Rtrim(ISNULL(ＭＯ.Ｃ６,'')) AS Ｃ６,
       商品.箱入数,
       仕入.最終仕入日,
	   ＭＯ.中分類コード
FROM ＭＯ left join (
		SELECT M.商品コード, MAX(H.伝票年月日) as 最終仕入日
		FROM 仕入ヘッダ H,仕入明細 M
 		WHERE H.削除 = 'N'
 		  AND M.削除 = 'N'
 		  AND H.伝票番号 = M.伝票番号 
 		group by 商品コード) as 仕入 on ＭＯ.削除 = 'N' and 仕入.商品コード = ＭＯ.商品コード
	left join 担当者 on ＭＯ.削除 = 'N' and 担当者.削除 = 'N' and 担当者.担当者コード = ＭＯ.発注担当者コード
	left join 商品 on ＭＯ.削除 = 'N' and 商品.削除 = 'N' and 商品.商品コード = ＭＯ.商品コード
	left join 取引先 on ＭＯ.削除 = 'N' and 取引先.削除 = 'N' and 取引先.取引先コード = ＭＯ.取引先コード
WHERE ＭＯ.年月度 = '{0}' 
	  AND ＭＯ.メーカーコード = '{1}' 
	  AND ＭＯ.大分類コード = '{2}' 
	  {3}
	  AND ＭＯ.確定フラグ = '0'
	  {4} 
ORDER BY 型番 