USE [eProcurement]
GO
/****** Object:  Table [dbo].[ATTACHMENT]    Script Date: 01/03/2010 11:20:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ATTACHMENT]') AND type in (N'U'))
DROP TABLE [dbo].[ATTACHMENT]


/****** Object:  Table [dbo].[ATTACHMENT]    Script Date: 01/03/2010 11:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ATTACHMENT](
	[ATTCHMTID] [uniqueidentifier] NOT NULL,
	[FILENAME] [varchar](50)  NOT NULL,
	[FILEDESC] [varchar](200)  NULL,
	[FILESIZE] [bigint] NOT NULL,
	[FILEDATA] [varbinary](max) NOT NULL,
	[ATTCHDATE] [bigint] NOT NULL,
	[STOREPATH] [varchar](200)  NOT NULL,
	[PROFTYP] [varchar](10)  NOT NULL,
	[CREATEBY] [varchar](10)  NOT NULL,
	[EBELN] [char](21)  NULL,
	[DELIND] [char](1)  NOT NULL,
 CONSTRAINT [PK_ATTCHMT] PRIMARY KEY CLUSTERED 
(
	[ATTCHMTID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF