UPDATE 日付制限
SET 最小年月日 = '{2}',
    最大年月日 = '{3}',
	更新日時 = '{4}',
	更新ユーザー名 = 'sys'
WHERE 画面ＮＯ = '{0}'
	  AND 営業所コード = '{1}'
