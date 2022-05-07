//Planteo de Aplicación

La siguiente estructura corresponder a la creación de un Juego que le permita al usuario crear un personaje (Objeto Entrenador) que pueda interactuar con el mundo de los pokemon (Clases selladas que pertenecen al árbol de herencia del Objeto Pokemon). Los distintos pokemons tienen distintos tipos que los hacen más vulnerables/resistentes a otros tipos de pokemons (Interface ITipo). El personaje tendrá la capcidad de explorar y almacenar la información de los distintos pokemons (Objeto Pokedex). Además, podrá enfrentar a sus pokemons con los pokemons que encuentre mientras explora.

//Estructura a desarrollar

Clase Entrenador
	constructor(nombre)	
		new Pokedex

	//Atributos
	public string Nombre
	public obj Pokedex
	private obj PokemenActivo 
	private obj PokemonSalvaje
	private obj Random
	
	//Métodos
	Explorar => Crea un nuevo Pokemon y lo almacena en PokemonSalvaje
	SeleccionarActivo => Utiliza el casteo de objetos para modificar el atributo PokemonActivo
	AtaqueBasico/AtaqueTipo => Llama al Método AtaqueBasico/AtaqueTipo de Pokemon. PokemnoActivo lucha contra PokemonEncontrado. Derrotar/Atrapar limpia PokemonSalvaje. Perder limpia PokemonActivo. 
	Evolucion => Llama al Método Evolucionar de Pokemon.

Clase Pokedex

	//Atributos
	private list Pokemons (readonly)

	//Métodos
	GetPokemons => Devuelve lista Pokemons
	GetPokemon => Devuelve un Pokemon de la lista
	ActualizarPokedex => Actualiza la lista
	ActualizarPokedexEvolucion => Callback de Entrenador.Evolucion

Clase Pokemon
	//Dato Global
	enum Tipo

	constructor(tipo) => Si no se le pasa un nombre, el atributo nombre pasa a ser el de la clase clase sellada correspondiente
	constructor(nombre, tipo)

	//Atributos
	public string Nombre
	public int Vida
	protected Tipo
	protected int Golpe
	public int Exp
	public int EtapaActual
	protected int Evoluciones

	
	//Métodos
	AtaqueTipo => Ejecutado como callback de Entrenador.Ataque
	AtaqueTipo => Ejecutado como callback de Entrenador.AtaqueTipo. Llama al Método Abstracto RecibirGolpe
	RecibirGolpe => Calcula el daño que se recibe por un AtaqueTipo usando los Métodos de Interface ITipo
	Derrotado => Analiza Vida del Pokemon atacado. Si es 0 o menos, es derrotado. Callback de atacar(Pokemon)
	Evolucionar => Callback de Entrenador.Evolucion. Crea una nueva instancia de Evolucion/Evolucion2 según corresponda
	

Clase Basico: Pokemon, ITipo
	constructor(tipo) => Si no se le pasa un nombre, el atributo nombre pasa a ser el de la clase clase sellada correspondiente
	constructor(nombre, tipo)

	//Atributos
	int Vida = 50
	int Exp

	//Métodos
	override override RecibirGolpe
	

Clase Evolucion: Pokemon, ITipo
	constructor(Exp) => Si no recibe nombre, toma el nombre de la clase. Aplica Exp recibida a atributo Exp
	constructor(Nombre, Exp)

	//Atributos
	int Vida = 100
	int Exp = base(Exp)

	//Métodos
	override RecibirGolpe

Clase Evolucion2: Evolucion, ITipo
	constructor(Exp) => Si no recibe nombre, toma el nombre de la clase. Aplica Exp recibida a atributo Exp
	constructor(Nombre, Exp)

	//Atributos
	int Vida = 150
	int Exp = base(Exp)

	//Métodos
	override RecibirGolpe

sealed class Pikachu:Basico, ITipo

sealed class Raichu:Evolucion, ITipo

//Interfaces
ITipo
	Debilidad() - Calcula el daño recibido según el Tipo de Pokemon que lo provoca. Mayor daño por debilidad
	Resistencia() - Calcula el daño recibido según el Tipo de Pokemon que lo provoca. Menor daño por resistencia 
	
//Excepciones Manejadas
	ArgumentNullException
	FamiliaNoEncontradaException
	PokemonExisteException
