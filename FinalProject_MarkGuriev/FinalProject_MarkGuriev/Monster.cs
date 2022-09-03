using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalProject_MarkGuriev
{
    class Monster
    {
        
        public int X { get; set; }
        public int Y { get; set; }
        private string _monsterMarker;
        private ConsoleColor _monsterColor;


        public Monster(int initialX, int initialY, int dmg, int mHP)
        {
            X = initialX;
            Y = initialY;
            _monsterMarker = "M";
            _monsterColor = ConsoleColor.Magenta;
            hp = _maxHP;
            damage += dmg;
            hp += mHP;
        }

        public void Draw()
        {
            ForegroundColor = _monsterColor;
            SetCursorPosition(X, Y);
            Write(_monsterMarker);
            ResetColor();

        }
        public int hp, damage = 3;
        private int _maxHP = 17;


        //Monster movement = Player movement
        //abs, number to  tivi
        public double MonsterRange(int x, int y)
        {
            int dX, dY;
            dX = X - x;
            dY = Y - y;
            Math.Abs(dX);
            Math.Abs(dY);
            return Math.Sqrt(dX * dX + dY * dY);
        }

        public void TakeDmg(int damage)
        {
            hp -= damage;
        }
    }
}
