using Biblioteca.Pokemons;
using BLL;

namespace Biblioteca
{
    public static class Vistas
    {
        private static readonly List<string> TiposAtaques = new()
        {
            "Ataque Básico",
            "Ataque Especial"
        };

        /// <summary>
        ///     Imprime un título en pantalla
        /// </summary>
        private static void Titulo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(".~~~~~~~~~~~~~~~~~~.");
            Console.WriteLine("| Aventura Pokemon |");
            Console.WriteLine("'~~~~~~~~~~~~~~~~~~'\n");

            Console.ResetColor();
        }

        /// <summary>
        ///     Arma la vista para la creación del Objeto Entrenador tomando en cuenta la existencia o no de una partida iniciada y cargadno los datos almacenados en la Base de Datos cuando corresponda
        /// </summary>
        /// <returns>Objeto Entrenador</returns>
        public static Entrenador InicioJuego()
        {
            Entrenador entrenador = null;
            List<string> menuInicio = new() { "Nueva Aventura", "Continuar Aventura" };

            Titulo();
            Console.WriteLine("Bienvenid@. Quieres iniciar una Nueva Aventura o Continuar una iniciada?");            
            GenerarMenu(menuInicio);
            int seleccion = Validaciones.ValidarNumero();
            seleccion =  Validaciones.ValidarOpcionMenu(menuInicio, seleccion);

            if (seleccion == 1)
            {
                Console.Clear();
                //Obtener Entrenadores en BD y armar Lista menú
                var entrenadores = BLLEntrenador.ObtenerTodos();
                List<string> menuEntrenadores = ArmarMenuEntrenadores(entrenadores);
                //Crear Objeto Entrenador
                string nombreEntrenador = NombreEntrenador(menuEntrenadores);
                entrenador = new(nombreEntrenador);
                Console.Clear();
                //Obtener Pokemones Iniciales de BD
                var pokemonesIniciales = BLLPokemones.ObtenerPokemonsIniciales();
                List<string> menuPokeIniciales = new();
                foreach (var poke in pokemonesIniciales)
                {
                    menuPokeIniciales.Add(poke.Familia);
                }
                //Crear Pokemon Inicial
                string pokemonInicial = PokemonInicial(menuPokeIniciales);
                switch (pokemonInicial)
                {
                    case "Pikachu":
                        var plantillaPikachu = BLLPokemones.ObtenerUnPokemon(pokemonesIniciales, pokemonInicial);
                        Pikachu pikachu = new()
                        {
                            NombreEntrenador = entrenador.Nombre,
                            PokemonBaseId = plantillaPikachu.PokemonBaseId,
                            Vida = plantillaPikachu.Vida,
                            Golpe = plantillaPikachu.Golpe,
                            Familia = plantillaPikachu.Familia,
                            Is_Aviable = true,
                            Is_Active = true
                        };
                        entrenador.AgregarPokemonPokedex(pikachu);
                        break;
                    case "Squirtle":
                        var plantillaSquirtle = BLLPokemones.ObtenerUnPokemon(pokemonesIniciales, pokemonInicial);
                        Squirtle squirtle = new()
                        {
                            NombreEntrenador = entrenador.Nombre,
                            PokemonBaseId = plantillaSquirtle.PokemonBaseId,
                            Vida = plantillaSquirtle.Vida,
                            Golpe = plantillaSquirtle.Golpe,
                            Familia = plantillaSquirtle.Familia,
                            Is_Aviable = true,
                            Is_Active = true
                        };
                        entrenador.AgregarPokemonPokedex(squirtle);
                        break;
                    case "Bulbasaur":
                        var plantillaBulbasaur = BLLPokemones.ObtenerUnPokemon(pokemonesIniciales, pokemonInicial);
                        Bulbasaur bulbasaur = new()
                        {
                            NombreEntrenador = entrenador.Nombre,
                            PokemonBaseId = plantillaBulbasaur.PokemonBaseId,
                            Vida = plantillaBulbasaur.Vida,
                            Golpe = plantillaBulbasaur.Golpe,
                            Familia = plantillaBulbasaur.Familia,
                            Is_Aviable = true,
                            Is_Active = true
                        };
                        entrenador.AgregarPokemonPokedex(bulbasaur);
                        break;
                    case "Charmander":
                        var plantilaCharmander = BLLPokemones.ObtenerUnPokemon(pokemonesIniciales, pokemonInicial);
                        Charmander charmander = new()
                        {
                            NombreEntrenador = entrenador.Nombre,
                            PokemonBaseId = plantilaCharmander.PokemonBaseId,
                            Vida = plantilaCharmander.Vida,
                            Golpe = plantilaCharmander.Golpe,
                            Familia = plantilaCharmander.Familia,
                            Is_Aviable = true,
                            Is_Active = true
                        };
                        entrenador.AgregarPokemonPokedex(charmander);
                        entrenador.AgregarPokemonPokedex(new Charmander());
                        break;
                } 
                //Poner como Pokemon Activo
                entrenador.SeleccionarPokemonActivo(0);
                //Guardar Nueva Partida
                Console.WriteLine("Vamos a guardar tu nueva partida");
                PuntosSuspensivos();
                GuardarPartida(entrenadores, entrenador);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                //Obtener Entrenadores en BD y armar Lista menú
                var entrenadores = BLLEntrenador.ObtenerTodos();
                List<string> menuEntrenadores = ArmarMenuEntrenadores(entrenadores);
                Titulo();
                //Crear Objeto Entrenador
                Console.WriteLine("Selecciona tu partida");
                GenerarMenu(menuEntrenadores);
                int seleccionEntrenador = Validaciones.ValidarNumero();
                seleccionEntrenador = Validaciones.ValidarOpcionMenu(menuInicio, seleccionEntrenador);
                foreach (var item in entrenadores)
                {
                    if (item.Nombre == menuEntrenadores[seleccionEntrenador - 1])
                    {
                        entrenador = new(item.Id, item.Nombre);
                        break;
                    }
                }
                //Obtener Pokemones de Entrenador en BD
                var pokemones = BLLPokemones.ObtenerPokemonsEntrenador(entrenador.Id);
                //Creación de Pokedex
                Pokedex pokedex = new();
                foreach (var pokemon in pokemones)
                {
                    switch (pokemon.Familia)
                    {
                        case "Pikachu":
                            Pikachu pikachu = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(pikachu);
                            break;
                        case "Raichu":
                            Raichu raichu = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(raichu);
                            break;
                        case "Bulbasaur":
                            Bulbasaur bulbasaur = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(bulbasaur);
                            break;
                        case "Ivysaur":
                            Ivysaur ivysaur = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(ivysaur);
                            break;
                        case "Venasaur":
                            Venasaur venasaur = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(venasaur);
                            break;
                        case "Squirtle":
                            Squirtle squirtle = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(squirtle);
                            break;
                        case "Wartortle":
                            Wartortle wartortle = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(wartortle);
                            break;
                        case "Blastoise":
                            Blastoise blastoise = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(blastoise);
                            break;
                        case "Charmander":
                            Charmander charmander = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(charmander);
                            break;
                        case "Charmeleon":
                            Charmeleon charmeleon = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(charmeleon);
                            break;
                        case "Charizard":
                            Charizard charizard = new()
                            {
                                Id = pokemon.Id,
                                NombreEntrenador = pokemon.NombreEntrenador,
                                EntrenadorId = pokemon.EntrenadorId,
                                PokemonBaseId = pokemon.PokemonBaseId,
                                NombrePokemon = pokemon.NombrePokemon,
                                Vida = pokemon.Vida,
                                Exp = pokemon.Exp,
                                Golpe = pokemon.Golpe,
                                Familia = pokemon.Familia,
                                Is_Aviable = pokemon.Is_Aviable,
                                Is_Active = pokemon.Is_Active
                            };
                            pokedex.InsertPokemon(charizard);
                            break;
                    }
                }
                //Agregar a Entrenador
                entrenador.Pokedex = pokedex;
                Console.Clear();
                //Restaurar Pokemons
                entrenador = RestaurarPokemons(entrenador);
                Console.Clear();
                //Seleccionar Pokemon Activo
                string pokemonSeleccionado = SeleccionarPokemonActivo(entrenador);
                int index = 0;
                foreach (var pokemon in entrenador.Pokedex.GetPokemons())
                {
                    if (pokemon.NombrePokemon == pokemonSeleccionado)
                        break;
                    index++;
                }
                entrenador.SeleccionarPokemonActivo(index);
            }

                return entrenador;
        }

        /// <summary>
        ///     Arma la vista para la selcción de un nombre para una cuenta nueva
        /// </summary>
        /// <returns>Nombre Entrenador</returns>
        public static string NombreEntrenador(List<string> menuEntrenadores)
        {
            Titulo();
            Console.WriteLine("Elije un nombre para tu personaje");
            string nombre = Validaciones.ValidarNombreVacio(menuEntrenadores);
            return nombre;
        }

        /// <summary>
        ///    Imprime en patalla un menú que permite seleccionar el Pokemon inicial. Crea un Objeto Basico de   la clase sellada correpondiente con la selección. Utiliza el método GenerarMenu para la creación del menú a mostrar
        /// </summary>
        /// <returns>Objeto Basico</returns>
        public static string PokemonInicial(List<string> menu){
            Titulo();
            Console.WriteLine("Selecciona un Pokemon para iniciar la Aventura:");
            GenerarMenu(menu);
            int seleccion = Validaciones.ValidarNumero();
            int pokemonInicial = Validaciones.ValidarOpcionMenu(menu, seleccion);

            return menu[pokemonInicial-1];
        }

        /// <summary>
        ///     Crea la vista para la explorar en el juego. Explorar implica la creación de un Objeto Pokemon y la inserción del mismo en el atributo PokemonSalvaje del Objeto NombreEntrenador
        /// </summary>
        /// <param name="entrenador">Objeto NombreEntrenador que recibirá al Objeto Pokemon creado</param>
        public static void Explorar(Entrenador entrenador)
        {
            Titulo();
            Console.WriteLine("Con tu nuevo Pokemon te adentras en el bosque en busca de Pokemons Salvajes para ampliar tus conocimientos");
            PuntosSuspensivos();
            Console.WriteLine("Un Pokemon Salvaje ha aparecido");
            Random rand = new();
            int i = rand.Next(1, 11);
            switch (i)
            {
                case 1:
                    entrenador.Explorar(new Pikachu());
                    break;
                case 2:
                    entrenador.Explorar(new Raichu());
                    break;
                case 3:
                    entrenador.Explorar(new Bulbasaur());
                    break;
                case 4:
                    entrenador.Explorar(new Ivysaur());
                    break;
                case 5:
                    entrenador.Explorar(new Venasaur());
                    break;
                case 6:
                    entrenador.Explorar(new Squirtle());
                    break;
                case 7:
                    entrenador.Explorar(new Wartortle());
                    break;
                case 8:
                    entrenador.Explorar(new Blastoise());
                    break;
                case 9:
                    entrenador.Explorar(new Charmander());
                    break;
                case 10:
                    entrenador.Explorar(new Charmeleon());
                    break;
                case 11:
                    entrenador.Explorar(new Charizard());
                    break;
            }
            Console.WriteLine($"La Pokedex te dice que es un {entrenador.PokemonSalvaje.NombrePokemon}");
            Console.WriteLine("Vamos a enfrentarnos a el");
        }

        /// <summary>
        ///     Crea la vista para el enfrentamiento entre los PokemonActivo y PokemonSalvaje que se encuentran almacenados en el Objeto NombreEntrenador
        /// </summary>
        /// <param name="entrenador">Objeto NombreEntrenador del que se toman los datos PokemonActivo y PokemonSalvaje</param>
        /// <returns></returns>
        public static string Enfrentamiento(Entrenador entrenador)
        {
            string resultado = "";

            while (entrenador.PokemonActivo.Vida > 0 && entrenador.PokemonSalvaje.Vida > 0)
            {
                Titulo();
                Console.WriteLine("Selecciona el tipo de ataque quieres utilizar:");                
                GenerarMenu(TiposAtaques);
                int seleccion = Validaciones.ValidarNumero();
                int tipoAtaque = Validaciones.ValidarOpcionMenu(TiposAtaques, seleccion);

                switch (tipoAtaque)
                {
                    case 1:
                        entrenador.AtaqueBasico();
                        break;
                    case 2:
                        entrenador.AtaqueTipo();
                        break;
                }

                if(entrenador.PokemonActivo is null)
                {
                    Console.WriteLine("A tu Pokemon lo han derrotado");
                    resultado = "El Pokemon Salvaje a ganado";
                    break;
                }
                else
                {
                    Console.WriteLine($"A tu Pokemon le quedan {entrenador.PokemonActivo.Vida} puntos de Vida");
                }

                if(entrenador.PokemonSalvaje is null)
                {
                    Console.WriteLine("El Pokemon Salvaje ha sido derrotado");
                    resultado = "Tu Pokemon ha ganado";
                    break;
                }
                else
                {
                    Console.WriteLine($"Al Pokemon salvaje le quedan {entrenador.PokemonSalvaje.Vida} puntos de Vida");
                }

                Console.ReadKey();
                Console.Clear();
            }

            return resultado;
        }

        /// <summary>
        ///     Crea la vista para el enfrentamiento victorioso contra el Pokemon Salvaje. Muestra el resultado en pantalla. Aplica la experiencia obtenida por el Pokemon Activo de entrenador recibido por parámetro. 
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="entrenador"></param>
        public static void Ganador(string resultado, Entrenador entrenador)
        {
            Titulo();
            Console.WriteLine(resultado);
            entrenador.PokemonActivo.SetExp(50);
            Console.WriteLine("Se le aplicará una posición para sanar sus heridas");
            entrenador.DarPocion();
            Console.WriteLine("Recibe 50 puntos de experiencia");
            Evolucion(entrenador);
        }

        /// <summary>
        ///     Crea la vista para la Evolución del PokemonActivo del Objeto NombreEntrenador
        /// </summary>
        /// <param name="entrenador">Objeto NombreEntrenador del que se toma el dato PokemonActivo</param>
        public static void Evolucion(Entrenador entrenador)
        {
            string actual = entrenador.PokemonActivo.Familia;
            Console.WriteLine($"{actual} está evolucionando!");
            entrenador.Evolucion();
            Console.WriteLine($"Tu {actual} ahora es un {entrenador.PokemonActivo.Familia}");
            Console.ReadKey();
        }

        /// <summary>
        ///     Crea la vista de la finalización del juego. Muestra una vista distinta dependiendo del resultado del enfrentamientos. Limpia la variable que almacena al Objeto NombreEntrenador para preparar el reinicio del juego. Retorna un bool para manejar el reinicio o cierre del juego
        /// </summary>
        /// <param name="resultado">string con el resultado del enfrentamiento</param>
        /// <param name="entrenador">Objeto NombreEntrenador a ser limpiuado</param>
        /// <returns>bool reiniciar</returns>
        public static bool FinDelJuego(string resultado, Entrenador entrenador)
        {
            bool reiniciar = true;

            if (!string.IsNullOrEmpty(resultado))
            {
                Titulo();
                Console.WriteLine("Han derrotado a tu Pokemon y tu aventura llega a su fin");
                Console.WriteLine("Vamos a Guardar tu Progreso");
                var entrenadores = BLLEntrenador.ObtenerTodos();
                GuardarPartida(entrenadores, entrenador);
                PuntosSuspensivos();
                reiniciar = Validaciones.ValidarTecla("Presione ENTER para reiniciar o ESC para salir");
            }
            else
            {
                Titulo();
                Console.WriteLine("El juego a llegado a su fin");
                var entrenadores = BLLEntrenador.ObtenerTodos();
                GuardarPartida(entrenadores, entrenador);
                PuntosSuspensivos();
                reiniciar = Validaciones.ValidarTecla("Presione ENTER para reiniciar o ESC para salir");
            }  

            if (reiniciar)
            {
                Titulo();
                Console.WriteLine("La consola va a reiniciarse");
            }
                
            PuntosSuspensivos();
            entrenador = null;
            return reiniciar;
        }

        /// <summary>
        ///     Crea un menú de selección utilizando los elementos existentes en una Lista.
        /// </summary>
        /// <param name="lista">Lista utilizada para la creación del menú</param>
        private static void GenerarMenu(List<string> lista)
        {
            int loop = 1;
            foreach (string el in lista)
            {
                Console.WriteLine($"{loop}. {el}");
                loop++;
            }
        }

        /// <summary>
        ///     Crea una vista de puntos suspensivos con delay para simular esperas
        /// </summary>
        private static void PuntosSuspensivos()
        {
            for (int i = 0; i < 3; i++)
            {
                int mydelay = 1000;
                Console.Write(".");
                Thread.Sleep(mydelay);
                Console.Write(".");
            }
            Console.WriteLine("");
        }

        /// <summary>
        ///     Genera una lista de los Pokemon almacenados en el atributo Pokedex del Objeto Entrenador recibido por parámetro.
        /// </summary>
        /// <param name="entrenador"></param>
        private static List<string> ListaPokemons(Entrenador entrenador, bool isActive)
        {
            var pokemons = entrenador.Pokedex.GetPokemons();
            var lista = new List<string>();
            if (isActive)
            {
                foreach (var pokemon in pokemons)
                {
                    if (pokemon.Is_Aviable == true && pokemon.Vida > 0)                
                        lista.Add(pokemon.NombrePokemon);               
                }
            }
            else
            {
                foreach (var pokemon in pokemons)
                {
                    if (pokemon.Is_Aviable == true && pokemon.Vida <= 0)
                        lista.Add(pokemon.NombrePokemon);
                }
            }
            
            return lista;
        }
        
        /// <summary>
        ///     Genera una lista de string en base a los entrenadores almacenados en la Base de Datos
        /// </summary>
        /// <param name="entrenadores"></param>
        /// <returns>Lista de strings con los nombres de todos los entrenadores</returns>
        private static List<string> ArmarMenuEntrenadores(List<Entities.Entrenador> entrenadores)
        {
            List<string> menuEntreadores = new();
            foreach (var entre in entrenadores)
            {
                menuEntreadores.Add(entre.Nombre);
            }
            return menuEntreadores;
        }
        
        /// <summary>
        ///     Genera la vista de selección del Pokemon Activo
        /// </summary>
        /// <param name="entrenador"></param>
        /// <returns>int que representa el índice del pokemon seleccionado</returns>
        private static string SeleccionarPokemonActivo(Entrenador entrenador)
        {
            Titulo();
            Console.WriteLine("Selecciona el Pokemon Activo");
            List<string> menuPokemons = ListaPokemons(entrenador, true);
            for (int i = 0; i < menuPokemons.Count(); i++)
            {
                Console.WriteLine($"{i+1}. {menuPokemons[i]}");
            }               
            int seleccion = Validaciones.ValidarNumero();
            seleccion = Validaciones.ValidarOpcionMenu(menuPokemons, seleccion);
            return menuPokemons[seleccion-1];
        }
        
        /// <summary>
        ///     Genera la vista para la restauración de la vida de los Pokemones que están disponibles para ser elegidos. Modifica los stats en la Pokedex del Objeto Entrenador recibido por parámetro. 
        /// </summary>
        /// <param name="entrenador"></param>
        /// <returns>El Objeto Entrenador modificado</returns>
        private static Entrenador RestaurarPokemons(Entrenador entrenador)
        {
            Titulo();
            Console.WriteLine("Vamos a comprobar el estado de tus Pokemon");
            List<string> menuPokemons = ListaPokemons(entrenador, false);
            if(menuPokemons.Count > 0)
            {
                PuntosSuspensivos();
                Console.WriteLine("Estos Pokemon necesitan ser atendidos antes de comenzar");
                Console.WriteLine("");
                foreach (var poke in menuPokemons)
                {
                    Console.WriteLine($"{poke}");
                }
                Console.WriteLine("");
                Console.ReadLine();
                Console.Clear();
                Titulo();
                Console.WriteLine("Nos encargaremos de dejarlos como nuevos");
                foreach (var pokemon in entrenador.Pokedex.GetPokemons())
                {
                    if (pokemon.Vida <= 0)
                    {
                        switch (pokemon.EtapaActual)
                        {
                            case 1:
                                pokemon.Is_Aviable = true;
                                pokemon.Vida = 50;
                                break;
                            case 2:
                                pokemon.Is_Aviable = true;
                                pokemon.Vida = 100;
                                break;
                            case 3:
                                pokemon.Is_Aviable = true;
                                pokemon.Vida = 150;
                                break;
                        }
                    }
                }
                PuntosSuspensivos();
                Console.WriteLine("Perfecto! Ya estan listos para continuar");
            }
            else
            {
                PuntosSuspensivos();
                Console.WriteLine("Genial! Ninguno de tus Pokemon necesita ser atendido");
            }            
            Console.ReadKey();

            return entrenador;
        }
        
        /// <summary>
        ///     Genera la vista de guarado de partida a partir del Objeto Entrenador. Si el nombre del Objeto Entrenador no coincide con los nombres dentro de la Lista envía los datos del Objeto Entrenador a la Base de Datos; si existe, actualiza los datos en la BD
        /// </summary>
        /// <param name="entrenadoresEntitie"></param>
        /// <param name="entrenador"></param>
        private static void GuardarPartida(List<Entities.Entrenador> entrenadoresEntitie, Entrenador entrenador)
        {
            bool nuevo = true;
            List<string> entrenadores = ArmarMenuEntrenadores(entrenadoresEntitie);
            foreach (var entre in entrenadores)
            {
                if(entre == entrenador.Nombre)
                {
                    nuevo = false;
                    break;
                }
            }
            List<Biblioteca.Pokemon> pokemonsObjetoEntrenador = entrenador.Pokedex.GetPokemons();
            if (nuevo)
            {
                Entities.Entrenador nuevoEntrenador = new()
                {
                    Nombre = entrenador.Nombre
                };
                BLLEntrenador.Agregar(nuevoEntrenador);
                //Agregar del entrenador en Objeto Entrenador
                var listaEntrenadores = BLLEntrenador.ObtenerTodos();
                foreach (var item in listaEntrenadores)
                {
                    if (item.Nombre == nuevoEntrenador.Nombre)
                    {
                        int idEntrenador = BLLEntrenador.ObtenerEntrenador(nuevoEntrenador.Nombre);

                        foreach (var poke in pokemonsObjetoEntrenador)
                        {
                            Entities.Pokemon pokemonEntitie = new()
                            {
                                Id = poke.Id,
                                NombreEntrenador = nuevoEntrenador.Nombre,
                                EntrenadorId = idEntrenador,
                                PokemonBaseId = poke.PokemonBaseId,
                                NombrePokemon = poke.NombrePokemon,
                                Vida = poke.Vida,
                                Exp = poke.Exp,
                                Golpe = poke.Golpe,
                                Familia = poke.Familia,
                                Is_Aviable = poke.Is_Aviable,
                                Is_Active = poke.Is_Active
                            };
                            BLLPokemones.AgregarAPokedex(pokemonEntitie);
                        }
                        break;
                    }
                }
            }
            else
            {
                List<Entities.Pokemon> nuevosDatos = new();
                foreach (var poke in pokemonsObjetoEntrenador)
                {
                    Entities.Pokemon pokemonEntitie = new()
                    {
                        Id = poke.Id,
                        NombreEntrenador = poke.NombreEntrenador,
                        EntrenadorId = poke.EntrenadorId,
                        PokemonBaseId = poke.PokemonBaseId,
                        NombrePokemon = poke.NombrePokemon,
                        Vida = poke.Vida,
                        Exp = poke.Exp,
                        Golpe = poke.Golpe,
                        Familia = poke.Familia,
                        Is_Aviable = poke.Is_Aviable,
                        Is_Active = poke.Is_Active
                    };
                    nuevosDatos.Add(pokemonEntitie);
                }
                foreach (var poke in nuevosDatos)
                {
                    if (poke.Id == 0)
                        BLLPokemones.AgregarAPokedex(poke);
                    else
                        BLLPokemones.ModificarEnPokedex(poke);
                }
            }
            
        }   
    }
}
