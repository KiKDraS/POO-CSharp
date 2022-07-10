namespace Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string NombreEntrenador { get; set; } 
        public int EntrenadorId { get; set; }  
        public int PokemonBaseId { get; set; }
        public string NombrePokemon { get; set; }   
        public int Vida { get; set; }
        public int Exp { get; set; }   
        public int Golpe { get; set; }
        public string Familia { get; set; }
        public bool Is_Aviable { get; set; }
        public bool Is_Active { get; set; }

    }
}