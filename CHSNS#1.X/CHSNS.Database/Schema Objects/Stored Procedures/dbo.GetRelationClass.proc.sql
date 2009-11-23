-- =============================================
-- Author:		邹健
-- Create date: 20070726
-- Description:	获得相关班级
-- =============================================
CREATE PROCEDURE [dbo].[GetRelationClass]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @GRADE INT , @UNIVERSITY NVARCHAR(50),@XUEYUAN NVARCHAR(50)
SELECT @GRADE=GRADE,@UNIVERSITY =UNIVERSITY ,@XUEYUAN=XUEYUAN from SchoolInformation
where userid=@userid


SELECT     GroupName, summmary, [group].id,@GRADE as grade ,xueyuan.xueyuan as xueyuan,[group].istrue,[groupuser].[level]
FROM         [Group]
left JOIN groupuser ON  GroupUser.Groupid=[Group].id and groupuser.userid=@userid
inner join xueyuan on xueyuan.id=@XueYuan

WHERE     (Other0 = @University) AND (Num0 = @Grade) AND (Other1 = @XueYuan) 


END


