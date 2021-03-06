USE [master]
GO
/****** Object:  Database [afdemp_csharp_1]    Script Date: 15/11/2017 8:05:54 μμ ******/
CREATE DATABASE [afdemp_csharp_1]
GO
USE [afdemp_csharp_1]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 15/11/2017 8:05:54 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[amount] [money] NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 15/11/2017 8:05:54 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_users] FOREIGN KEY([id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_users]
GO
ALTER DATABASE [afdemp_csharp_1] SET  READ_WRITE 
GO
INSERT [dbo].[users] ([username], [password]) VALUES (N'admin', N'admin'), (N'user1', N'password1'),(N'user2', N'password2')
GO
INSERT [dbo].[accounts] ([user_id], [transaction_date], [amount]) VALUES (1, CAST(N'2017-11-13T19:28:47.000' AS DateTime), 100000.0000), (2, CAST(N'2017-11-13T19:29:06.000' AS DateTime), 1000.0000),(3, CAST(N'2017-11-13T19:29:15.000' AS DateTime), 1000.0000)
GO