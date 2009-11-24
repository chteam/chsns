CREATE PROCEDURE [dbo].[EntryAddVersion]
	@id bigint =0, 
	@title nvarchar,
	@createrId bigint,
	@status int,
	@ext ntext,
	@reason ntext,
	@description ntext,@reference ntext,
	@userId bigint,@vStatus int,
	@parentText  nvarchar(50),
	@vExt ntext
AS
      if @id is null or @id =0
	  begin
	  		if exists(select 1 from Entry where Title=@title)
			begin
				select 0;--return false
				return 0;
			end
	        INSERT INTO [Entry]([Title] ,[CreaterId] ,[UpdateTime],[EditCount],[ViewCount] ,[Status],[Ext])     
			VALUES(@title,@createrId,GETDATE(),0,0,@status,@ext);
			select @id=@@IDENTITY;
	  end
	  else
	  begin
	  	update Entry set
		UpdateTime=GETDATE(),EditCount+=1 where Id=@id;
	  end
            
INSERT INTO [EntryVersion]
 ([Reason] ,[AddTime] ,[Description] ,[Reference] ,[UserId]
 ,[Status] ,[EntryId] ,[ParentText] ,[Ext])
     VALUES (@reason ,GETDATE() ,@description ,@reference ,@userId
 ,@vStatus ,@id ,@parentText ,@vExt);

 update Entry set CurrentId=@@IDENTITY where Id=@id;
RETURN 0