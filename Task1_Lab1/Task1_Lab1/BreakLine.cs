using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Task1_Lab1
{
    //Класс предназначен для хранения точек ломаной линии и отображения ломаной линии на pbox
    public class BreakLine
    {
        //Поля
        Point[] points = null;
        int End = 0;
        int MaxEnd = 0; //Переделать
        Color color = Color.Red;
        //Конструктор
        public BreakLine(DataGridView data, int n = 50)
        {
            MaxEnd = n; //Выделяем память для массива
            points = new Point[MaxEnd];
            //Настраиваем таблицу для вывода координат точкам
            data.ColumnCount = 2;
            data.RowCount = 1;
            data.Columns[0].HeaderText = "X";
            data.Columns[1].HeaderText = "Y";
        }
        //Методы
        //Добавление точки в ломаную линию
        public void AddPoint(DataGridView data, int x, int y)
        {
            //Добавляем координаты точки в массив
            points[End] = new Point(x, y);
            //Добавляем строчку в таблицу данных dgv
            data.Rows.Add();
            data.Rows[End].Cells[0].Value = x;
            data.Rows[End].Cells[1].Value = y;
            End++;
        }
        //Метод для рисования ломаной линии
        public void Draw(PictureBox pbox)

        {
            //Проверяем кол-во точек в ломаной
            if (End > 0)
            {
                //Для pbox создаём полотно, на котором будем рисовать
                Graphics gr = pbox.CreateGraphics();
                gr.Clear(pbox.BackColor);
                //Создаём карандаш для рисования
                Pen pen = new Pen(color, 2.1f);
                //Рисуем точки
                foreach (var a in points)
                {
                    gr.DrawEllipse(pen, a.X - 5, a.Y - 5, 10, 10);
                }
                //Рисуем отрезки для ломаной
                for (int i = 1; i < End; i++)
                {
                    gr.DrawLine(pen, points[i - 1], points[i]);
                }
            }
        }
        //метод для очистки datagritviewe
     public void gridclear(DataGridView data)
    {
        data.ColumnCount = 2;
        data.RowCount = 1;
        data.Columns[0].HeaderText = "X";
        data.Columns[1].HeaderText = "Y";
    }
        //метод для изменения цвета ломаной линии 
        public void setcolor(Color color)
        {
            this .color = color;
        }
}
}
