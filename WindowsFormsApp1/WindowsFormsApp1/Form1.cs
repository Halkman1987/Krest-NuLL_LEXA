﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        private int cellHeight;
        private int cellWidht;
        private Game game;
        private Bot bot;
        bool gameStarted = false;//сомнительно но пусть будет пока
        public Form1()
        {
            InitializeComponent();
           
            game = new Game(10, 10);//вручную задаём размеры виртуального поля для записи в него ходов
            bot = new Bot(game); // прокинули в БОТА текущюю Гаму 
            game.OnMove += DrawMove; 
            
            
            //Реальное поле на котором нужно рисовать
            cellHeight = pctLineXY.Height / 10; // вычисляем шириную ячейки в пикселях
            cellWidht = pctLineXY.Width / 10; // вычисляем высоту ячейки  в пикселях

            // game.OnWin += 
        }
        
        //Метод Гаме.Мув выполняет ОнМув, а тот ВраитМув и он уже рисует....ниче не понятно
        
        private void DrawMove(object sender, (int x, int y, bool side) move) // только для рисования, принимает только параметры КУДА и ЧТО рисовать
        {
            var (x, y, side) = move;
            var centrX = (cellHeight * x);
            var centrY = (cellWidht * y);
          //  if((side == false || true) && radioButton1.Checked == true)

            //рисуешь крестик или нолик  в зависимости кто сходил и что выбрано
            if (radioButton1.Checked == true && side == false)
            {
                DrawKrestik(centrX, centrY);
            }
            else
            {
                if(radioButton1.Checked == true & side == true)
                {
                   DrawNoLik(centrX, centrY);
                }
                else
                {
                    if(radioButton2.Checked == true & side == false)
                    {
                        DrawNoLik(centrX, centrY);
                    }
                    else
                    {
                        DrawKrestik(centrX, centrY);
                    }
                }
            }
        }
        private void pctLineXY_MouseClick(object sender, MouseEventArgs e) // событие клика по пикчербоксу
        {
            if (gameStarted == false)
            {
                gameStarted = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            int x = e.X / (pctLineXY.Width / 10);//вычисляем порядковый номер ячейки и + 1 (в которой будет стоять мышь) 
            int y = e.Y / (pctLineXY.Height / 10);
            bool temp;
           
            game.Move(false, x, y);
            bot.Move();
            //временно сделали 2 хода для проверки
            //game.Move(false, x, y); // пока вписали жестко куда будет ходить Человек
            //bot.Move(); // БОТ ходит рандомно
        }
        public void DrawNoLik(int x, int y) // Метод для Нолика
        {
            Graphics g = pctLineXY.CreateGraphics();
            Pen pn = new Pen(Color.Red, 3);
            g.DrawEllipse(pn, x+3, y+3, 33, 33);
            //int width = pctLineXY.Width;//ширина поля  в пикселях 
            //int height = pctLineXY.Height;//высота поля в пикселях
            //int stepx = width / 10; //ширина ячейки поля в пикселях
            //int stepy = height / 10;// высота ячейки поля в пикселях
            //int bufX = e.X / stepx; //количество целых ячеек
            //int bufY = e.Y / stepy; //количество целых ячеек
            //int coordinataX = bufX * stepx + (stepx / 2);
            //int coordinataY = bufY * stepy + (stepy / 2);
            //Graphics g = pctLineXY.CreateGraphics();
            //Pen pn = new Pen(Color.Red, 3);
            //g.DrawEllipse(pn, coordinataX - 17, coordinataY - 17, 34, 34);


        }
        public void DrawKrestik(int x, int y) // Метод для крестика
        {
           
            int bufX = x / cellHeight; //количество целых ячеек
            int bufY = y / cellWidht;

            int coordinataX1 = x;// cellHeight;//верхняя левая
            int coordinataY1 = y;// cellWidht;

            int coordinataX2 = bufX * cellHeight + cellHeight;//верхняя правая
            int coordinataY2 = bufY * cellWidht;

            int coordinataX3 = bufX * cellHeight;//верхняя правая
            int coordinataY3 = bufY * cellWidht + cellWidht;

            int coordinataX4 = bufX * cellHeight + cellHeight;//нижняя правая
            int coordinataY4 = bufY * cellWidht + cellWidht;

            Graphics g = pctLineXY.CreateGraphics();
            Pen pn = new Pen(Color.Blue, 3);
            g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
            g.DrawLine(pn, coordinataX3, coordinataY3, coordinataX2, coordinataY2);
            
            //int width = pctLineXY.Width;
            //int height = pctLineXY.Height;
            //int stepx = width / 10; //ширина ячейки 
            //int stepy = height / 10;// высота ячейки
            //int bufX = e.X / stepx; //количество целых ячеек
            //int bufY = e.Y / stepy;

            //int coordinataX1 = bufX * stepx;//верхняя левая
            //int coordinataY1 = bufY * stepy;

            //int coordinataX2 = bufX * stepx + stepx;//верхняя правая
            //int coordinataY2 = bufY * stepy;

            //int coordinataX3 = bufX * stepx;//верхняя правая
            //int coordinataY3 = bufY * stepy + stepy;

            //int coordinataX4 = bufX * stepx + stepx;//нижняя правая
            //int coordinataY4 = bufY * stepy + stepy;

            //Graphics g = pctLineXY.CreateGraphics();
            //Pen pn = new Pen(Color.Blue, 3);
            //g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
            //g.DrawLine(pn, coordinataX3, coordinataY3, coordinataX2, coordinataY2);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void btnClickThis_Click(object sender, EventArgs e) // При нажатии кнопки идёт разлиновка поля и БОЛЬШЕ НИЧЕГО
        {
            lblHelloWorld.Text = " Разметка завершенна !";
            lblHelloWorld.ForeColor = System.Drawing.Color.BlueViolet;
            int width = pctLineXY.Width;
            int height = pctLineXY.Height;
            int stepW = width / 10;
            int stepH = height / 10;
            int countW = width / stepW;
            int countH = height / stepH;
            int buffposX = 0;
            int buffposY = 0;
            int buffposX1 = 0;
            int buffposY1 = 0;
            int buffposNull = 0;

            var pct = pctLineXY;   //Экземпляр пикчербокса
            pct.MouseClick += pctLineXY_MouseClick; // подписка на клик или что то в этом роде

            Graphics g = pctLineXY.CreateGraphics();
            Pen pn = new Pen(Color.Black, 2);

            for (int i = 0; i <= countW; i++) //разлиновка поля
            {
                g.DrawLine(pn, buffposX, buffposY, buffposX, height);
                buffposX += stepW;
            }
            for (int i = 0; i <= countH; i++)
            {
                g.DrawLine(pn, buffposNull, buffposY1, width, buffposX1);
                buffposY1 += stepH;
                buffposX1 += stepH;
            }

        }

        private void lblHelloWorld_Click(object sender, EventArgs e)
        {

        }

        private void pct_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        public void ChertaGorizonta() // Метод для определения победы (НЕ НАПИСАН)
        {

        }
        


        
        public void BotHodit() //ход бота
        {

            int width = pctLineXY.Width;
            int height = pctLineXY.Height;

            Random rnd = new Random();

            int xHod = rnd.Next(0, width);
            int yHod = rnd.Next(0, height);

            //int stepx = width / 10; //ширина ячейки 
            //int stepy = height / 10;// высота ячейки
            //int hx = xHod/stepx;
            //int hy = yHod/stepy;

            //if (buffDatas[hx, hy] == "-")
            //{
            //    botNuLLik(xHod, yHod);
            //}

            if (radioButton1.Checked == true)
            {
               // botNuLLik(xHod, yHod);
            }
            else
            {
               // botKrestik(xHod, yHod);
            }

           

        }
        //public void botNuLLik(int x, int y) // Метод для Нолика
        //{
        //    int width = pctLineXY.Width;
        //    int height = pctLineXY.Height;
        //    int stepx = width / 10; //ширина ячейки 
        //    int stepy = height / 10;// высота ячейки
        //    int bufX = x / stepx; //количество целых ячеек
        //    int bufY = y / stepy;
        //    int coordinataX = bufX * stepx + (stepx / 2);
        //    int coordinataY = bufY * stepy + (stepy / 2);

        //    Graphics g = pctLineXY.CreateGraphics();
        //    Pen pn = new Pen(Color.Brown, 3);

        //    if (buffDatas[bufX, bufY] == "x" || buffDatas[bufX, bufY] == "0")
        //    {

        //        MessageBox.Show("<bot> - Выберите другую клетку");
        //        pravoHoda = false;// 
        //                          //пробуем сгенерить новые координаты для хода
        //        int w = pctLineXY.Width;
        //        int h = pctLineXY.Height;
        //        Random rnd = new Random();
        //        int xH = rnd.Next(0, w);
        //        int yH = rnd.Next(0, h);
        //        buffDatas[xH, yH] = "0";
        //    }
        //    else
        //    {
        //        g.DrawEllipse(pn, coordinataX - 17, coordinataY - 17, 34, 34);
        //        buffDatas[bufX, bufY] = "0";
        //    }

        //}
        //public void botKrestik(int x, int y)
        //{
        //    int width = pctLineXY.Width;
        //    int height = pctLineXY.Height;
        //    int stepx = width / 10; //ширина ячейки 
        //    int stepy = height / 10;// высота ячейки
        //    int bufX = x / stepx; //количество целых ячеек
        //    int bufY = y / stepy;

        //    int coordinataX1 = bufX * stepx;//верхняя левая
        //    int coordinataY1 = bufY * stepy;

        //    int coordinataX2 = bufX * stepx + stepx;//верхняя правая
        //    int coordinataY2 = bufY * stepy;

        //    int coordinataX3 = bufX * stepx;//верхняя правая
        //    int coordinataY3 = bufY * stepy + stepy;

        //    int coordinataX4 = bufX * stepx + stepx;//нижняя правая
        //    int coordinataY4 = bufY * stepy + stepy;

        //    Graphics g = pctLineXY.CreateGraphics();
        //    Pen pn = new Pen(Color.Blue, 3);
        //    if (buffDatas[bufX, bufY] == "x" || buffDatas[bufX, bufY] == "0")
        //    {
        //        MessageBox.Show("<bot> - Выберите другую клетку");
        //    }
        //    else
        //    {
        //        g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
        //        g.DrawLine(pn, coordinataX3, coordinataY3, coordinataX2, coordinataY2);
        //        buffDatas[bufX, bufY] = "x";
        //    }

        //}

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Крестик
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // Нолик
        {

        }

        private void pctLineXY_Click(object sender, EventArgs e) // событие клика по пикчербоксу - пока отключено
        {
            //int width = pctLineXY.Width;
            //int height = pctLineXY.Height;
            //int stepW = width / 10;
            //int stepH = height / 10;
            //int countW = width / stepW;
            //int countH = height / stepH;
            //int buffposX = 0;
            //int buffposY = 0;
            //int buffposX1 = 0;
            //int buffposY1 = 0;
            //int buffposNull = 0;

            //// var pct = pctLineXY;   //Экземпляр пикчербокса
            ////  pct.MouseClick += pctLineXY_MouseClick; // подписка на клик или что то в этом роде
            //Graphics g = pctLineXY.CreateGraphics();
            //Pen pn = new Pen(Color.Black, 2);

            //for (int i = 0; i <= countW; i++)
            //{
            //    g.DrawLine(pn, buffposX, buffposY, buffposX, height);
            //    buffposX += stepW;

            //}
            //for (int i = 0; i <= countH; i++)
            //{
            //    g.DrawLine(pn, buffposNull, buffposY1, width, buffposX1);
            //    buffposY1 += stepH;
            //    buffposX1 += stepH;

            //}
        }


    }
}

