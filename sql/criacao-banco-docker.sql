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

CREATE TABLE [Marcas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Cancelado] SMALLINT NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Proprietarios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Email] varchar(254) NULL,
    [NumeroDocumento] varchar(14) NULL,
    [TipoDocumento] SMALLINT NULL,
    [Cancelado] SMALLINT NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    CONSTRAINT [PK_Proprietarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ProprietarioEnderecos] (
    [Id] uniqueidentifier NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Complemento] varchar(250) NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cep] varchar(20) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [ProprietarioId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ProprietarioEnderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProprietarioEnderecos_Proprietarios_ProprietarioId] FOREIGN KEY ([ProprietarioId]) REFERENCES [Proprietarios] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Veiculos] (
    [Id] uniqueidentifier NOT NULL,
    [ProprietarioId] uniqueidentifier NOT NULL,
    [MarcaId] uniqueidentifier NOT NULL,
    [Renavam] varchar(50) NOT NULL,
    [Quilometragem] DECIMAL(18,2) NOT NULL,
    [Valor] DECIMAL(18,2) NOT NULL,
    [Status] SMALLINT NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    CONSTRAINT [PK_Veiculos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Veiculos_Marcas_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marcas] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Veiculos_Proprietarios_ProprietarioId] FOREIGN KEY ([ProprietarioId]) REFERENCES [Proprietarios] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Modelos] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(50) NOT NULL,
    [AnoFabricacao] varchar(50) NOT NULL,
    [AnoModelo] varchar(50) NOT NULL,
    [VeiculoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Modelos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Modelos_Veiculos_VeiculoId] FOREIGN KEY ([VeiculoId]) REFERENCES [Veiculos] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_Modelos_VeiculoId] ON [Modelos] ([VeiculoId]);
GO

CREATE UNIQUE INDEX [IX_ProprietarioEnderecos_ProprietarioId] ON [ProprietarioEnderecos] ([ProprietarioId]);
GO

CREATE UNIQUE INDEX [IX_Veiculos_MarcaId] ON [Veiculos] ([MarcaId]);
GO

CREATE UNIQUE INDEX [IX_Veiculos_ProprietarioId] ON [Veiculos] ([ProprietarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220330121416_Initial', N'5.0.15');
GO

COMMIT;
GO

