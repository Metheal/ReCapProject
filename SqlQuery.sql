CREATE TABLE [dbo].[Brands] (
    [BrandID]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([BrandID] ASC)
);

CREATE TABLE [dbo].[CarImages] (
    [CarImageID] INT            IDENTITY (1, 1) NOT NULL,
    [CarID]      INT            NULL,
    [ImagePath]  NVARCHAR (MAX) NULL,
    [Date]       DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([CarImageID] ASC),
    FOREIGN KEY ([CarID]) REFERENCES [dbo].[Cars] ([CarID])
);

CREATE TABLE [dbo].[Cars] (
    [CarID]       INT            IDENTITY (1, 1) NOT NULL,
    [BrandID]     INT            NULL,
    [ColorID]     INT            NULL,
    [CarName]     NVARCHAR (50)  NULL,
    [ModelYear]   SMALLINT       NULL,
    [DailyPrice]  DECIMAL (18)   NULL,
    [Description] NVARCHAR (MAX) NULL,
    [FindexScore] INT            NULL,
    PRIMARY KEY CLUSTERED ([CarID] ASC),
    FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([ColorID]),
    FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([BrandID])
);

CREATE TABLE [dbo].[CreditCards] (
    [CreditCardID]     INT           IDENTITY (1, 1) NOT NULL,
    [CardHolderName]   VARCHAR (MAX) NOT NULL,
    [CreditCardNumber] VARCHAR (16)  NOT NULL,
    [ExpirationMonth]  INT           NOT NULL,
    [ExpirationYear]   INT           NOT NULL,
    [CreditCardCVV]    INT           NOT NULL,
    [CustomerID]       INT           NULL,
    PRIMARY KEY CLUSTERED ([CreditCardID] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorID]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([ColorID] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Payments] (
    [PaymentID]   INT          IDENTITY (1, 1) NOT NULL,
    [RentalID]    INT          NOT NULL,
    [TotalAmount] DECIMAL (18) NOT NULL,
    [PaidAmount]  DECIMAL (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentID] ASC)
);

CREATE TABLE [dbo].[Rentals] (
    [RentalID]   INT      IDENTITY (1, 1) NOT NULL,
    [CarID]      INT      NULL,
    [CustomerID] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalID] ASC),
    FOREIGN KEY ([CarID]) REFERENCES [dbo].[Cars] ([CarID]),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID])
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [ID]               INT IDENTITY (1, 1) NOT NULL,
    [UserID]           INT NOT NULL,
    [OperationClaimID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Users] (
    [UserID]       INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)    NOT NULL,
    [LastName]     VARCHAR (50)    NOT NULL,
    [EMail]        VARCHAR (50)    NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [CustomerID]  INT           IDENTITY (1, 1) NOT NULL,
    [UserID]      INT           NULL,
    [CompanyName] NVARCHAR (50) NULL,
    [FindexScore] INT           NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);
