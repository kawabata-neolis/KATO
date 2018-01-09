UPDATE ＭＯ
SET ＭＯ発注数=0,
	納期 = null,
	発注番号 = null
WHERE 年月度= '{0}' AND 
	  発注番号 = '{1}'
