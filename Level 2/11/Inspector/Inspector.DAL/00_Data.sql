INSERT INTO [dbo].[Areas] ([Name] ,[SOATO]) VALUES ('Respublika Uzbekistan', '1700')
GO
INSERT INTO [dbo].[Areas] ([Name] ,[SOATO]) VALUES ('Respublika Karakalpakstan', '1735')
GO
INSERT INTO [dbo].[Areas] ([Name] ,[SOATO]) VALUES ('Andijan viloyati', '1703')
GO
INSERT INTO [dbo].[Areas] ([Name] ,[SOATO]) VALUES ('Buhoro viloyati', '1706')
GO
INSERT INTO [dbo].[Areas] ([Name] ,[SOATO]) VALUES ('Jizzah', '1708')
GO
INSERT INTO [dbo].[Areas] ([Name] ,[SOATO]) VALUES ('Kashkadaryo viloyati', '1710')
GO


set identity_insert Organizations  ON
go
INSERT INTO Organizations (id, OKPO,SOATO,INN,Name,Type)VALUES(1, '12345678', '1700', '987654232', 'Micros Training Centre', 3)
GO
INSERT INTO Organizations (id, OKPO,SOATO,INN,Name,Type)VALUES(2, '12345670', '1700', '987654232', 'MUM', 3)
GO
set identity_insert Organizations  OFF
go