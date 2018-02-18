USE [DevMtsDb]
GO
SET IDENTITY_INSERT [dbo].[ApplicationFeature] ON 

INSERT [dbo].[ApplicationFeature] ([Id], [CreatedDate], [IsPanel], [IsParent], [Name], [ParentId], [UpdatedDate], [RouteAddress]) VALUES (1, CAST(0x07804694FA13DC3D0B AS DateTime2), 0, 0, N'Dashboard', 0, CAST(0x07B0BB94FA13DC3D0B AS DateTime2), N'dashboard')
INSERT [dbo].[ApplicationFeature] ([Id], [CreatedDate], [IsPanel], [IsParent], [Name], [ParentId], [UpdatedDate], [RouteAddress]) VALUES (2, CAST(0x07504296FA13DC3D0B AS DateTime2), 0, 0, N'User Management', 0, CAST(0x07504296FA13DC3D0B AS DateTime2), N'usermanagement')
INSERT [dbo].[ApplicationFeature] ([Id], [CreatedDate], [IsPanel], [IsParent], [Name], [ParentId], [UpdatedDate], [RouteAddress]) VALUES (3, CAST(0x07504296FA13DC3D0B AS DateTime2), 0, 0, N'Inventory Management', 0, CAST(0x07504296FA13DC3D0B AS DateTime2), N'inventory')
SET IDENTITY_INSERT [dbo].[ApplicationFeature] OFF
