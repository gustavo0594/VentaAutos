
SELECT st.name,
       sep.value Description
FROM sys.tables st     
LEFT JOIN sys.extended_properties sep ON 
	st.object_id = sep.major_id  AND sep.name = 'MS_Description'
   