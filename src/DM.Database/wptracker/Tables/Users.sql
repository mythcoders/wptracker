CREATE TABLE [wptracker].[Users] (
    [ID]        BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [Email]     VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (20) NOT NULL,
    [ProfileID] BIGINT       NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Users_ToProfiles] FOREIGN KEY ([ProfileID]) REFERENCES [wptracker].[Profiles] ([ID])
);

