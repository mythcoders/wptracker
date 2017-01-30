CREATE TABLE [wptracker].[PhonePhotos] (
    [ID]      BIGINT IDENTITY (1, 1) NOT NULL,
    [PhoneID] BIGINT NULL,
    [PhotoID] BIGINT NULL,
    CONSTRAINT [PK_PhonePhotos] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PhonePhotos_ToPhones] FOREIGN KEY ([PhoneID]) REFERENCES [wptracker].[Phones] ([id]),
    CONSTRAINT [FK_PhonePhotos_ToPhotos] FOREIGN KEY ([PhotoID]) REFERENCES [wptracker].[Photos] ([ID])
);

