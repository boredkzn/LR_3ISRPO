USE [RESTOURAN]
GO
/****** Object:  Table [dbo].[MainTable]    Script Date: 15.04.2022 22:18:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_reservation] [datetime] NULL,
	[number_table] [nvarchar](max) NULL,
	[FIO_Clients] [nvarchar](max) NULL,
	[phone_clients] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MainTable] ON 
GO
INSERT [dbo].[MainTable] ([id], [date_reservation], [number_table], [FIO_Clients], [phone_clients]) VALUES (2, CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'234', N'Zaripov Shamil Damirovich', N'89196217131')
GO
INSERT [dbo].[MainTable] ([id], [date_reservation], [number_table], [FIO_Clients], [phone_clients]) VALUES (3, CAST(N'2023-02-10T00:00:00.000' AS DateTime), N'111', N'Latypov Damir Ildarovich', N'89872367625')
GO
INSERT [dbo].[MainTable] ([id], [date_reservation], [number_table], [FIO_Clients], [phone_clients]) VALUES (5, CAST(N'2022-04-06T21:20:00.000' AS DateTime), N'22', N'aaaa', N'2233232')
GO
INSERT [dbo].[MainTable] ([id], [date_reservation], [number_table], [FIO_Clients], [phone_clients]) VALUES (16, CAST(N'2022-04-06T22:01:00.000' AS DateTime), N'12', N'sdfsdf', N'2233232')
GO
INSERT [dbo].[MainTable] ([id], [date_reservation], [number_table], [FIO_Clients], [phone_clients]) VALUES (17, CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'1321', N'awdawd', N'234234234')
GO
INSERT [dbo].[MainTable] ([id], [date_reservation], [number_table], [FIO_Clients], [phone_clients]) VALUES (18, CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'ssef', N'sefsef', N'sefsef')
GO
SET IDENTITY_INSERT [dbo].[MainTable] OFF
GO
