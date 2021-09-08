using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsIndiv
{
    public partial class Form1 : Form
        //Здравствуйте!Данную работу выполнил Минайлов Олег Студент 12 группы 
        //Данная программа(код) является шифратором,он шифрует некоторые символы,буквы и цифры,можно вводить данные
        //как с клавиатуры ,так и с помощью текстового файла
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool ValidCharFound(string str)//функция проверки наличия только символовцифр и , в //строке
            {
                bool valid = true;// возвращаемый результат
                foreach (char c in str) // искать символ c в строке str
                {
                    string bfr = c.ToString();// конвертировать с в строку
                    if (Regex.IsMatch(bfr, @"[0-9,]"))//если в строке только
                    {
                        valid = true;//то результат=истина
                    }
                    else
                    {
                        valid = false;//иначе ложь
                        break;
                    }
                }
                return valid;
            }
            if (textBox3.Text != null && textBox3.Text != "")
            {
                if (ValidCharFound(textBox3.Text))    //проверка на правильность 
                                                      //введенных данных
                { }
                else
                    MessageBox.Show("Введите ключ шифрования(он состоит из цифер)", "Ошибка", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); //кнопка выхода из программы
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  //Диалоговое окно с загрузкой данных
            {
                Name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(Name);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Удаление данных
            MessageBox.Show("Данные были удалены", "Удаление данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)  //Диалоговое окно с сохранением данных
            {
                Name = saveFileDialog1.FileName;
                File.WriteAllText(Name, textBox2.Text);
            }
        }

        static string ABC = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789?!()-"; //Наши используемые буквы,цифры и символы

        private void button3_Click(object sender, EventArgs e)
        {

            textBox2.Text = ooo(textBox1.Text);
        }
        public string ooo(string inp)
        {
            StringBuilder cipher = new StringBuilder();

            string a = textBox1.Text;          //Шифрование кода
            int b = 1;

            for (int i = 0; i < a.Length; i++)
                for (int e = 0; e < ABC.Length; e++)
                    if (a[i] == ABC[e]) cipher.Append(ABC[(e + b + ABC.Length) % ABC.Length]);
            textBox1.Clear();
            return cipher.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = ooo0(textBox2.Text);
            }
             string ooo0(string inp)
            {

                StringBuilder code = new StringBuilder();

                string a = textBox2.Text;
                int b = 8;
                for (int i = 0; i < a.Length; i++)
                    for (int x=0; x < ABC.Length; x++)
                        if (a[i] == ABC[x]) code.Append(ABC[(x - b + ABC.Length) % ABC.Length]);

                textBox2.Clear();
                return code.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHelp f2 = new FormHelp();        //Возможность нажимать на кнопки с выводом доп.окон
            f2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormHints f3 = new FormHints();   ////Возможность нажимать на кнопки с выводом доп.окон
            f3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormAnswerOnOurQuestions f4 = new FormAnswerOnOurQuestions();  //Возможность нажимать на кнопки с выводом доп.окон
            f4.Show();
        }
    }
}