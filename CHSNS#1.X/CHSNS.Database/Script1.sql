-- =============================================
-- Script Template
-- =============================================
begin transaction   --     开始事务
declare @e int
set @e=0;
INSERT INTO [Account]
([UserName],[Password],[Code])
VALUES
('admin',upper('21232f297a57a5a743894a0e4a801fc3'),123456);
set @e = @@error+@e
declare @id bigint;
set @id=@@identity;
INSERT INTO [Profile] ([UserId],[Name],showlevel,[status])VALUES(@id,'Admin',0,255);
set @e = @@error+@e
INSERT INTO[BasicInformation] ([UserId],[Name],ShowLevel)VALUES(@id ,'Admin',0);
set @e = @@error+@e

if @e = 0
    commit
else
 begin   
    rollback
    print 'error!!!'  --现在这种情况执行不到这里
                         --如果我想在这里做一些log 之类的操作，怎么办？

  end