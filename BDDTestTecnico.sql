CREATE DATABASE DBTestTecnico2

GO

USE DBTestTecnico2

CREATE TABLE Personas(
	[id_Persona] [int] IDENTITY(0,1) CONSTRAINT pkPersonas PRIMARY KEY,
	[nombre_Persona] [varchar](50) NOT NULL,
	[nacimiento_Persona] [date] NOT NULL,
	[edad_Persona] [int] NOT NULL,
	[baja_Persona] [bit] NOT NULL,
	[sexo_Persona] [varchar](50) NOT NULL
	);

