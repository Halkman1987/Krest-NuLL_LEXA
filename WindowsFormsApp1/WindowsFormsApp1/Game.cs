using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Game
    {
        public bool?[,] BuffDatas; // двумерный массив для хранения информ-ии по заполнению ячеек крестиком или ноликом
        public EventHandler<(int x, int y, bool side)> OnMove;//список обработчиков для события хода (ОнМув)
        public EventHandler<bool> OnWin;// список обработчиков для события победы
        public bool MoveSide;
        public bool FinalGame;
        public int MaxXlenght = 10;
        public int MaxYlenght = 10;
        public Game(int maxYlenght, int maxXlenght)
        {
            
            MaxYlenght = maxYlenght;
            MaxXlenght = maxXlenght;
            BuffDatas = new bool?[maxXlenght, maxYlenght];
        }

        public void Move(bool side, int x, int y)
        {
            if (side == MoveSide && !FinalGame)//проверяем сторону и что игра НЕ закончена
            {
                if (BuffDatas[x, y] is null)
                {
                    BuffDatas[x, y] = side;
                    OnMove(this, (x, y, side));
                    CheckFinal();
                    MoveSide = !MoveSide;
                }
                else
                {
                    throw new Exception("Выберите другую ячейку");
                }

            }
            else
            {
                throw new Exception("Нарушен порядок хода ");
            }

        }
        private void CheckFinal()
        {
            if (false)
                FinalGame = true;
           // OnWin();
        }
    }
}
