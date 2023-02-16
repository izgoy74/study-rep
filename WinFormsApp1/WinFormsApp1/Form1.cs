using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //данный метод будет выполняться когда форма загрузится 
            //необходимо ограничить значения в выборе даты взятия кредита 
            begindate.MinDate = DateTime.Today;
            begindate.MaxDate = DateTime.Today.AddMonths(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Получаем данные для создания объекта, создаём объект, вызвать метод Print для отображения результатов на форме
            string alastname = lastname.Text;
            double asumma = Convert.ToDouble(summa.Value);
            double aprocent = Convert.ToDouble(procent.Value);
            int amonths = Convert.ToInt32(months.Value);
            DateTime a = begindate.SelectionRange.Start;

             BankCounter bc = new BankCounter(a, alastname, asumma, aprocent, amonths);
            bc.Print(result, monthspay, enddate, history);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //очищаем историю - richtextbox 
            history.Text = "";
            result.Text = "";
            monthspay.Text = "";
        }

        private void begindate_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
