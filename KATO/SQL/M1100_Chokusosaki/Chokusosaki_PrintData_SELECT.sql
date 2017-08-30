SELECT a.得意先コード ,b.取引先名称 AS 得意先名称, a.直送先コード , a.直送先名 , a.郵便番号,a.住所１,a.住所２,a.電話番号
FROM 直送先 a, 取引先 b
WHERE a.削除 = 'N'
AND b.取引先コード = a.得意先コード
AND b.削除 = 'N'
ORDER BY a.得意先コード, a.直送先コード