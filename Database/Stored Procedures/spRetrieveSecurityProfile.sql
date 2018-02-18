IF EXISTS ( SELECT  *
            FROM    dbo.sysobjects
            WHERE   id = OBJECT_ID(N'[dbo].[spRetrieveSecurityProfile]')
                    AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
    BEGIN
        PRINT 'DROP spRetrieveSecurityProfile';
        DROP PROCEDURE [dbo].[spRetrieveSecurityProfile];
    END;
GO

PRINT 'Creating Procedure spRetrieveSecurityProfile';
GO

/*****************************************************************************************
  Created By:	Francis Cebu
  Date:			Feb 15, 2018
  Purpose:		Retrieve the security profile of user
******************************************************************************************/

CREATE PROCEDURE [dbo].[spRetrieveSecurityProfile]
	@userid int
AS

select af.* from userrole ur
join RoleApplicationFeature ra on ur.RoleId = ra.RoleId
join applicationfeature af on ra.ApplicationFeatureId = af.Id
where ra.FullAccess = 1 and ur.UserId = 4
	
/*****************************************************************************************
	Date Modified	Modified By			Modification
  -----------------------------------------------------------------------------------------
  	[mm/dd/yyyy]	[Employee Name]
  	[Modification description goes here]
*******************************************************************************************/



