CREATE PROCEDURE deleteUser
	@email nvarchar(50),
	@businessName nvarchar(50)
AS
BEGIN
declare @userid int = (select id from [user] where email = @email);
declare @businessid int = (select id from business where Name = @businessName);
declare @roleid int = (select roleid from userrole where UserId = @userid);

delete from UserBusiness
where UserId = @userid and BusinessId = @businessid

delete from userrole
where userid = @userid and RoleId = @roleid

delete from RoleApplicationFeature
where roleid = @roleid

delete from [user]
where id = @userid

delete from Business
where id = @businessid

delete from role
where id = @roleid

END
GO



