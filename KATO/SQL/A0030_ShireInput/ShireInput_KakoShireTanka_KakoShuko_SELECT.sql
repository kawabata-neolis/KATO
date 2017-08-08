SELECT SUM(b.単価*b.数量) FROM 出庫ヘッダ a,出庫明細 b
WHERE a.削除='N' AND b.削除='N'
AND a.伝票番号= b.伝票番号
AND b.受注番号='{0}'
AND (a.取引区分='41' OR  a.取引区分='43')