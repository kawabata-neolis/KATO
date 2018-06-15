DELETE FROM MO月別実績

INSERT INTO MO月別実績(商品コード,年月,売上数量,出庫数量,入庫数量,仕入数量,発注残,受注残,登録日時,登録ユーザー名)
SELECT 商品コード,年月,売上数量,出庫数量,入庫数量,仕入数量,発注残,受注残,'{2}','{3}'
  from (
        select 商品コード,  convert(char(7),年月日,111) as 年月, sum(売上数量) as 売上数量, sum(出庫数量) as 出庫数量, sum(仕入数量) as 仕入数量, sum(入庫数量) as 入庫数量, sum(発注残数) as 発注残, sum(受注残数) as 受注残
          from (
                select 商品コード, 伝票年月日 as 年月日, 売上数量, null as 出庫数量, null as 入庫数量, null as 仕入数量, null as 発注残数, null as 受注残数
                  from (
                             SELECT 商品コード,SUM(M.数量) AS 売上数量, convert(char(7),伝票年月日,111) as 伝票年月日
                               FROM 売上明細 M ,売上ヘッダ H
                              WHERE H.伝票番号=M.伝票番号
                                AND H.削除='N'
                                AND M.削除='N'
                                AND H.伝票年月日>='{0}'
                                AND H.伝票年月日<='{1}'
                                AND H.取引区分 IN ('11','12','13','14','15','16','17','18')
                              GROUP BY 商品コード, convert(char(7),伝票年月日,111)
                            ) as a
                union
                select 商品コード, 出庫予定日 as 年月日, null as 売上数量, 出庫数量, null as 入庫数量, null as 仕入数量, null as 発注残数, null as 受注残数
                  from (
                             SELECT 商品コード,SUM(出庫明細.数量) as 出庫数量, convert(char(7),出庫明細.出庫予定日,111) as 出庫予定日
                       		   FROM 出庫ヘッダ, 出庫明細
                              WHERE 出庫ヘッダ.伝票番号 = 出庫明細.伝票番号
                                AND 出庫ヘッダ.削除 = 'N'
                                AND 出庫ヘッダ.取引区分 IN ('41','43')
                                AND 出庫明細.出庫予定日>='{0}'
                                AND 出庫明細.出庫予定日<='{1}'
                                AND 出庫明細.削除 = 'N'
                              GROUP BY 商品コード, convert(char(7),出庫明細.出庫予定日,111)
                            ) as a
				union
				SELECT 商品コード, 伝票年月日 as 年月日, null as 売上数量, null as 出庫数量, 仕入数量, null as 入庫数量, null as 発注残数, null as 受注残数
				  FROM(
				             SELECT	商品コード,SUM(数量) as 仕入数量, convert(char(7),仕入ヘッダ.伝票年月日,111) as 伝票年月日
				   	           FROM 仕入ヘッダ, 仕入明細
					          WHERE 仕入ヘッダ.伝票番号	= 仕入明細.伝票番号
					            AND 仕入ヘッダ.削除 = 'N'
					            AND 仕入ヘッダ.伝票年月日>='{0}'
 					            AND 仕入ヘッダ.伝票年月日<='{1}'
					            AND 仕入ヘッダ.取引区分	IN ('21','22','23','24','25','26','27','28')
				                AND 仕入明細.削除 = 'N'
					          GROUP BY 商品コード,convert(char(7),伝票年月日,111)
							) as a
			    union
				SELECT 商品コード, 出庫予定日 as 年月日, null as 売上数量, null as 出庫数量, null as 仕入数量, 入庫数量, null as 発注残数, null as 受注残数
					from (
				          	  SELECT 商品コード,SUM(出庫明細.数量) as 入庫数量, convert(char(7),出庫明細.出庫予定日,111) as 出庫予定日
								FROM 出庫ヘッダ, 出庫明細
							   WHERE 出庫ヘッダ.伝票番号	= 出庫明細.伝票番号
								 AND 出庫ヘッダ.削除 = 'N'
								 AND 出庫ヘッダ.取引区分	IN ('42')
								 AND 出庫明細.出庫予定日>='{0}'
								 AND 出庫明細.出庫予定日<='{1}'
								 AND 出庫明細.削除 = 'N'
							   GROUP BY 商品コード,convert(char(7),出庫明細.出庫予定日,111)
							 ) as a
				union
				SELECT 商品コード, 発注年月日 as 年月日, null as 売上数量, null as 出庫数量, null as 仕入数量, null as 入庫数量, 発注残数, null as 受注残数
					FROM (
							  SELECT 商品コード, convert(char(7),発注年月日,111) as 発注年月日, CASE WHEN SUM(ISNULL(発注数量,'0') - ISNULL(仕入済数量,'0')) != 0
																									 THEN SUM(ISNULL(発注数量,'0') - ISNULL(仕入済数量,'0'))
																									 ELSE NULL
																									  END as 発注残数
							    FROM 発注
							   WHERE 削除 = 'N'
							     AND 仕入先コード<>'9999'
							     AND(発注数量>=仕入済数量 OR 発注数量<0)
       						     AND 発注年月日>='{0}'
       							 AND 発注年月日<='{1}'
							   GROUP BY 商品コード,convert(char(7),発注年月日,111)
				  			) as a
				union
				SELECT 商品コード, 年月日, null as 売上数量, null as 出庫数量, null as 入庫数量, null as 仕入数量, null as 発注残数, 受注残数
					FROM (
							  SELECT 商品コード, 年月日, CASE WHEN SUM(ISNULL(受注残数A,'0') + ISNULL(受注残数B,'0')) != 0
									 						  THEN SUM(ISNULL(受注残数A,'0') + ISNULL(受注残数B,'0'))
															  ELSE NULL
															   END AS 受注残数
							  	FROM(
							 	     select 商品コード, 受注年月日 as 年月日, (ISNULL(数１,'0') + ISNULL(数２,'0') + ISNULL(数３,'0')) as 受注残数A, null as 受注残数B
								     	from(
 											 select 商品コード, 受注年月日, 数１, 数２, 数３
												from(
		    										SELECT 商品コード, SUM(受注数量 - 売上済数量) AS 数１, null as 数２, null as 数３, convert(char(7),受注年月日,111) as 受注年月日
        	  											FROM 受注
            												WHERE 削除='N'
            												  AND 発注指示区分 = '1'
            												  AND 受注年月日>='{0}'
            												  AND 受注年月日<='{1}'
            												GROUP BY 商品コード, convert(char(7),受注年月日,111)
		    										union
		    										SELECT 商品コード, null as 数１, SUM(受注数量 - 売上済数量) AS 数２, null as 数３, convert(char(7),受注年月日,111) as 受注年月日
            											FROM 受注
            												WHERE 削除='N'
            												  AND 発注指示区分 = '0'
           													  AND 本社出庫数 <> 0
            												  AND 本社出庫数>岐阜出庫数
            												  AND (本社出庫数+岐阜出庫数)=受注数量
															  AND dbo.f_get倉庫間移動有無(受注番号)='0'
															  AND 売上済数量<受注数量
            												  AND 受注年月日>='{0}'
            												  AND 受注年月日<='{1}'
            												GROUP BY 商品コード, convert(char(7),受注年月日,111)
		    										union
		    										SELECT 商品コード, null as 数１, null as 数２, SUM(受注数量 - 売上済数量) AS 数３, convert(char(7),受注年月日,111) as 受注年月日
            											FROM 受注
            												WHERE 削除='N'
            												  AND 発注指示区分 = '0'
            												  AND 岐阜出庫数 <> 0
            												  AND 本社出庫数<岐阜出庫数
            												  AND (本社出庫数+岐阜出庫数)=受注数量
															  AND dbo.f_get倉庫間移動有無(受注番号)='1'
															  AND 売上済数量<受注数量
            												  AND 受注年月日>='{0}'
            												  AND 受注年月日<='{1}'
            												GROUP BY 商品コード, convert(char(7),受注年月日,111)
		    										) 取り出し
											)結果A
									union
									SELECT	H.商品コード as 商品コード,convert(char(7),H.発注年月日,111) as 年月日, null as 受注残数A, SUM(H.発注数量) as 受注残数B
										FROM	受注 J,発注 H	
											WHERE J.削除 = 'N'
											  AND H.削除 = 'N'
											  AND J.受注番号 = H.受注番号
											  AND J.商品コード <> H.商品コード		
											  AND H.加工区分='0'		--2006.10.6
											  AND J.売上済数量 < J.受注数量	--2015.6.30
											  AND J.受注年月日>='{0}'
    										  AND J.受注年月日<='{1}'
											  AND H.発注年月日>='{0}'
    										  AND H.発注年月日<='{1}'
											  GROUP BY H.商品コード, convert(char(7),H.発注年月日,111)
									) 結果B
									GROUP BY 商品コード, 年月日
							 ) as a
               ) as 集計前
         where 年月日 is not null
         group by 商品コード, 年月日
       ) 集計後
WHERE 売上数量 != ''
   OR 出庫数量 != ''
   OR 入庫数量 != ''
   OR 仕入数量 != ''
   OR 発注残 != ''
   OR 受注残 != ''
 order by 商品コード, convert(char(7),年月,111)
