using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalProject_MarkGuriev
{
 // ---- C# 101 (Dor Ben Dor) ----
 //          Mark Guryev
 //          07.08.2021
 // ------------------------------
    class Game
    {
        private Sound sound;
        private UI ui;
        private World _myWorld;
        private Player _CurrentPlayer;
        public int lvlCount = 1;
        List<Monster> monsters = new List<Monster>();

        Queue<string> levels = new Queue<string>();
        public void Start()
        {
            Title = "FinalProject_MarkGuriev";
            CursorVisible = false;
            SetWindowSize(125, 40);
            _CurrentPlayer = new Player(1, 1);

            levels.Enqueue("Level 1.txt");
            levels.Enqueue("Level 2.txt");
            levels.Enqueue("Level 3.txt");
            levels.Enqueue("Level 4.txt");
            levels.Enqueue("Level 5.txt");
            levels.Enqueue("Level 6.txt");
            levels.Enqueue("Level 7.txt");
            levels.Enqueue("Level 8.txt");
            levels.Enqueue("Level 9.txt");
            levels.Enqueue("Level 10.txt");
            LvlLoad(levels);

            RunGameLoop(levels);
        }

        private void DisplayIntro()
        {
            WriteLine(@"

 /$$      /$$                     /$$              /$$$$$$                      /$$                        
| $$$    /$$$                    | $$             /$$__  $$                    |__/                        
| $$$$  /$$$$  /$$$$$$   /$$$$$$ | $$   /$$      | $$  \__/ /$$   /$$  /$$$$$$  /$$  /$$$$$$  /$$    /$$   
| $$ $$/$$ $$ |____  $$ /$$__  $$| $$  /$$/      | $$ /$$$$| $$  | $$ /$$__  $$| $$ /$$__  $$|  $$  /$$/   
| $$  $$$| $$  /$$$$$$$| $$  \__/| $$$$$$/       | $$|_  $$| $$  | $$| $$  \__/| $$| $$$$$$$$ \  $$/$$/    
| $$\  $ | $$ /$$__  $$| $$      | $$_  $$       | $$  \ $$| $$  | $$| $$      | $$| $$_____/  \  $$$/     
| $$ \/  | $$|  $$$$$$$| $$      | $$ \  $$      |  $$$$$$/|  $$$$$$/| $$      | $$|  $$$$$$$   \  $/      
|__/     |__/ \_______/|__/      |__/  \__/       \______/  \______/ |__/      |__/ \_______/    \_/       
                                                                                                           
                                                                                                           
                                                                                                           
 /$$$$$$$$ /$$                     /$$       /$$$$$$$                                               /$$    
| $$_____/|__/                    | $$      | $$__  $$                                             | $$    
| $$       /$$ /$$$$$$$   /$$$$$$ | $$      | $$  \ $$ /$$$$$$   /$$$$$$  /$$  /$$$$$$   /$$$$$$$ /$$$$$$  
| $$$$$   | $$| $$__  $$ |____  $$| $$      | $$$$$$$//$$__  $$ /$$__  $$|__/ /$$__  $$ /$$_____/|_  $$_/  
| $$__/   | $$| $$  \ $$  /$$$$$$$| $$      | $$____/| $$  \__/| $$  \ $$ /$$| $$$$$$$$| $$        | $$    
| $$      | $$| $$  | $$ /$$__  $$| $$      | $$     | $$      | $$  | $$| $$| $$_____/| $$        | $$ /$$
| $$      | $$| $$  | $$|  $$$$$$$| $$      | $$     | $$      |  $$$$$$/| $$|  $$$$$$$|  $$$$$$$  |  $$$$/
|__/      |__/|__/  |__/ \_______/|__/      |__/     |__/       \______/ | $$ \_______/ \_______/   \___/  
                                                                    /$$  | $$                              
                                                                   |  $$$$$$/                              
                                                                    \______/                               
");
            WriteLine("Welcome to the Final Project RPG Game by Mark");
            WriteLine("\n Instructions");
            WriteLine("> Use the arrow keys to move");
            Write("> Try to reach the goal, which looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine("> Press any key to start");
            sound.theme.Play();
            ReadKey(true);
            Clear();
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("You finish the game!");
            WriteLine("Your Stats: HP: " + _CurrentPlayer.hp + ", Damage: " + _CurrentPlayer.damage + ", Coins: " + _CurrentPlayer.coins);
            WriteLine("Thanks for playing.");
            WriteLine("Press any key to exit...");
            sound.pass.Play();
            ReadKey(true);
            Environment.Exit(0);
        }

        //Draw World, Player etc...
        private void DrawFrame()
        {
            _myWorld.Draw();

            _CurrentPlayer.Draw();

            SetCursorPosition(0, 27);
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health: {_CurrentPlayer.hp} ");

            ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Damage: { _CurrentPlayer.damage}");

            ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Coins: " + _CurrentPlayer.coins);

            ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Level: " + lvlCount);
            ResetColor();

            foreach (var monster in monsters)
            {
                monster.Draw();
            }

            ui.ListPrint();
        }

        //Key Check
        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
                

            } while (KeyAvailable);
            sound.foot.Play();

            //Player controller + checking if he can walk to position
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (_myWorld.IsPositionWalkable(_CurrentPlayer.X, _CurrentPlayer.Y - 1))
                    {
                        _CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_myWorld.IsPositionWalkable(_CurrentPlayer.X, _CurrentPlayer.Y + 1))
                    {
                        _CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_myWorld.IsPositionWalkable(_CurrentPlayer.X - 1, _CurrentPlayer.Y))
                    {
                        _CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (_myWorld.IsPositionWalkable(_CurrentPlayer.X + 1, _CurrentPlayer.Y))
                    {
                        _CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void RunGameLoop(Queue<string> lvlLodd)
        {
            Console.Clear();
            DisplayIntro();
            sound.start.Play();
            while (true)
            {
                // Draw everything
                DrawFrame();

                MonsterMove();

                // Check for player input from the keyboard and move the player
                HandlePlayerInput();

                Combat();

                // Check if the player has reached the X and load the next lvl
                string elementAtPlayerPos = _myWorld.GetElementAt(_CurrentPlayer.X, _CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    lvlCount++;
                    _CurrentPlayer.damage += 2;
                    sound.fbi.Play();
                    MonsterSpawn();
                    LvlLoad(lvlLodd);
                }
                // Check if the player has reached ^
                else if (elementAtPlayerPos == "^")
                {
                    _CurrentPlayer.hp -= 1;
                    ForegroundColor = ConsoleColor.Gray;
                    ui.AddToList($"You took 1 damaage                               ");

                    _myWorld.GiveElement("*", _CurrentPlayer.X, _CurrentPlayer.Y);
                    sound.oof.Play();
                    ResetColor();
                }
                // Check if the player reached #
                else if (elementAtPlayerPos == "#")
                {
                    Random rand = new Random();
                    int randCoin = rand.Next(2, 10);
                    int randHeal = rand.Next(0, 3);
                    _CurrentPlayer.coins += randCoin;
                    _CurrentPlayer.GetHeal(randHeal);
                    ui.AddToList($"You got {randHeal} heal                                  ");
                    ui.AddToList($"You got {randCoin} coins                                 ");
                    _myWorld.GiveElement(" ", _CurrentPlayer.X, _CurrentPlayer.Y);
                    sound.coin.Play();
                }
                if (_CurrentPlayer.IsDead())
                {
                    DeadScreen();
                }

                // Give the console a chance to render.
                System.Threading.Thread.Sleep(20);
            }
        }

        //Loading the next lvl if he has, if not exit game method 
        private void LvlLoad(Queue<string> lvlLodd)
        {
            //Load some stuff to lvl
            if (lvlLodd.Any())
            {
                string[,] grid = LevelParser.ParseFileToArray(lvlLodd.Dequeue());
                ui = new UI();
                sound = new Sound();
                if (lvlCount != 1)
                {
                    ui.AddToList("                                                           ");
                    ui.AddToList("                                                           ");
                    ui.AddToList("                                                           ");
                    ui.AddToList("                                                           ");
                    ui.AddToList("                                                           ");
                    ui.AddToList($"You reached lvl {lvlCount} and increased your damage by 2 ");
                }

                _myWorld = new World(grid);
                _CurrentPlayer.X = 1;
                _CurrentPlayer.Y = 1;
            }
            else
            {
                DisplayOutro();
            }
        }

        private void DeadScreen()
        {
            Clear();
            WriteLine(@"
██╗░░░██╗░█████╗░██╗░░░██╗  ░██████╗░░█████╗░████████╗  ██╗░░██╗██╗██╗░░░░░██╗░░░░░███████╗██████╗░██╗
╚██╗░██╔╝██╔══██╗██║░░░██║  ██╔════╝░██╔══██╗╚══██╔══╝  ██║░██╔╝██║██║░░░░░██║░░░░░██╔════╝██╔══██╗██║
░╚████╔╝░██║░░██║██║░░░██║  ██║░░██╗░██║░░██║░░░██║░░░  █████═╝░██║██║░░░░░██║░░░░░█████╗░░██║░░██║██║
░░╚██╔╝░░██║░░██║██║░░░██║  ██║░░╚██╗██║░░██║░░░██║░░░  ██╔═██╗░██║██║░░░░░██║░░░░░██╔══╝░░██║░░██║╚═╝
░░░██║░░░╚█████╔╝╚██████╔╝  ╚██████╔╝╚█████╔╝░░░██║░░░  ██║░╚██╗██║███████╗███████╗███████╗██████╔╝██╗
░░░╚═╝░░░░╚════╝░░╚═════╝░  ░╚═════╝░░╚════╝░░░░╚═╝░░░  ╚═╝░░╚═╝╚═╝╚══════╝╚══════╝╚══════╝╚═════╝░╚═╝
");
            WriteLine("Your Stats: HP: " + _CurrentPlayer.hp + ", Damage: " + _CurrentPlayer.damage + ", Coins: " + _CurrentPlayer.coins);
            WriteLine("Thanks for playing.");
            WriteLine("Press any key to exit...");
            sound.loss.Play();
            ReadKey(true);
            Environment.Exit(0);
        }


        //Check monster walk with player
        private void MonsterMove()
        {
            foreach (var monster in monsters)
            {
                if (monster.MonsterRange(_CurrentPlayer.X, _CurrentPlayer.Y) <= 2)
                {
                    if (monster.X < _CurrentPlayer.X)
                    {
                        if (_myWorld.IsPositionWalkable(monster.X + 1, monster.Y))
                        {
                            monster.X += 1;
                        }
                    }
                    else if (monster.X > _CurrentPlayer.X)
                    {
                        if (_myWorld.IsPositionWalkable(monster.X - 1, monster.Y))
                        {
                            monster.X -= 1;
                        }
                    }
                    else if (monster.Y < _CurrentPlayer.Y)
                    {
                        if (_myWorld.IsPositionWalkable(monster.X, monster.Y + 1))
                        {
                            monster.Y += 1;
                        }
                    }
                    else if (monster.Y > _CurrentPlayer.Y)
                    {
                        if (_myWorld.IsPositionWalkable(monster.X, monster.Y - 1))
                        {
                            monster.Y -= 1;
                        }
                    }
                }
            }
        }

        private void Combat()
        {
            
            List<Monster> toRemove = new List<Monster>();
            foreach (var monster in monsters)
            {

                if (monster.MonsterRange(_CurrentPlayer.X, _CurrentPlayer.Y) <= 1)
                {
                    _CurrentPlayer.Takedmg(monster.damage);
                    monster.TakeDmg(_CurrentPlayer.damage);
                   ui.AddToList("The enemy took " + _CurrentPlayer.damage + " damage");
                    ui.AddToList("You took " + monster.damage + " damage");
                    if (monster.hp <= 0)
                    {
                        ui.AddToList("The enemy is dead                                  ");
                        toRemove.Add(monster);
                        
                        break;
                    }
                }
            }
            foreach (var monster in toRemove)
            {
                monsters.Remove(monster);
            }
        }

        private void MonsterSpawn()
        {
            {

                switch (lvlCount)
                {
                    case 2:
                        monsters.Add(new Monster(35, 5, 2, 2));
                        break;
                    case 3:
                        monsters.Clear();
                        monsters.Add(new Monster(37, 9, 4, 4));
                        break;
                    case 6:
                        monsters.Clear();
                        monsters.Add(new Monster(20, 7, 5, 5));
                        break;
                    case 8:
                        monsters.Clear();
                        monsters.Add(new Monster(7, 16, 7, 7));
                        break;
                    case 10:
                        monsters.Clear();
                        monsters.Add(new Monster(40, 9, 12, 12));
                        monsters.Add(new Monster(36, 23, 12, 12));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
