CREATE TABLE [wptracker].[SuggestedChanges] (
    [id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserID]    BIGINT         NULL,
    [Field]     NVARCHAR (MAX) NULL,
    [OldValue]  NVARCHAR (MAX) NULL,
    [NewValue]  NVARCHAR (MAX) NULL,
    [Notes]     NVARCHAR (MAX) NULL,
    [DBVersion] NVARCHAR (30)  NULL,
    [Status]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_SuggestedChanges_0] FOREIGN KEY ([UserID]) REFERENCES [wptracker].[Users] ([ID])
);

