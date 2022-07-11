USE [pokemon]
GO

/* Datos Iniciales */
INSERT INTO [dbo].[entrenadores]
           ([entrenador_nombre])
     VALUES
           ('Ash')

INSERT INTO [dbo].[pokemons_base]
           ([pokemon_familia]
           ,[vida_base]
           ,[golpe_base]
           ,[etapa_actual])
     VALUES
           ('Pikachu',50,10,1),
           ('Raichu',100,20,2),
           ('Bulbasaur',50,10,1),
           ('Ivysaur',100,20,2),
           ('Venasaur',150,30,3),
           ('Squirtle',50,10,1),
           ('Wartortle',100,20,2),
           ('Blastoise',150,30,3),
           ('Charmander',50,10,1),
           ('Charmeleon',100,20,2),
           ('Charizard',150,20,3)


INSERT INTO [dbo].[pokedex]
           ([entrenador_id]
           ,[pokemon_base_id]
           ,[pokemon_nombre]
           ,[pokemon_vida]
           ,[pokemon_exp]
           ,[is_aviable]
           ,[is_active])
     VALUES
           (1,1,'Pikachu',20,40,1,1),
           (1,3,'Bulbasaur',40,0,1,0)

GO
