using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace WindowsFormsNote
{
    public partial class FormNote : Form
    {
        DateTime[] dataArr = new DateTime[100];
        List<object> birthDates = new List<object>();
        List<object> appointmentDates = new List<object>();
        public FormNote()
        {
            InitializeComponent();
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            monthCalendar.MaxSelectionCount = 1;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;


        }
        private void FormNote_Load(object sender, EventArgs e)
        {
            monthCalendar.TodayDate = DateTime.Today;

        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar.BoldedDates = dataArr;//сделать жирными все даты что попали в массив dataArr
            textBox1.Text = this.monthCalendar.SelectionRange.Start.ToShortDateString();

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            labelInput.Text = $"\nВы выбрали: { dateTimePicker1.Text}";
        }
       
            private void buttonAdd_Click(object sender, EventArgs e)//добавить событие 
            {
                var dt = monthCalendar.SelectionRange.Start;
                var txt = textBox1.Text;
                var сalendatTime = new CalendatTime(dt, txt);
            if (checkBoxB.Checked) { 
                birthDates.Add(сalendatTime);
                addArr(dt);
            }
            if (checkBoxA.Checked)
            {
                appointmentDates.Add(сalendatTime);
                addArr(dt);
            }
               
            }

            private void buttonView_Click(object sender, EventArgs e)//посмотреть заметки
            { 
            textBox1.Text = "";
            if (checkBoxB.Checked)
            {
                foreach (var item in birthDates)
                {
                    textBox1.Text += ((CalendatTime)item).Print();
                }
            }
            if (checkBoxA.Checked)
            {
                foreach (var item in appointmentDates)
                {
                    textBox1.Text += ((CalendatTime)item).Print();
                }
            }
            }

            private void buttonClean_Click(object sender, EventArgs e)// кнопка очистить
            {
                textBox1.Text = "";
            }

        private void addArr(DateTime date)//заполнение массива дат, чтобы в дальнейшем их зажирнить
        {
            
            for (int i = 0; i < dataArr.Length; i++)
            {
                dataArr[i] = date;
            }
        }
        }
    } 

