CREATE TABLE [wptracker].[OSVersions] (
    [id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Version]   NVARCHAR (50)  NOT NULL,
    [Codename]  NVARCHAR (50)  NULL,
    [Changes]   NVARCHAR (MAX) NULL,
    [Notes]     NVARCHAR (MAX) NULL,
    [Publish]   BIT            NOT NULL,
    [Date]      NVARCHAR (50)  NULL,
    [SortOrder] INT            NULL,
    [Branch]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

