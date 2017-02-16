using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace DataTest
{
    public partial class Form1 : Form
    {

        int q = 0;
        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
        List<string> values = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gridview.RowHeadersVisible = false;
            
            button1.Enabled = false;
            button1.Hide();
            button2.Enabled = false;
            button2.Hide();

            if (File.Exists("AppData Dont Delete.xml"))
            {
                
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("AppData Dont Delete.xml", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                Information info = (Information)xs.Deserialize(read);
             
                int a = 0;
                int b = 1;
                int c = 2;
                int d = 3;
                int f = 4;
                int cal = info.NewList.Count();
                int cal1 = cal / 5;
                int cal2 = cal1 - 1;
                // if()
                if (cal2 == 0)
                {
                    Gridview.Rows.Add(1);
                }
                else
                {
                    Gridview.Rows.Add(cal2);
                }
                try
                {
                    for (int i = 0; i < cal2; i++)
                    {

                        if (info.NewList[a] == "") { info.NewList[a] = "False"; }
                        DataGridViewRow selectedRow = Gridview.Rows[i];
                        selectedRow.Cells["WorkState"].Value = info.NewList[a];
                        selectedRow.Cells["WorKNumber"].Value = info.NewList[b];
                        selectedRow.Cells["WorkName"].Value = info.NewList[c];
                        selectedRow.Cells["StartDate"].Value = info.NewList[d];
                        selectedRow.Cells["EndDate"].Value = info.NewList[f];
                        a = a + 5;
                        b = b + 5;
                        c = c + 5;
                        d = d + 5;
                        f = f + 5;

                    }
                     a = 0;
                     b = 1;
                     c = 2;
                     d = 3;
                     f = 4;

                    dataGridView1.Rows.Add(((info.NewList2.Count/4)-1));
                    for (int i = 0; i < info.NewList2.Count/4; i++)
                    {
                       // if (info.NewList2[a] == "") { info.NewList2[a] = "False"; }
                        DataGridViewRow selectedRow = dataGridView1.Rows[i];
                       // selectedRow.Cells["WorkState"].Value = info.NewList[a];
                        selectedRow.Cells["Number"].Value = info.NewList2[a];
                        selectedRow.Cells["Name"].Value = info.NewList2[b];
                        selectedRow.Cells["Start"].Value = info.NewList2[c];
                        selectedRow.Cells["End"].Value = info.NewList2[d];
                        a = a + 4;
                        b = b + 4;
                        c = c + 4;
                        d = d + 4;
                    }

                        // Gridview.Rows.Add(i,info.NewList[i]);
                }
                catch { }
                read.Close();
                //  Gridview.Rows.Add(false, "34324");
            }
        }

        private void Gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                 }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Gridview.SelectedCells.Count > 0)
            {
                int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
               // Gridview.Rows.RemoveAt(selectedrowindex);
                DataGridViewRow selectedRow = Gridview.Rows[selectedrowindex];
                selectedRow.Cells["WorkNumber"].Value = "";
                string a = Convert.ToString(selectedRow.Cells["WorkNumber"].Value);
                string s = Convert.ToString(selectedRow.Cells["WorkName"].Value);
                string m = Convert.ToString(selectedRow.Cells["StartDate"].Value);
                string k = Convert.ToString(selectedRow.Cells["EndDate"].Value);

                //MessageBox.Show(a);
                //MessageBox.Show(s);
                }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            // string[,] val;
            Information info = new Information();
            for (int i = 0; i < Gridview.Rows.Count; i++) {

                int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
                // Gridview.Rows.RemoveAt(selectedrowindex);
                DataGridViewRow selectedRow = Gridview.Rows[i];
                // selectedRow.Cells["WorkNumber"].Value = "";

        info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkState"].Value));
        info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkNumber"].Value));
        info.NewList.Add (Convert.ToString(selectedRow.Cells["WorkName"].Value));
          info.NewList.Add( Convert.ToString(selectedRow.Cells["StartDate"].Value));
            info.NewList.Add( Convert.ToString(selectedRow.Cells["EndDate"].Value));
                
            }
           // File.WriteAllText("data.xml", "");
            SaveXML.SaveData(info, "AppData Dont Delete.xml");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // string[,] val;
            Information info = new Information();
            for (int i = 0; i < Gridview.Rows.Count; i++)
            {

                int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
                // Gridview.Rows.RemoveAt(selectedrowindex);
                DataGridViewRow selectedRow = Gridview.Rows[i];
                // selectedRow.Cells["WorkNumber"].Value = "";

                info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkState"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkNumber"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkName"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["StartDate"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["EndDate"].Value));
            }
            // File.WriteAllText("data.xml", "");
            SaveXML.SaveData(info, "AppData Dont Delete.xml");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
                // Gridview.Rows.RemoveAt(selectedrowindex);
                DataGridViewRow selectedRow = dataGridView1.Rows[i];
                // selectedRow.Cells["WorkNumber"].Value = "";

                info.NewList2.Add(Convert.ToString(selectedRow.Cells["Number"].Value));
               // info.NewList2.Add(Convert.ToString(selectedRow.Cells["WorkNumber"].Value));
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["Name"].Value));
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["Start"].Value));
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["End"].Value));
            }
            // File.WriteAllText("data.xml", "");
            SaveXML.SaveData(info, "AppData Dont Delete.xml");

            MessageBox.Show("Saved Successfully", "Saved", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
        private void ExitButton()
        {
            // string[,] val;
            Information info = new Information();
            for (int i = 0; i < Gridview.Rows.Count; i++)
            {
                int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
                // Gridview.Rows.RemoveAt(selectedrowindex);
                DataGridViewRow selectedRow = Gridview.Rows[i];
                // selectedRow.Cells["WorkNumber"].Value = "";
                info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkState"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkNumber"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["WorkName"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["StartDate"].Value));
                info.NewList.Add(Convert.ToString(selectedRow.Cells["EndDate"].Value));
            }
            // File.WriteAllText("data.xml", "");
            SaveXML.SaveData(info, "AppData Dont Delete.xml");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
                // Gridview.Rows.RemoveAt(selectedrowindex);
                DataGridViewRow selectedRow = dataGridView1.Rows[i];
                // selectedRow.Cells["WorkNumber"].Value = "";
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["Number"].Value));
                // info.NewList2.Add(Convert.ToString(selectedRow.Cells["WorkNumber"].Value));
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["Name"].Value));
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["Start"].Value));
                info.NewList2.Add(Convert.ToString(selectedRow.Cells["End"].Value));
            }
            // File.WriteAllText("data.xml", "");
            SaveXML.SaveData(info, "AppData Dont Delete.xml");
           // MessageBox.Show("OK");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /// DialogResult dial= MessageBox.Show("Works Saved","Save Works",MessageBoxButtons.OK);
            ExitButton();
                //saveToolStripMenuItem.PerformClick();
            
              Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                       saveToolStripMenuItem.PerformClick();
           
       }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            if (Gridview.SelectedCells.Count == 0)
            {
                return;
            }
            int selectedrowindex = Gridview.SelectedCells[0].RowIndex;
     
            DataGridViewRow selectedRow = Gridview.Rows[selectedrowindex];
            //  selectedRow.Cells["WorkNumber"].Value = "";
            string h = Convert.ToString(selectedRow.Cells["WorkState"].Value);
            string a = Convert.ToString(selectedRow.Cells["WorkNumber"].Value);
            string s = Convert.ToString(selectedRow.Cells["WorkName"].Value);
            string m = Convert.ToString(selectedRow.Cells["StartDate"].Value);
            string k = Convert.ToString(selectedRow.Cells["EndDate"].Value);

            dataGridView1.Rows.Add(a, s, m, k);
            q++;
            //if (q != 0)
            //{
            //    dataGridView1.Rows.Add();
            //}


          //DataGridViewRow selectedRow1 = dataGridView1.Rows[q];
            ////selectedRow1.Cells["WorkState"].Value = h;
            //selectedRow1.Cells["Number"].Value = a;
            //selectedRow1.Cells["Name"].Value = s;
            //selectedRow1.Cells["Start"].Value = m;
            //selectedRow1.Cells["End"].Value = k;
            //q+=1;
            //if (Gridview.Rows.Count == 1)
            //{

            //    return;
            //}
            try
            {
                Gridview.Rows.RemoveAt(selectedrowindex);
            }
            catch
            {

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // dataGridView1.Rows.Add();
        }

        private void Gridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // Gridview.ClearSelection();
        }

        private void Gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // Gridview.ClearSelection();
        }

        private void Gridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gridview.ClearSelection();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(selectedrowindex);
            }
            catch
            {

            }
            
            }

        private void button5_Click(object sender, EventArgs e)
        {
            int selectedrowindex = Gridview.SelectedCells[0].RowIndex;

            DataGridViewRow row = Gridview.Rows[selectedrowindex];
           // DataGridViewRow row = new DataGridViewRow();
           
            if (Convert.ToBoolean(row.Cells["WorkState"].Value))
                row.Selected = true;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new About();
            form.Show();
        }
    }
}
