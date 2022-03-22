using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWE_4202_Lab_Final
{
    public partial class Form1 : Form
    {
        List<string> ID = new List<string>();
        List<string> Student_Name = new List<string>();
        List<string> Attendance = new List<string>();
        List<string> Quiz_1 = new List<string>();
        List<string> Quiz_2 = new List<string>();
        List<string> Quiz_3 = new List<string>();
        List<string> Quiz_4 = new List<string>();
        List<string> Mid = new List<string>();
        List<string> Final = new List<string>();
        List<string> Viva = new List<string>();
        List<int> Total_Marks = new List<int>();
        int[] total;

        public Form1()
        {
            InitializeComponent();
            using (var reader = new StreamReader(@"D:\SWE4201MarkSheet.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    ID.Add(values[0]);
                    Student_Name.Add(values[1]);
                    Attendance.Add(values[2]);
                    Quiz_1.Add(values[3]);
                    Quiz_2.Add(values[4]);
                    Quiz_3.Add(values[5]);
                    Quiz_4.Add(values[6]);
                    Mid.Add(values[7]);
                    Final.Add(values[8]);
                    Viva.Add(values[9]);
                }
                reader.Close();

                string dummy = ID[0] + "\t" + "\t" + Student_Name[0] + "\t" + "\t" + "\t" + "\t" + "Percentage" + "\t" + "Grade";
                Student_Info.Items.Add(dummy);

                var id_list = from id in ID
                              where id.StartsWith("2000")
                              select id;
                var name_list = from name in Student_Name
                                where !name.StartsWith("Name")
                                select name;
                var attendance = from atd in Attendance
                                 where !atd.StartsWith("\"Attendance")
                                 select atd;
                var quiz_1 = from quiz in Quiz_1
                             where !quiz.StartsWith("\"Quiz")
                             select quiz;
                var quiz_2 = from quiz in Quiz_2
                             where !quiz.StartsWith("\"Quiz")
                             select quiz;
                var quiz_3 = from quiz in Quiz_3
                             where !quiz.StartsWith("\"Quiz")
                             select quiz;
                var quiz_4 = from quiz in Quiz_4
                             where !quiz.StartsWith("\"Quiz")
                             select quiz;
                var mid_list = from mid in Mid
                               where !mid.StartsWith("\"MID")
                               select mid;
                var final_list = from final in Final
                                 where !final.StartsWith("\"Final")
                                 select final;
                var viva_list = from viva in Viva
                                where !viva.StartsWith("\"Viva")
                                select viva;

                /*int i = 0;
                foreach (var quiz in quiz_1)
                {
                    
                    total[i] = Convert.ToInt32(quiz);
                    i++;
                }
                i = 0;
                foreach (var quiz in quiz_2)
                {

                    total[i] += Convert.ToInt32(quiz);
                    i++;
                }
                i = 0;
                foreach (var quiz in quiz_3)
                {

                    total[i] += Convert.ToInt32(quiz);
                    i++;
                }
                i = 0;
                foreach (var mid in mid_list)
                {

                    total[i] += Convert.ToInt32(mid);
                    i++;
                }
                i = 0;
                foreach (var final in final_list)
                {

                    total[i] += Convert.ToInt32(final);
                    i++;
                }
                i = 0;
                foreach (var viva in viva_list)
                {

                    total[i] += Convert.ToInt32(viva);
                    i++;
                }*/

                for (int j=1;j<ID.Count();j++)
                {
                    string dum = ID[j] + "\t" + Student_Name[j]/* + "\t" + total[j]*/;
                    Student_Info.Items.Add(dum);
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Search(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Student_ID_Input.Text);

        }
    }
}
