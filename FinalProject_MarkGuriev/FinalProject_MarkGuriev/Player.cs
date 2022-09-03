using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalProject_MarkGuriev
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string _playerMarker;
        private ConsoleColor _playerColor;


        public Player (int initialX, int initialY)
        {
            X = initialX;
                Y = initialY;
            _playerMarker = "Ö";
            _playerColor = ConsoleColor.DarkRed;
            hp = _maxHP;
        }

        public void Draw()
        {
            ForegroundColor = _playerColor;
            SetCursorPosition(X, Y);
            Write(_playerMarker);
            ResetColor();

        }
        public int hp, damage = 15, coins;
        private int _maxHP = 100;

        public void Takedmg(int damage)
        {
            hp -= damage;
        }
        public int GetHeal(int heal)
        {
            if (hp <= 96 && heal == 3)
            {
                return hp + heal;
            }
            else if (hp <= 98 && heal == 1)
            {
                return hp + heal;
            }
            else if (hp <= 97 && heal == 2)
            {
                return hp + heal;
            }
            else if (heal == 0)
            {
                return hp;
            }
            else
            {
                return hp = _maxHP;
            }
        }

        public bool IsDead()
        {
            return hp <= 0;
        }
    }

}
