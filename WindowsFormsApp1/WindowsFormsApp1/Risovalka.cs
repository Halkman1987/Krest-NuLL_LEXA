using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Risovalka
    {
        
        public PictureBox pctLineXY;

        public Risovalka(PictureBox pctLineXY)
        {
           
            this.pctLineXY = pctLineXY;
        }

        public void CentrovkaNuLLika(MouseEventArgs e) // Метод для Нолика
        {
            int width = pctLineXY.Width;
            int height = pctLineXY.Height;
            int stepx = width / 10; //ширина ячейки 
            int stepy = height / 10;// высота ячейки
            int bufX = e.X / stepx; //количество целых ячеек
            int bufY = e.Y / stepy;
            int coordinataX = bufX * stepx + (stepx / 2);
            int coordinataY = bufY * stepy + (stepy / 2);
            Graphics g = pctLineXY.CreateGraphics();
            Pen pn = new Pen(Color.Red, 3);
            g.DrawEllipse(pn, coordinataX - 17, coordinataY - 17, 34, 34);

            //if (buffDatas[bufX, bufY] == "x" || buffDatas[bufX, bufY] == "0")
            //{
            //    MessageBox.Show("Выберите другую клетку");
            //    //g.DrawEllipse(pn, coordinataX - 17, coordinataY - 17, 34, 34);
            //    //buffDatas[bufX, bufY] = "0";
            //}
            //else
            //{
            //    g.DrawEllipse(pn, coordinataX - 17, coordinataY - 17, 34, 34);
            //    buffDatas[bufX, bufY] = "0";
            //}


        }
        public void CentrovkaKrestika(MouseEventArgs e) // Метод для крестика
        {
            int width = pctLineXY.Width;
            int height = pctLineXY.Height;
            int stepx = width / 10; //ширина ячейки 
            int stepy = height / 10;// высота ячейки
            int bufX = e.X / stepx; //количество целых ячеек
            int bufY = e.Y / stepy;

            int coordinataX1 = bufX * stepx;//верхняя левая
            int coordinataY1 = bufY * stepy;

            int coordinataX2 = bufX * stepx + stepx;//верхняя правая
            int coordinataY2 = bufY * stepy;

            int coordinataX3 = bufX * stepx;//верхняя правая
            int coordinataY3 = bufY * stepy + stepy;

            int coordinataX4 = bufX * stepx + stepx;//нижняя правая
            int coordinataY4 = bufY * stepy + stepy;

            Graphics g = pctLineXY.CreateGraphics();
            Pen pn = new Pen(Color.Blue, 3);
            g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
            g.DrawLine(pn, coordinataX3, coordinataY3, coordinataX2, coordinataY2);
            
            //if (buffDatas[bufX, bufY] == "x" || buffDatas[bufX, bufY] == "0")
            //{
            //    MessageBox.Show("Выберите другую клетку");
            //}
            //else
            //{
            //    g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
            //    g.DrawLine(pn, coordinataX3, coordinataY3, coordinataX2, coordinataY2);
            //    //buffDatas[bufX, bufY] = "x";
            //}

        }
    }
}
