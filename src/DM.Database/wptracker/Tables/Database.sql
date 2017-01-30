CREATE TABLE [wptracker].[Database] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Version]     NVARCHAR (50)  NOT NULL,
    [Changes]     NVARCHAR (MAX) NOT NULL,
    [Publish]     BIT            CONSTRAINT [ColumnDefault_d6aced94-8b59-4a32-8751-42a695aebdb7] DEFAULT ((0)) NULL,
    [Type]        NVARCHAR (50)  NULL,
    [PublishDate] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

