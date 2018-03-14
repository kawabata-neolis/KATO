SELECT T.取引先コード As コード ,
	   T.取引先名称 AS 得意先名 ,
	   CONVERT(CHAR(7),DATEADD(d,1,K.年月日),111) AS 年月,
	   dbo.f_get売掛残高一覧表_繰越残高FROM取引先経理情報(T.取引先コード,DATEADD(d,1,K.年月日) )  AS 前月売掛残, 
	   dbo.f_get売掛残高一覧表_入金_現金(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金現金,
	   dbo.f_get売掛残高一覧表_入金_小切手(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金小切手,
	   dbo.f_get売掛残高一覧表_入金_振込(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金振込,
	   dbo.f_get売掛残高一覧表_入金_手形(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金手形,
	   dbo.f_get売掛残高一覧表_入金_相殺(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金相殺,
	   dbo.f_get売掛残高一覧表_入金_手数料(T.取引先コード,DATEADD(d,1,K.年月日),dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金手数料,
	   dbo.f_get売掛残高一覧表_入金_その他(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 入金その他,
	   dbo.f_get売掛残高一覧表_繰越残高FROM取引先経理情報(T.取引先コード,DATEADD(d,1,K.年月日) )
	   	- dbo.f_get売掛残高一覧表_入金_現金(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_小切手(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_振込(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_手形(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_相殺(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_手数料(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_その他(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 繰越残高,
	   CASE WHEN 消費税区分=1 THEN
	   	dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
	   ELSE
	    dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   END AS 当月売上高,
	   CASE WHEN 消費税区分=0 AND 消費税計算区分=2 THEN
	   	dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
	   		WHEN 消費税区分=1 THEN
	   	dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
 	   ELSE
	   	dbo.f_get売掛残高一覧表_売上ヘッダ_消費税(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   END AS 当月消費税, 
	   dbo.f_get売掛残高一覧表_繰越残高FROM取引先経理情報(T.取引先コード,DATEADD(d,1,K.年月日) )
	   	- dbo.f_get売掛残高一覧表_入金_現金(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_小切手(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_振込(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_手形(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_相殺(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_手数料(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	- dbo.f_get売掛残高一覧表_入金_その他(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   	+ ( CASE WHEN 消費税区分=1 THEN
	   		dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   			- dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
	   		ELSE
	   			dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   		END
	   	)
	   	+ ( CASE WHEN 消費税区分=0 AND 消費税計算区分=2 THEN
	   			dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
	   				WHEN 消費税区分=1 THEN
	   			dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get売掛残高一覧表_売上ヘッダ_売上高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
	   		ELSE
	   			dbo.f_get売掛残高一覧表_売上ヘッダ_消費税(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
	   		END
	   	)  AS 当月残高 ,
	   	CASE WHEN 消費税区分=1 THEN '内税' ELSE '' END 税区,
		T.カナ AS フリガナ
FROM 取引先 T, 取引先経理情報 K
WHERE T.削除 = 'N'
	  AND T.取引先コード<>'6666'
	  AND T.取引先コード<>'8888'
	  AND T.取引先コード>='{0}'
	  AND T.取引先コード<='{1}'
	  AND T.取引先コード=K.取引先コード	  
	  AND DATEADD(d,1,K.年月日) >= '{2}'
	  AND DATEADD(d,1,K.年月日) <= '{3}'	  
	  AND K.情報区分='21'
ORDER BY {4}