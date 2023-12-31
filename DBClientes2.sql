DROP DATABASE DBCliente3
CREATE DATABASE DBCliente3
USE DBCliente3

--CREACIÓN DE TABLA CLIENTE
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [nvarchar](50) NULL,
	[idTipoCliente] [int] NULL,
	[estCliente] [bit] NULL,
	[clienteRUC] [nvarchar](50) NULL,
	[ciudadCliente] [nvarchar](50) NULL,
	[fecRegCliente] [date] NULL
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--CREACIÓN DE TABLA CIUDAD
CREATE TABLE [dbo].[Ciudad]
(
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,	
	[desCiudad] [nvarchar](50) NULL,
	[estCiudad] [bit] NULL,
	CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--PROCEDURE INSERTCIÓN CLIENTES
CREATE PROCEDURE [dbo].[spInsertaCliente] 
(@razonSocial varchar(50),
@idTipoCliente int,
@fecRegCliente date,
@clienteRUC varchar(50),
@ciudadCliente varchar(50),
@estCliente bit

)
as
begin 

	insert into Cliente(razonSocial,idTipoCliente,fecRegCliente, clienteRUC,ciudadCliente,estCliente) values
	(@razonSocial, @idTipoCliente,@fecRegCliente, @clienteRUC,@ciudadCliente,@estCliente)
end

--PROCEDURE BUSQUEDA DE CLIENTES
create  PROCEDURE [dbo].[spBuscarIdCliente] 
  @idCliente int
  as
  Begin Select * from Cliente
  where idCliente= @idCliente
  end
GO

--PROCEDURE DESHABILITACIÓN DE CLIENTES
create  PROCEDURE [dbo].[spDeshabilitaCliente] 
(@idCliente int
)
as
begin 
	update  Cliente set 
	estCliente = 0
	where idCliente = @idCliente
end


--PROCEDURE EDICIÓN DE CLIENTES
create  PROCEDURE [dbo].[spEditaCliente] 
(@idCliente int,
@razonSocial varchar(50),
@idTipoCliente int,
@fecRegCliente date,
@clienteRUC varchar(50),
@ciudadCliente varchar(50),
@estCliente bit
)
as
begin 

	update  Cliente set 
	razonSocial = @razonSocial,
	idTipoCliente = @idTipoCliente,
	fecRegCliente = @fecRegCliente,
	clienteRUC = @clienteRUC,
			
	estCliente = @estCliente
	where idCliente = @idCliente
end

--PROCEDURE LISTADO CLIENTES
CREATE PROCEDURE [dbo].[spListaCliente] 
AS

	SELECT * from Cliente where estCliente='1' OR estCliente='0'
GO

--PROCEDURE LISTADO CIUDADE EN MANTENEDOR CLIENTE
CREATE PROCEDURE [dbo].[spListaCiudadCliente] 
AS

	SELECT * from Ciudad where estCiudad='1'	
GO

--PROCEDURE INSERTCIÓN CIUDAD
CREATE PROCEDURE [dbo].[spInsertaCiudad] 
(@desCiudad varchar(50),
@estCiudad bit
)
as
begin 

	insert into Ciudad(desCiudad,estCiudad) values
	(@desCiudad, @estCiudad)
end


--PROCEDURE EDICIÓN DE CIUDAD
create  PROCEDURE [dbo].[spEditaCiudad] 
(@idCiudad int,
@desCiudad varchar(50),
@estCiudad bit
)
as
begin 

	update  Ciudad set 
	desCiudad = @desCiudad,
	estCiudad = @estCiudad
	where idCiudad = @idCiudad
end


--PROCEDURE DESHABILITA CIUDAD
create  PROCEDURE [dbo].[spDeshabilitaCiudad] 
(@idCiudad int
)
as
begin 
	update  Ciudad set 
	estCiudad = 0
	where idCiudad = @idCiudad
end


--PROCEDURE LISTADO CIUDADES
CREATE PROCEDURE [dbo].[spListaCiudad] 
AS

	SELECT * from Ciudad where estCiudad='1' OR estCiudad='0'	
GO

delete Cliente
select * from Ciudad
insert into Ciudad values('Trujillo', 1)
insert into Ciudad values('Lima', 1)

insert into Cliente values ('Test', 3, 1,'1254645', 'Trujillo','1993-01-13')
select * from Cliente
