using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lab1
{//класс предназначен для хранения точек ломаной линии и отображения ломаной линни на picturebox 
    public class Breakline
    {
        //поля 
        Point[] points = null;
        int N = 0;
        int maxN = 0; //переделать 
        //конструктор
        public Breakline(DataGridView data, int n = 50)
        {
            maxN = n; //выделяем память для массива
            points = new Point[maxN];
            //настраиваем таблицу для вывода координат точек
            data.ColumnCount = 2;
            data.RowCount = 0;
            data.Columns[0].HeaderText = "X";
            data.Columns[1].HeaderText = "Y";

        }
        //методы 

        //добавление точки в ломаную линию 
        public void addPoint(DataGridView data, int x, int y)
        {
            //добавляем координаты точки в массив 
            points[N] = new Point(x, y);//добавляем строчку в таблицу данных datagridview
            data.Rows.Add();
            data.Rows[N].Cells[0].Value = x;
            data.Rows[N].Cells[1].Value = y;
            N++;
        }


        //метод для рисования ломаной линии
        public void draw(PictureBox pbox)
        {
            //проверяем количество точек в ломаной 
            if (N > 0)
            {
                //для picturebox создаем полтно на котором будем рисовать 
                Graphics gr = pbox.CreateGraphics();
                //созадем карандаш для рисования
                Pen pen = new Pen(Color.Black, 2.1f);
                //рисуем точки 
                foreach(var a in points)
                {
                    gr.DrawEllipse(pen, a.X - 5, a.Y - 5, 10,10);
                }
                //рисуем отрезки для ломаной
                for (int i = 1; i < N; i++)
                {
                    gr.DrawLine(pen, points[i - 1], points[i]);
                }
            }
        }
    }
}
