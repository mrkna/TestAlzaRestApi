USE[TestAlzaRestApiDatabase];
GO

/****** Object:  Table [dbo].[Product]    Script Date: 29.11.2020 11:14:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Product](

[Id][int] NOT NULL,

[Name] [varchar](max)NOT NULL,
	[ImgUrl] [varchar](max)NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Description] [varchar](max)NULL
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO

SET ANSI_PADDING OFF
GO;