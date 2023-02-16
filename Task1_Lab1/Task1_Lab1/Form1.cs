using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_Lab1
{
    public partial class Form1 : Form
    {   //создаем новое поле типа ломаная линия 
        BreakLine lin1;
        public Form1()
        {
            InitializeComponent();
            lin1 = new BreakLine(data, 50);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //очищаем пикбокс, датагридвью, объект класса 
            lin1 = new BreakLine(data, 50);
            pbox.CreateGraphics().Clear(pbox.BackColor);
        }

        private void pbox_Click(object sender, EventArgs e)
        {

        }

        private void pbox_MouseClick(object sender, MouseEventArgs e)
        {
            //Получаем координаты мымши для отображения точки на пбоксе 
            int x =e.X;
            int y =e.Y;
            lin1.AddPoint(data, x, y);
            lin1.Draw(pbox);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //вызываем диалоговое око для выбора цвета, изменяем цвет ломаной линии 
            palitr.ShowDialog();
            Color color = palitr.Color;
            lin1.setcolor(color);
        }
    }
}
