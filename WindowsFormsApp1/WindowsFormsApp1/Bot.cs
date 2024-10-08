using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Bot
    {
        private Game game;
        private Random random;
        public Bot(Game game)
        {
            this.game = game;
        }

        public void Move()
        {
            if(!game.FinalGame && game.MoveSide == true)
            while (true)
            {
                var x = random.Next(0, game.MaxXlenght);
                var y = random.Next(0, game.MaxYlenght);
                if (game.BuffDatas[x, y] == null)
                {
                    game.Move(true, x, y);
                    break;
                }

            }
        }
    }
}
