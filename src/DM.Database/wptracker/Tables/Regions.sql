CREATE TABLE [wptracker].[Regions] (
    [ID]      BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (50) NULL,
    [Publish] BIT          NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([ID] ASC)
);

