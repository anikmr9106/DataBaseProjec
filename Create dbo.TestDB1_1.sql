USE [C:\USERS\ANIL\DOCUMENTS\TESTDATABASE.MDF]
GO

/****** Object: Table [dbo].[TestDB1] Script Date: 7/15/2016 9:17:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TestDB1] (
    [St]       INT          NULL,
    [ID]       INT          NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Location] VARCHAR (50) NULL
);
select * from TestDB1;
insert into TestDB1 (St,ID,Name,Location)
values(1,2,Anil,bangalore);
select top 1000 [St],[id],[name],[location] from TestDB1 
Delete from TestDB1 where id=3;
insert into TestDB1 ([SlNo],[ID],[Name],[Location])
 Values([Null],[1gv09ee001],[nbsihdhb],[fjdjnn]);


