CREATE TABLE [wptracker].[Manufacturers] (
    [id]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [Publish] BIT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

