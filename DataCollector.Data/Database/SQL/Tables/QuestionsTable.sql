USE [DataCollector]
GO

/****** Object:  Table [dbo].[Questions]    Script Date: 8/21/2021 1:26:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](100) NOT NULL,
	[DependentQuestionId] [int] NULL,
	[DependentAnswerId] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_PossibleAnswers] FOREIGN KEY([DependentAnswerId])
REFERENCES [dbo].[PossibleAnswers] ([Id])
GO

ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_PossibleAnswers]
GO

ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Questions] FOREIGN KEY([DependentQuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO

ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Questions]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Questions that will be asked about data items. Some questions are dependent on the answers to others.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questions'
GO


