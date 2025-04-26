using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Game
    {
        private Player player;
        private List<Enemy> enemies = new List<Enemy>();

        public void Start()
        {
            CreateGame();
            PlayGame();
        }

        private void CreateGame()
        {
            Console.WriteLine("Crea tu jugador:");
            Console.Write("Nombre: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);

            Console.WriteLine("Agrega un item:");
            Console.Write("Nombre del item: ");
            string itemName = Console.ReadLine();
            Console.Write("¿Cura vida? (si/no): ");
            bool isLifeItem = Console.ReadLine() == "si";
            Console.Write("¿Cuánto cura?: ");
            int amount = int.Parse(Console.ReadLine());
            player.AddItem(new Item(itemName, isLifeItem, amount));

            Console.WriteLine("Agrega un poder:");
            Console.Write("Nombre del poder: ");
            string powerName = Console.ReadLine();
            Console.Write("Costo de mana: ");
            int manaCost = int.Parse(Console.ReadLine());
            Console.Write("Daño que causa: ");
            int damage = int.Parse(Console.ReadLine());
            player.AddPower(new Power(powerName, manaCost, damage));

            Console.WriteLine("Agrega un enemigo:");
            Console.Write("Nombre del enemigo: ");
            string enemyName = Console.ReadLine();
            Enemy enemy = new Enemy(enemyName);

            enemy.AddItem(new Item("Poción Enemiga", true, 20));
            enemies.Add(enemy);
        }

        private void PlayGame()
        {
            while (player.Life > 0 && enemies.Count > 0)
            {
                Console.WriteLine("\n--- Turno del Jugador ---");
                Console.WriteLine("1. Usar item");
                Console.WriteLine("2. Atacar enemigo");
                string choice = Console.ReadLine();

                Enemy enemy = enemies[0];

                if (choice == "1")
                {
                    player.UseItem();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("1. Ataque normal");
                    Console.WriteLine("2. Usar poder");
                    string attackChoice = Console.ReadLine();

                    if (attackChoice == "1")
                    {
                        player.Attack(enemy);
                    }
                    else if (attackChoice == "2")
                    {
                        player.UsePower(enemy);
                    }

                    if (enemy.IsDead())
                    {
                        Console.WriteLine(enemy.Name + " ha muerto!");
                        foreach (Item item in enemy.GetItems())
                        {
                            player.AddItem(item);
                            Console.WriteLine("Recogiste: " + item.Name);
                        }
                        enemies.Remove(enemy);
                    }
                }

                if (enemies.Count > 0)
                {
                    Console.WriteLine("\n--- Turno del Enemigo ---");
                    enemy.Attack(player);
                }
            }

            if (player.Life <= 0)
            {
                Console.WriteLine("\nFalleciste uu");
            }
            else
            {
                Console.WriteLine("\nGanaste!");
            }
        }
    }
}
