namespace PeleaPersonajes
{
    public class Program
    {

        public bool atarcarPeronsaje(bool regenerate, Personaje ataque, Personaje defensa)
        {
            Random rnd = new Random();
            if (regenerate)
            {
                Console.WriteLine($"{ataque.Name} se está regenerando y no ataca.");
                regenerate = false;
            }
            else if (rnd.NextDouble() > defensa.Esquivar)
            {
                int damage = rnd.Next(10, ataque.DamageMaximo);
                Console.WriteLine($"{ataque.Name} ataca a {defensa.Name} con {damage} de daño.");
                if (damage == 100)
                {
                    regenerate = true;
                    Console.WriteLine($"¡Golpe Critico de {ataque.Name}! {defensa.Name} no atacará en el siguiente ya que tiene que regenerarse.");
                }
                defensa.PuntosSalud -= damage;
                if (defensa.PuntosSalud <= 0)
                {
                    Console.WriteLine($"La vida de {defensa.Name} ha llegado a cero.");
                }
                else
                {
                    Console.WriteLine($"Vida restante de {defensa.Name}: {defensa.PuntosSalud}");
                }
            }
            else
            {
                Console.WriteLine($"¡{defensa.Name} esquiva el ataque de {ataque.Name}!");
            }
            return regenerate;
        }

        public void simularBatalla(int turn, Personaje deadpool, Personaje wolverine)
        {
            bool regenerate = false;

            if (deadpool.PuntosSalud > 0 && wolverine.PuntosSalud > 0)
            {
                turn++;
                Console.WriteLine($"Turno Nro. {turn}");
                atarcarPeronsaje(regenerate, deadpool, wolverine);
                atarcarPeronsaje(regenerate, wolverine, deadpool);
                simularBatalla(turn, deadpool, wolverine);
            }

        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Random rnd = new Random();
            Console.WriteLine("Introduce la vida de Deadpool");
            int deadpool_health = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la vida de Wolverine");
            int wolverine_health = int.Parse(Console.ReadLine());

            Personaje deadpool = new Personaje("Deadpool", deadpool_health, 100, 0.25);
            Personaje wolverine = new Personaje("Wolverine", deadpool_health, 120, 0.2); 

            p.simularBatalla(0, deadpool, wolverine);

        }
    }
}
