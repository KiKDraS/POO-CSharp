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
           ,[golpe_base])
     VALUES
           ('Pikachu',50,10),
           ('Raichu',100,20),
           ('Bulbasaur',50,10),
           ('Ivysaur',100,20),
           ('Venasaur',150,30),
           ('Squirtle',50,10),
           ('Wartortle',100,20),
           ('Blastoise',150,30),
           ('Charmander',50,10),
           ('Charmeleon',100,20),
           ('Charizard',150,20)


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
