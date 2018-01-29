SELECT
 a.商品コード,
 a.売上,
 a.仕入,
 [KATO].dbo.f_getメーカー名(b.メーカーコード) AS メーカー名,
 a.型番,
 a.在庫数量,
 a.定価,
 a.評価単価,
 a.掛率,
 a.仮単価,
 a.仮掛率,
 a.最終売上単価,
 a.売掛率,
 a.最終売上日,
 a.最終仕入単価,
 a.入掛率,
 a.最終仕入日,
 b.メーカーコード,
 b.大分類コード AS 大分類コード,
 b.中分類コード AS 中分類コード
FROM [KATO].[dbo].[商品仕入単価履歴TMP2] AS a
LEFT JOIN [KATO].[dbo].[商品] AS b
ON a.商品コード = b.商品コード
AND b.削除 = 'N'
WHERE 在庫年月日='{0}'
{1}
ORDER BY 大分類コード, 中分類コード, 型番