 --  CREATE DATABASE OnlineGaadi
/*
USE [OnlineGaadi]
GO
/****** Object:  Table [dbo].[tbl_DriverRegistration]    Script Date: 14-04-2021 10:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DriverRegistration](
	[DriverUNID] [varchar](36) NOT NULL,
	[DriverName] [varchar](150) NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
	[VehicleNumber] [varchar](15) NOT NULL,
	[PickupLocation] [varchar](250) NOT NULL,
	[AadharCardID] [varchar](36) NULL,
	[LicenseID] [varchar](36) NULL,
	[DriverPhotoID] [varchar](36) NULL,
	[_CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_DriverRegistration] PRIMARY KEY CLUSTERED 
(
	[DriverUNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_tbl_DriverRegistration] UNIQUE NONCLUSTERED 
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Login]    Script Date: 14-04-2021 10:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Login](
	[LoginUNID] [varchar](36) NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
	[UserType] [varchar](25) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[IsActive] [int] NOT NULL,
	[OTP] [varchar](4) NOT NULL,
	[_CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Login] PRIMARY KEY CLUSTERED 
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_tbl_Login] UNIQUE NONCLUSTERED 
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_DriverRegistration] ADD  CONSTRAINT [DF_tbl_DriverRegistration_DriverUNID]  DEFAULT (newid()) FOR [DriverUNID]
GO
ALTER TABLE [dbo].[tbl_DriverRegistration] ADD  CONSTRAINT [DF_Table_1_CreatedOn]  DEFAULT (getdate()) FOR [_CreatedOn]
GO
ALTER TABLE [dbo].[tbl_Login] ADD  CONSTRAINT [DF_tbl_Login_LoginUNID]  DEFAULT (newid()) FOR [LoginUNID]
GO
ALTER TABLE [dbo].[tbl_Login] ADD  CONSTRAINT [DF_tbl_Login_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Login] ADD  CONSTRAINT [DF_tbl_Login__CreatedOn]  DEFAULT (getdate()) FOR [_CreatedOn]
GO
/****** Object:  StoredProcedure [dbo].[spr_FindDriverByLocation]    Script Date: 14-04-2021 10:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Suraj
-- Create date: 14 April
-- Description:	<Description,,>
-- EXEC spr_FindDriverByLocation 'mum'
-- =============================================
CREATE PROCEDURE [dbo].[spr_FindDriverByLocation] 
	-- Add the parameters for the stored procedure here
	@DriverLocation VARCHAR(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@DriverLocation = 'All')
	BEGIN
		SELECT DriverName, MobileNumber, VehicleNumber, PickupLocation
		FROM [dbo].[tbl_DriverRegistration]
	END
	ELSE
	BEGIN
		SELECT DriverName, MobileNumber, VehicleNumber, PickupLocation
		FROM [dbo].[tbl_DriverRegistration]
		WHERE PickupLocation LIKE '%'+@DriverLocation+'%'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spr_RegistrationDriver]    Script Date: 14-04-2021 10:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Suraj Mishra>
-- Create date: 14 April 2021
-- Description:	<Description,,>
-- EXEC [dbo].[spr_RegistrationDriver]  'Umesh Mishra','8286779494','MH04 A4334','Mumbai','12345'
-- =============================================
CREATE PROCEDURE [dbo].[spr_RegistrationDriver] 
	-- Add the parameters for the stored procedure here
	@DriverName VARCHAR(150),
	@MobileNumber VARCHAR(15),
	@VehicleNumber VARCHAR(15),
	@PickupLocation VARCHAR(250),
	@Password VARCHAR(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
		-- Insert statements for procedure here
		
		INSERT INTO [dbo].[tbl_DriverRegistration]
		(DriverName, MobileNumber, VehicleNumber, PickupLocation)
		VALUES(@DriverName, @MobileNumber, @VehicleNumber, @PickupLocation)

		DECLARE @OTP VARCHAR(10)

		SELECT @OTP = SUBSTRING(CONVERT(varchar(40), NEWID()),0,5)

		INSERT INTO [dbo].[tbl_Login]
		(MobileNumber, UserType, Password, OTP)
		VALUES(@MobileNumber, 'Driver', @Password, @OTP)

	END TRY
	BEGIN CATCH

	END CATCH
END
GO


*/