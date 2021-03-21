USE [hqhaidev]
GO
/****** Object:  Table [dbo].[SystemUsers]    Script Date: 3/21/2021 9:13:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUsers](
	[Id] [int] NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL
) ON [PRIMARY]
GO
