CREATE TABLE [dbo].[PatientDetail] (
    [PatientId]       INT            IDENTITY (1, 1) NOT NULL,
    [CreatedOn]       DATETIME       CONSTRAINT [DF_PatientDetail_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       NVARCHAR (50)  CONSTRAINT [DF_PatientDetail_CreatedBy] DEFAULT ('System') NOT NULL,
    [ModifiedOn]      DATETIME       NULL,
    [ModifiedBy]      NVARCHAR (50)  NULL,
    [Deleted]         BIT            CONSTRAINT [DF_PatientDetail_Deleted] DEFAULT ((0)) NOT NULL,
    [ForeName]        NVARCHAR (50)  NOT NULL,
    [Surname]         NVARCHAR (50)  NOT NULL,
    [Gender]          BIT            CONSTRAINT [DF_PatientDetail_Gender] DEFAULT ((0)) NOT NULL,
    [DateOfBirth]     DATE           NULL,
    [TelephoneNumber] NVARCHAR (500) NULL,
    CONSTRAINT [PK_PatientDetail] PRIMARY KEY CLUSTERED ([PatientId] ASC)
);

