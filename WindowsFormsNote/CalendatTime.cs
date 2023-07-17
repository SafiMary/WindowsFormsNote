using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsNote
{
    internal class CalendatTime
    {
       
            DateTime dateTime;
            string text;
            public CalendatTime(DateTime date)
            {
                this.dateTime = date;
                text = string.Empty;
            }
            public CalendatTime(DateTime date, string text)
            {
                this.dateTime = date;
                this.text = text;
            }
            public void addText(string txt)
            {
                this.text += txt;
            }
            public string Print()
            {
                return dateTime.ToString("yyyy-MM-dd") +
                    " " + text;
            }
        }
    }

