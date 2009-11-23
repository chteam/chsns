-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2007 9 1 le 10 20 
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MySchoolSelect]
@userid bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
U.School as University, SchoolInformation.University as University_id,
SchoolInformation.Xueyuan as Xueyuan_id,X.Xueyuan,
Grade,
SchoolInformation.Qinshi as Qinshi_id,Q.Qinshi,
H.School as Highschool,
J.School as Juniorschool,
SchoolInfoShowLevel
	from SchoolInformation
	INNER JOIN [PROFILE] ON [PROFILE].USERID=SchoolInformation.USERID
	left join School as U on U.id=SchoolInformation.University
	left join Xueyuan as X on X.id=SchoolInformation.Xueyuan
	left join Qinshi as Q on q.id=SchoolInformation.Qinshi
	left join School as H on H.id=SchoolInformation.Highschool
	left join School as J on J.id=SchoolInformation.Juniorschool
	where SchoolInformation.userid=@userid
END


