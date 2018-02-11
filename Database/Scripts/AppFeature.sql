USE [DevMtsDb]
GO
SET IDENTITY_INSERT [dbo].[ApplicationFeature] ON 

INSERT [dbo].[ApplicationFeature] ([Id], [IsParent], [Name], [ParentId], [IsPanel], [CreatedDate], [UpdatedDate]) VALUES (1, 0, N'Dashboard', 0, 0, CAST(0x07804694FA13DC3D0B AS DateTime2), CAST(0x07B0BB94FA13DC3D0B AS DateTime2))
INSERT [dbo].[ApplicationFeature] ([Id], [IsParent], [Name], [ParentId], [IsPanel], [CreatedDate], [UpdatedDate]) VALUES (2, 0, N'User Management', 0, 0, CAST(0x07504296FA13DC3D0B AS DateTime2), CAST(0x07504296FA13DC3D0B AS DateTime2))
INSERT [dbo].[ApplicationFeature] ([Id], [IsParent], [Name], [ParentId], [IsPanel], [CreatedDate], [UpdatedDate]) VALUES (3, 0, N'Inventory Management', 0, 0, CAST(0x07504296FA13DC3D0B AS DateTime2), CAST(0x07504296FA13DC3D0B AS DateTime2))
SET IDENTITY_INSERT [dbo].[ApplicationFeature] OFF
