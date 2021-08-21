USE [DataCollector]
GO

/****** Object:  Table [dbo].[PossibleAnswers]    Script Date: 8/21/2021 1:17:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PossibleAnswers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PossibleAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[PossibleAnswers]
(Answer)
VALUES
('Yes'), ('No'), ('Does not apply');
