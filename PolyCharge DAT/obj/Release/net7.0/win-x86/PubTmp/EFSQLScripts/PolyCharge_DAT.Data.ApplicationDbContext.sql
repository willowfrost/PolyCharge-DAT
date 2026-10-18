IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323001852_AddRunsAndTestsToDB')
BEGIN
    CREATE TABLE [Runs] (
        [Id] int NOT NULL IDENTITY,
        [Run_Number] nvarchar(max) NOT NULL,
        [Customer_Product] nvarchar(max) NOT NULL,
        [Project_Number] nvarchar(max) NULL,
        [Date_Run] nvarchar(max) NULL,
        [Pre_Run_Notes] nvarchar(max) NULL,
        [Oiler_Offset] real NULL,
        [Evap_Tank_Temp] int NULL,
        [Evap_Nozzel_Temp] int NULL,
        [Slit_Gap] nvarchar(max) NULL,
        [Target_Thickness] int NULL,
        [Mono_Flow_Rate] int NULL,
        [Mono_Pump] nvarchar(max) NULL,
        [Wire_Inner_Speed] int NULL,
        [Wire_Outer_Boat] nvarchar(max) NULL,
        [Wire_2nd_Outer_Boat] nvarchar(max) NULL,
        [Target_OD] real NULL,
        [E_Gun_KV] int NULL,
        [E_Gun_mA] int NULL,
        [E_Gun_Ar_Flow] int NULL,
        [Magnetron_Supply] nvarchar(max) NULL,
        [Magnetron_Power] nvarchar(max) NULL,
        [Magnetron_Ar_Gas_Flow] int NULL,
        [Magnetron_O2_Gas_Flow] int NULL,
        [Shadow_Mask] nvarchar(max) NULL,
        [Shadow_Mask_Start_Position] real NULL,
        [Shadow_Mask_Movement] int NULL,
        [Oiler_Faceplates] nvarchar(max) NULL,
        [Oiler_Temperature] int NULL,
        [Oiler_Gas_Flow] int NULL,
        [Oiler_Start_Position] int NULL,
        [Oiler_Shift] real NULL,
        [Oiler_Step_back] int NULL,
        [Drum_Temp] int NULL,
        [Web_Speed] int NULL,
        [Film] nvarchar(max) NULL,
        [Release] nvarchar(max) NULL,
        [Bottom_Mono_Only_Layers] int NULL,
        [Bottom_Inactive_Layers] int NULL,
        [Active_Layers] int NULL,
        [Top_Inactive_Layers] int NULL,
        [Top_Mono_Only_Layers] int NULL,
        [Total_layers] int NULL,
        CONSTRAINT [PK_Runs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323001852_AddRunsAndTestsToDB')
BEGIN
    CREATE TABLE [Tests] (
        [Id] int NOT NULL IDENTITY,
        [Run_Number] nvarchar(max) NOT NULL,
        [Card] int NOT NULL,
        [Lane] int NOT NULL,
        [Note_A] nvarchar(max) NOT NULL,
        [Note_B] nvarchar(max) NULL,
        [Date_Time] nvarchar(max) NOT NULL,
        [Series] int NOT NULL,
        [Part_Size] int NOT NULL,
        [Cap_120Hz_uF] real NOT NULL,
        [Cap_1kHz_uF] real NOT NULL,
        [DF_1kHz] real NOT NULL,
        [ESR1_10kHZ_mOhm] real NOT NULL,
        [ESR2_20kHZ_mOhm] real NOT NULL,
        [ESR3_100kHz_mOhm] real NOT NULL,
        CONSTRAINT [PK_Tests] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230323001852_AddRunsAndTestsToDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230323001852_AddRunsAndTestsToDB', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230417031444_AddIssuesToDB')
BEGIN
    CREATE TABLE [Issues] (
        [Id] int NOT NULL IDENTITY,
        [Issue_CreatedBy] nvarchar(max) NOT NULL,
        [Issue_Description] nvarchar(max) NOT NULL,
        [Issue_CreatedOn] datetime2 NOT NULL,
        [Issue_ClosedBy] nvarchar(max) NULL,
        [Issue_Resolution] nvarchar(max) NULL,
        [Issue_ClosedOn] datetime2 NULL,
        [Issue_Status] int NOT NULL,
        CONSTRAINT [PK_Issues] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230417031444_AddIssuesToDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230417031444_AddIssuesToDB', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230502190602_DropTestsTable')
BEGIN
    DROP TABLE [Tests];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230502190602_DropTestsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230502190602_DropTestsTable', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230502202248_AddBridgeTestsToDB')
BEGIN
    CREATE TABLE [POBITests] (
        [Id] int NOT NULL IDENTITY,
        [Run_Number] nvarchar(max) NOT NULL,
        [Card] int NOT NULL,
        [Lane] int NOT NULL,
        [Note_A] nvarchar(max) NOT NULL,
        [Note_B] nvarchar(max) NULL,
        [Date_Time] nvarchar(max) NOT NULL,
        [Series] int NOT NULL,
        [Part_Size] int NOT NULL,
        [Cap_120Hz_uF] real NOT NULL,
        [Cap_1kHz_uF] real NOT NULL,
        [DF_1kHz] real NOT NULL,
        [ESR1_10kHZ_mOhm] real NOT NULL,
        [ESR2_20kHZ_mOhm] real NOT NULL,
        [ESR3_100kHz_mOhm] real NOT NULL,
        CONSTRAINT [PK_POBITests] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230502202248_AddBridgeTestsToDB')
BEGIN
    CREATE TABLE [PODCTests] (
        [Id] int NOT NULL IDENTITY,
        [Run_Number] nvarchar(max) NOT NULL,
        [Card] int NOT NULL,
        [Lane] int NOT NULL,
        [Note_A] nvarchar(max) NOT NULL,
        [Note_B] nvarchar(max) NULL,
        [Date_Time] nvarchar(max) NOT NULL,
        [Series] int NOT NULL,
        [Part_Size] int NOT NULL,
        [Cap_120Hz_uF] real NOT NULL,
        [Cap_1kHz_uF] real NOT NULL,
        [DF_1kHz] real NOT NULL,
        [ESR1_10kHZ_mOhm] real NOT NULL,
        [ESR2_20kHZ_mOhm] real NOT NULL,
        [ESR3_100kHz_mOhm] real NOT NULL,
        CONSTRAINT [PK_PODCTests] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230502202248_AddBridgeTestsToDB')
BEGIN
    CREATE TABLE [PRDCTests] (
        [Id] int NOT NULL IDENTITY,
        [Run_Number] nvarchar(max) NOT NULL,
        [Card] int NOT NULL,
        [Lane] int NOT NULL,
        [Note_A] nvarchar(max) NOT NULL,
        [Note_B] nvarchar(max) NULL,
        [Date_Time] nvarchar(max) NOT NULL,
        [Series] int NOT NULL,
        [Part_Size] int NOT NULL,
        [Cap_120Hz_uF] real NOT NULL,
        [Cap_1kHz_uF] real NOT NULL,
        [DF_1kHz] real NOT NULL,
        [ESR1_10kHZ_mOhm] real NOT NULL,
        [ESR2_20kHZ_mOhm] real NOT NULL,
        [ESR3_100kHz_mOhm] real NOT NULL,
        CONSTRAINT [PK_PRDCTests] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230502202248_AddBridgeTestsToDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230502202248_AddBridgeTestsToDB', N'7.0.5');
END;
GO

COMMIT;
GO

