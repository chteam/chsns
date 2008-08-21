namespace CHSNS.Controllers.Admin
{
	
	using System;
	public class SqlController : BaseAdminController
	{
		public void Execute(string sql) {
			if (IsPost) {
				if (string.IsNullOrEmpty(sql)) {
					ViewData["msg"] = "请输入SQL语句";
					return;
				}
				try {
				//	IDataBaseExecutor idb = new DataBaseExecutor();
					this.DataBaseExecutor.Execute(sql);
				} catch (Exception e) {
					ViewData["msg"] = e.Message;
					return;
				}
				ViewData["msg"] = "执行成功";
			}
		}
//        public void ClearLog() {
//            commandText = (
//                (
//                (
//                (
//                (
//                (((((((((((((((((((
//                commandText +
//"SET NOCOUNT ON " +
//"DECLARE @LogicalFileName sysname, @MaxMinutes INT, @NewSize INT ") +
//"USE [" + dbname + "] -- 要操作的数据库名 ") +
//"SELECT @LogicalFileName = '" + dbname + "_log', -- 日志文件名 ") +
//"@MaxMinutes = 10, -- Limit on time allowed to wrap log. " +
//"@NewSize = 1 -- 你想设定的日志文件的大小(M) ") +
//"-- Setup / initialize " + "DECLARE @OriginalSize int ") +
//"SELECT @OriginalSize = " + shrinksize) + "FROM sysfiles ") +
//"WHERE name = @LogicalFileName " +
//"SELECT 'Original Size of ' + db_name() + ' LOG is ' + ") +
//"CONVERT(VARCHAR(30),@OriginalSize) + ' 8K pages or ' + " +
//"CONVERT(VARCHAR(30),(@OriginalSize*8/1024)) + 'MB' ") +
//"FROM sysfiles " + "WHERE name = @LogicalFileName ") +
//"CREATE TABLE DummyTrans " +
//"(DummyColumn char (8000) not null) ") +
//"DECLARE @Counter INT, " +
//"@StartTime DATETIME, ") +
//"@TruncLog VARCHAR(255) " +
//"SELECT @StartTime = GETDATE(), ") +
//"@TruncLog = 'BACKUP LOG ' + db_name() + ' WITH TRUNCATE_ONLY' " +
//"DBCC SHRINKFILE (@LogicalFileName, @NewSize) ") + 
//"EXEC (@TruncLog) " +
//"-- Wrap the log if necessary. ") + 
//"WHILE @MaxMinutes > DATEDIFF (mi, @StartTime, GETDATE()) -- time has not expired " +
//"AND @OriginalSize = (SELECT size FROM sysfiles WHERE name = @LogicalFileName) ") +
//"AND (@OriginalSize * 8 /1024) > @NewSize " + "BEGIN -- Outer loop. ") +
//"SELECT @Counter = 0 " +
//"WHILE ((@Counter < @OriginalSize / 16) AND (@Counter < 50000)) ") +
//"BEGIN -- update " + "INSERT DummyTrans VALUES ('Fill Log') ") +
//"DELETE DummyTrans " + "SELECT @Counter = @Counter + 1 ") +
//"END " + "EXEC (@TruncLog) ") + "END " +
//"SELECT 'Final Size of ' + db_name() + ' LOG is ' + ") +
//"CONVERT(VARCHAR(30),size) + ' 8K pages or ' +" +
//"CONVERT(VARCHAR(30),(size*8/1024)) + 'MB' ") +
//"FROM sysfiles " + "WHERE name = @LogicalFileName ") +
//"DROP TABLE DummyTrans " +
//"SET NOCOUNT OFF ";

//        }
	}
}
