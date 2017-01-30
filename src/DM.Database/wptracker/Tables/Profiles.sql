CREATE TABLE [wptracker].[Profiles] (
    [ID]          BIGINT       IDENTITY (1, 1) NOT NULL,
    [ProfileName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_profiles] PRIMARY KEY CLUSTERED ([ID] ASC)
);

