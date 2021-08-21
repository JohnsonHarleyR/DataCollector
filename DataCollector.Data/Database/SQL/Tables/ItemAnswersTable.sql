USE [DataCollector]
GO

/****** Object:  Table [dbo].[ItemAnswers]    Script Date: 8/21/2021 1:29:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemAnswers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
 CONSTRAINT [PK_ItemAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemAnswers]  WITH CHECK ADD  CONSTRAINT [FK_ItemAnswers_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO

ALTER TABLE [dbo].[ItemAnswers] CHECK CONSTRAINT [FK_ItemAnswers_Items]
GO

ALTER TABLE [dbo].[ItemAnswers]  WITH CHECK ADD  CONSTRAINT [FK_ItemAnswers_PossibleAnswers] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[PossibleAnswers] ([Id])
GO

ALTER TABLE [dbo].[ItemAnswers] CHECK CONSTRAINT [FK_ItemAnswers_PossibleAnswers]
GO

ALTER TABLE [dbo].[ItemAnswers]  WITH CHECK ADD  CONSTRAINT [FK_ItemAnswers_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
GO

ALTER TABLE [dbo].[ItemAnswers] CHECK CONSTRAINT [FK_ItemAnswers_Questions]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Answers to questions that have been provided about different questions.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ItemAnswers'
GO


