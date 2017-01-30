CREATE TABLE [wptracker].[Carriers] (
    [id]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [CountryID] BIGINT        NULL,
    [Publish]   BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Carriers_ToRegions] FOREIGN KEY ([CountryID]) REFERENCES [wptracker].[Regions] ([ID])
);

