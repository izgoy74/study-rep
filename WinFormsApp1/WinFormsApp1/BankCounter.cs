using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class BankCounter
    {
        string Lastname = "No name";
        double Summa = 0;
        double Procent = 0;
        int Months = 1;
        DateTime Begindate;
        //Конструктор
        public BankCounter(DateTime begindate, string lastname = "No name", double summa = 0, double procent = 0, int months = 1)
        {
            Lastname = (lastname.Length > 0) ? lastname.Substring(0, 1).ToUpper() + lastname.Substring(1).ToLower() : "Иванов Иван";
            Summa = (summa >= 0) ? summa : 0;
            Procent = (procent >= 0) ? procent : 0;
            Months = (months > 1) ? months : 1;
            Begindate = begindate;
            //Дописать
        }
        //Методы
        public DateTime Enddate()
        {
            return Begindate.AddMonths(Months);
        }

        public double Result()
        {
            double result = Summa;
            for (int i = 0; i < Months; i++)
                result += Summa * (Procent / 12.0);

            return result;
        }

        public double Monthpay()
        {
            return Result() / Months;
        }

        public void Print(TextBox textresult, TextBox textmonthspay, DateTimePicker enddate, RichTextBox history)
        {
            textresult.Text = Convert.ToString(Result());
            textmonthspay.Text = Convert.ToString(Monthpay());
            enddate.Value = Enddate();
            string s = $"\n\nИмя вкладчика: {Lastname}\tДата начала кредитования: {Begindate}\tДата оконсания кредитования: {Enddate()}\tКредит на сумму: {Summa:F4}\tИтоговая сумма: {Result():F4}\tПлатёж: {Monthpay():F4}";
            history.AppendText(s);
        }
    }
}
