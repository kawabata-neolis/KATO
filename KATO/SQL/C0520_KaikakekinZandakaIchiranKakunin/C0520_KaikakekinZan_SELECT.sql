SELECT コード, 
	   得意先名, 
	   年月, 
	   前月買掛残, 
	   支払現金, 
	   支払小切手, 
	   支払振込, 
	   支払手形, 
	   支払相殺, 
	   支払手数料, 
	   支払その他, 
	   繰越残高, 
	   当月仕入高, 
	   当月消費税, 
	   当月残高,
	   税区,
	   フリガナ
FROM (
		SELECT T.取引先コード As コード ,
		T.取引先名称 AS 得意先名 ,
		CONVERT(CHAR(7),DATEADD(d,1,K.年月日),111) AS 年月,
		dbo.f_get買掛残高一覧表_繰越残高FROM取引先経理情報(T.取引先コード,DATEADD(d,1,K.年月日) )  AS 前月買掛残, 
		dbo.f_get買掛残高一覧表_支払_現金(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払現金,
		dbo.f_get買掛残高一覧表_支払_小切手(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払小切手,
		dbo.f_get買掛残高一覧表_支払_振込(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払振込,
		dbo.f_get買掛残高一覧表_支払_手形(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払手形,
		dbo.f_get買掛残高一覧表_支払_相殺(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払相殺,
		dbo.f_get買掛残高一覧表_支払_手数料(T.取引先コード,DATEADD(d,1,K.年月日),dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払手数料,
		dbo.f_get買掛残高一覧表_支払_その他(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 支払その他,
		dbo.f_get買掛残高一覧表_繰越残高FROM取引先経理情報(T.取引先コード,DATEADD(d,1,K.年月日) )
		- dbo.f_get買掛残高一覧表_支払_現金(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_小切手(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_振込(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_手形(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_相殺(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_手数料(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_その他(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))) AS 繰越残高,
		CASE WHEN 消費税区分=1 THEN
			dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
			- dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
		ELSE
			dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		END AS 当月仕入高,
		CASE WHEN 消費税区分=0 AND 消費税計算区分=2 THEN
			dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
			WHEN 消費税区分=1 THEN
			dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
		ELSE
		dbo.f_get買掛残高一覧表_仕入ヘッダ_消費税(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		END AS 当月消費税, 
		dbo.f_get買掛残高一覧表_繰越残高FROM取引先経理情報(T.取引先コード,DATEADD(d,1,K.年月日) )
		- dbo.f_get買掛残高一覧表_支払_現金(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_小切手(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_振込(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_手形(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_相殺(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_手数料(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		- dbo.f_get買掛残高一覧表_支払_その他(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
		+ ( CASE WHEN 消費税区分=1 THEN
				dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
				- dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
			ELSE
				dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
			END
		)
		+ ( CASE WHEN 消費税区分=0 AND 消費税計算区分=2 THEN
				dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
				WHEN 消費税区分=1 THEN
				dbo.f_get売掛残高一覧表_月間消費税(T.取引先コード, dbo.f_月末日(DATEADD(m,1,K.年月日)),dbo.f_get買掛残高一覧表_仕入ヘッダ_仕入高(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日))))
			ELSE
				dbo.f_get買掛残高一覧表_仕入ヘッダ_消費税(T.取引先コード,DATEADD(d,1,K.年月日), dbo.f_月末日(DATEADD(m,1,K.年月日)))
			END
		)  AS 当月残高 ,
		CASE WHEN 消費税区分=1 THEN '(内税)' ELSE '' END 税区,
		T.カナ AS フリガナ
	FROM 取引先 T, 
		取引先経理情報 K
	WHERE T.削除 = 'N'
	AND T.取引先コード>='{0}'
	AND T.取引先コード<='{1}'
	AND T.取引先コード=K.取引先コード
	AND DATEADD(d,1,K.年月日) >= '{2}'
	AND DATEADD(d,1,K.年月日) <= '{3}'
	AND K.情報区分='22'
) A 
	 
WHERE A.前月買掛残 != '0' 
	  OR A.支払現金 != '0' 
	  OR A.支払小切手 != '0' 
	  OR A.支払振込 != '0' 
	  OR A.支払手形 != '0' 
	  OR A.支払相殺 != '0' 
	  OR A.支払手数料 != '0' 
	  OR A.支払その他 != '0' 
	  OR A.当月仕入高 != '0' 
	  OR A.当月消費税 != '0' 
	  
ORDER BY A.コード,A.年月

