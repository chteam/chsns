create   proc [dbo].[spGenInsertSQL] (@tablename varchar(256))  
as
begin
declare @SQL varchar(8000)
declare @SQLValues varchar(8000)
set @SQL =' ('
set @SQLValues = 'values (''+'
select @SQLValues = @SQLValues + cols + ' + '','' + ' ,@SQL = @SQL + '[' + name + '],'  
from  
      (select case  
                when xtype in (48,52,56,59,60,62,104,106,108,122,127)                                 
                     then 'case when '+ name +' is null then ''NULL'' else ' + 'cast('+ name + ' as varchar)'+' end'
                when xtype in (58,61)
                     then 'case when '+ name +' is null then ''NULL'' else '+''''''''' + ' + 'cast('+ name +' as varchar)'+ '+'''''''''+' end'
               when xtype in (167)
                     then 'case when '+ name +' is null then ''NULL'' else '+''''''''' + ' + 'replace('+ name+','''''''','''''''''''')' + '+'''''''''+' end'
                when xtype in (231)
                     then 'case when '+ name +' is null then ''NULL'' else '+'''N'''''' + ' + 'replace('+ name+','''''''','''''''''''')' + '+'''''''''+' end'
                when xtype in (175)
                     then 'case when '+ name +' is null then ''NULL'' else '+''''''''' + ' + 'cast(replace('+ name+','''''''','''''''''''') as Char(' + cast(length as varchar) + '))+'''''''''+' end'
                when xtype in (239)
                     then 'case when '+ name +' is null then ''NULL'' else '+'''N'''''' + ' + 'cast(replace('+ name+','''''''','''''''''''') as Char(' + cast(length as varchar) + '))+'''''''''+' end'
                else '''NULL'''   
              end as Cols,name
         from syscolumns   
        where id = object_id(@tablename)  
      ) T  
set @SQL ='select ''INSERT INTO ['+ @tablename + ']' + left(@SQL,len(@SQL)-1)+') ' + left(@SQLValues,len(@SQLValues)-4) + ')'' from '+@tablename
print @SQL exec (@SQL)
end


