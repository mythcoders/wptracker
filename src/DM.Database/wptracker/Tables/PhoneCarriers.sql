CREATE TABLE [wptracker].[PhoneCarriers] (
    [ID]        BIGINT IDENTITY (1, 1) NOT NULL,
    [PhoneID]   BIGINT NULL,
    [CarrierID] BIGINT NULL,
    CONSTRAINT [PK_PhoneCarriers] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PhoneCarriers_ToCarriers] FOREIGN KEY ([CarrierID]) REFERENCES [wptracker].[Carriers] ([id]),
    CONSTRAINT [FK_PhoneCarriers_ToPhones] FOREIGN KEY ([PhoneID]) REFERENCES [wptracker].[Phones] ([id])
);

