﻿/*
-- 后期部署脚本模板							
----------------------------------------------------------------------------------------
-- 此文件包含将追加到生成脚本的 SQL 语句		
-- 使用 SQLCMD 语法将文件包含到后期部署脚本中			
-- 示例:      :r .\filename.sql								
-- 使用 SQLCMD 语法引用后期部署脚本中的变量		
-- 示例:      :setvar $TableName MyTable							
--               SELECT * FROM [$(TableName)]					
----------------------------------------------------------------------------------------
*/
:r .\Permissions.sql

:r .\RoleMemberships.sql

:r .\RulesAndDefaults.sql

:r .\DatabaseObjectOptions.sql

:r .\Signatures.sql
