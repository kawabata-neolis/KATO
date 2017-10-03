SELECT Rtrim(ISNULL(Ｃ１,'')),
       Rtrim(ISNULL(Ｃ２,'')),
       Rtrim(ISNULL(Ｃ３,'')),
       Rtrim(ISNULL(Ｃ４,'')),
       Rtrim(ISNULL(Ｃ５,'')),
       Rtrim(ISNULL(Ｃ６,'')),
       現在在庫数,
	   売上数量,
	   仕入数量,
	   発注残数量,
	   受注残数量,
	   ＭＯ発注指示数,
	   ＭＯ発注数,
	   ＭＯ発注単価,
	   ROUND(ＭＯ発注数*ＭＯ発注単価,0,0),
	  	納期,
		取引先コード,
		dbo.f_get取引先名称(取引先コード),
		RTRIM(dbo.f_get注番文字FROM担当者('0003')) + CAST(発注番号 AS varchar(8)) AS 注番,
		発注番号,
		商品コード,
		Rtrim(ISNULL(Ｃ１,'')),
		Rtrim(ISNULL(Ｃ２,'')),
		Rtrim(ISNULL(Ｃ３,'')),
		Rtrim(ISNULL(Ｃ４,'')),
		Rtrim(ISNULL(Ｃ５,'')),
		Rtrim(ISNULL(Ｃ６,'')),
		dbo.f_get商品箱入数(商品コード),
		dbo.f_get商品コードから最終仕入日(商品コード)
FROM ＭＯ
WHERE 年月度 = '{0}'
     AND メーカーコード = '{1}'
	 AND 大分類コード = '{2}'
	 AND 中分類コード = '{3}'
	 AND 確定フラグ ='0'
	 AND 削除 ='N'
	 ORDER BY Rtrim(ISNULL(Ｃ１,''))