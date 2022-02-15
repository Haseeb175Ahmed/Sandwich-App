using MFilesAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandwich_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(fromDate.Text);
            DateTime ToDate = Convert.ToDateTime(toDate.Text);

            var listDates = GetGazettedHolidays();

            int SandwichLeaves = 0;
            int Leaves = 0;


            for (DateTime date = FromDate; ToDate.CompareTo(date) >= 0; date = date.AddDays(1.0))
            {
                if (listDates.Contains(date) || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    SandwichLeaves++;
                }
                else
                {
                    Leaves++;
                }
            }

            LeaveswithSandwich.Text = (SandwichLeaves + Leaves).ToString();
            LeaveswithoutSandwich.Text = Leaves.ToString();

        }



        public static List<DateTime> GetGazettedHolidays()
        {
            List<DateTime> GazettedHolidays = new List<DateTime>();

            try
            {
                DateTime KashmirDay = new DateTime(2022, 02, 05);
                DateTime PakistanDay = new DateTime(2022, 03, 23);
                DateTime LabourDay = new DateTime(2022, 05, 01);
                DateTime Eid_ul_Fitr_Starts = new DateTime(2022, 05, 03);
                DateTime Eid_ul_Fitr_Ends = new DateTime(2022, 05, 05);
                DateTime Eid_ul_Azha_Starts = new DateTime(2022, 07, 10);
                DateTime Eid_ul_Azha_Ends = new DateTime(2022, 07, 12);
                DateTime Ashura_9th = new DateTime(2022, 08, 07);
                DateTime Ashura_10th = new DateTime(2022, 08, 08);
                DateTime IndependenceDay = new DateTime(2022, 08, 14);
                DateTime Eid_Milad_un_Nabi = new DateTime(2022, 10, 09);
                DateTime Quaid_e_Azam_Day_Christmas = new DateTime(2022, 12, 25);


                GazettedHolidays.Add(KashmirDay);
                GazettedHolidays.Add(PakistanDay);
                GazettedHolidays.Add(LabourDay);
                for (DateTime date = Eid_ul_Fitr_Starts; Eid_ul_Fitr_Ends.CompareTo(date) >= 0; date = date.AddDays(1.0))
                {
                    GazettedHolidays.Add(date);
                }

                for (DateTime date1 = Eid_ul_Azha_Starts; Eid_ul_Azha_Ends.CompareTo(date1) >= 0; date1 = date1.AddDays(1.0))
                {
                    GazettedHolidays.Add(date1);
                }

                GazettedHolidays.Add(Ashura_9th);
                GazettedHolidays.Add(Ashura_10th);
                GazettedHolidays.Add(IndependenceDay);
                GazettedHolidays.Add(Eid_Milad_un_Nabi);
                GazettedHolidays.Add(Quaid_e_Azam_Day_Christmas);

            }
            catch (Exception ex)
            {

                throw;
            }

            return GazettedHolidays;
        }
    }
}
