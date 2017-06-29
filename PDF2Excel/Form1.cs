using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using PDFMosaic;
using System.Text;
using System.Text.RegularExpressions;

namespace PDF2Excel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        public string lineread = "";
        string readValue = "";
        string file_name;
        string fileread = "  ";
      

        int totLine;
        int linecout;
        String conv_Text = "";
        string po_value;
        string start_value;
        string cancel_value;
        string style_value;
        string ross_value;
        string storePath;
        string noSpace;
       

        string descript_value;
        string label_value;
        string price_value;
        string unit_value;
        string preticket_value;
       

        public List<string> PO = new List<string>();
        public List<string> start = new List<string>();
        public List<string> cancel = new List<string>();
        public List<string> style = new List<string>();
        public List<string> item = new List<string>();
        public List<string> descript = new List<string>();
        public List<string> label = new List<string>();
        public List<string> cost = new List<string>();
        public List<string> units = new List<string>();
        public List<string> pretickets = new List<string>();

        private void BrowseFile_Click(object sender, EventArgs e)
        {

            file_out.Text = "  ";
            fileread = " ";
            readValue = " ";
            lineread = " ";

            file_out.Show();
            dataGridView1.Hide();

            //add extension filter etc
            // openFileDialog.Filter = "pdf files (*.pdf)|*.pdft|All files (*.*)|*.*";
            openFileDialog.Filter = "Pdf Files|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                foreach (var file in openFileDialog.FileNames)
                {
                    //Transform the list to a better presentation if needed
                    //Below code just adds the full path to list
                    pdfFile.Items.Add(file);

                    //Or use below code to just add file names
                    //pdfFile.Items.Add (Path.GetFileName (file));
                    //  file_name = Path.GetFileName(file);

                }
                file_name = Path.GetFileName(pdfFile.Items[0].ToString());
                storePath = pdfFile.Items[0].ToString();

                exportName.Text = storePath.Substring(0, storePath.IndexOf(file_name));



            }
            processData();



        }

        static string RemoveMultipleSpaces(string s)
        {

            StringBuilder result = new StringBuilder();
            bool wasLastSpace = false;

            for (int i = 0; i < s.Length; i++)
            {

                char c = s[i];

                if (c != ' ' || !wasLastSpace)
                    result.Append(c);

                wasLastSpace = (c == ' ');

            }

            return result.ToString();

        }

        private void CopyWithProgress(int filesizes)
        {
            // Display the ProgressBar control.
            progressBar.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            progressBar.Maximum = filesizes;
            // Set the initial value of the ProgressBar.
             progressBar.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar.Step = 1;

            // Loop through all files to copy.
            for (int x = 1; x <= filesizes; x++)
            {
                // Perform the increment on the ProgressBar.
                progressBar.PerformStep();

            }
        }

        public static int SpaceCount(string str)
        {
            int spcctr = 0;
            string str1;
            for (int i = 0; i < str.Length; i++)
            {
                str1 = str.Substring(i, 1);
                if (str1 == " ")
                {
                    spcctr++;
                }


            }
            return spcctr;
        }


        void processData()
        {
            int fileNum = Int32.Parse(pdfFile.Items.Count.ToString());
            for (int i = 0; i < fileNum; i++)
            {
                file_out.Clear();
                progressBar.Value = 1;
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
                totLine = 0;
                linecout = 0;
                po_value = ""; start_value = ""; cancel_value = ""; style_value = "";
                descript_value = ""; price_value = ""; unit_value = ""; preticket_value = ""; ross_value = "";
                label_value = "";
               
                PO.Clear();
                start.Clear();
                cancel.Clear();
                style.Clear();
                item.Clear();
                descript.Clear();
                label.Clear();
                cost.Clear();
                units.Clear();
                pretickets.Clear();
                fileread = pdfFile.Items[i].ToString();

                if (fileread.Contains("PDF") || fileread.Contains("pdf"))
                {
                    //file_out.Text = ExtractTextFromPdf(fileread);
                    // file_out.Text = parseUsingPDFBox(fileread);
                    conv_Text = "";
                    file_out.Show();
                    PDFDocument document = new PDFDocument(fileread);
                    for (int j = 0; j < document.Pages.Count - 1; ++j)
                    {

                        conv_Text += document.Pages[j].GetText() + System.Environment.NewLine;
                        readValue = RemoveMultipleSpaces(conv_Text);

                       // noSpace = Regex.Replace(readValue, @"\s*(\n)", "$1");
                        noSpace = readValue.Substring(readValue.IndexOf("PO #"));
                        noSpace = noSpace.Replace("pick-up", "");
                        noSpace = noSpace.Replace("\n", String.Empty);
                        noSpace = noSpace.Replace("\r", String.Empty);
                        noSpace = noSpace.Replace("\t", String.Empty);
                        noSpace = noSpace.Replace("__________________", "");
                        noSpace = noSpace.Replace("Carton Labels DO NOT need to be changed.", "");
                        noSpace = noSpace.Replace("PAYMENT METHOD: Bulk/Flat No Hanger c. New Bill of Lading address will be required.", "");
                        noSpace = noSpace.Replace("To: Ross Distribution Center", "");
                        noSpace = noSpace.Replace("Address Information Current routing instructions available at", "");
                        noSpace = noSpace.Replace("http://partners.rossstores.com", "");
                        noSpace = noSpace.Replace("VENDOR STYLE # ITEM DESCRIPTION UNIT COST COMP RETAIL ORDER QTY COLOR NESTED PACK SIZE PACK", "");
                        noSpace = noSpace.Replace("VENDOR ITEM COMMENTS ROSS ITEM # LABEL SIZE GW LABOR SAMPLES NEED BY DATES NESTED PK QTY PREPACK", "");
                        noSpace = noSpace.Replace("GUARANTY - Vendor hereby represents that reasonable and representative tests, make in accordance with procedures prescribed and applicable standards or regulations issued, ammended or continued in effect under the Flammable Fabrics Act, as amended, show that the", "");
                        noSpace = noSpace.Replace("merchandise covered and identified by, and in the form delivered under this Purchase Order, conforms to the applicable standards or regulations issued, amended, or continued in effect.", "");
                        noSpace = noSpace.Replace("/INNER", "\n/INNER");
                        noSpace = noSpace.Replace("CODE", "\nCODE");
                        noSpace = noSpace.Replace(" ", "%");
                        noSpace = noSpace.Replace("%%", "%");
                        noSpace = noSpace.Replace("%%%", "%");

                        file_out.Text = noSpace;

                    }


                    foreach (string lines in file_out.Lines)
                    {
                        totLine++;
                        if (lines.Contains("PO%#:"))
                        {
                            po_value = getBetween(lines, "PO%#:%", "%Style");
                            PO.Add(po_value);
                           
                            start_value = lines.Substring(lines.IndexOf("%b.") + 13, 8);
                            start.Add(start_value);
                           
                            cancel_value = lines.Substring(lines.IndexOf(start_value) + 9, 8);
                            cancel.Add(cancel_value);
                           

                            String pre_value = getBetween(lines, cancel_value, "%Open");
                            preticket_value = pre_value.Replace("%", " ");
                            pretickets.Add(preticket_value);
                           

                        }
                        if (lines.Contains("CODE%"))
                        {
                            linecout++;
                            style_value = getBetween(lines, "CODE%", "%");
                            // 
                            style.Add(style_value);
                            

                            string des = getBetween(lines, style_value, ".");
                            des = des.Substring(0, des.Length - 2);
                           /// MessageBox.Show(des);
                            descript_value = des.Replace("%", " ");
                            descript.Add(descript_value);
                            string hel = des + "%";
                            hel = hel.Replace("%%", "%");
                            price_value = getBetween(lines, hel, "%");
                            cost.Add(price_value);
                            //MessageBox.Show(price_value);



                            string valbtw = getBetween(lines, price_value + "%", "%");

                            unit_value = getBetween(lines, valbtw + "%", "%");

                            units.Add(unit_value);
                           

                        }

                        if (lines.Contains("/INNER"))
                        {

                            string ross = getBetween(lines, "/INNER%", "%");


                            if (isNumeric(ross) == true)
                            {

                                ross_value = ross;
                                item.Add(ross_value + "i");

                                label_value = getBetween(lines, ross_value + "%", "%");

                                label.Add(label_value);
                               
                            }
                            else
                            {
                                ross_value = ross;
                                item.Add("-");
                                label_value = ross;

                                label.Add(label_value);
                            }
                        }


                        while (PO.Count <= linecout)
                        {
                            PO.Add(po_value);

                        }
                        while (start.Count <= linecout)
                        {

                            start.Add(start_value);
                        }
                        while (cancel.Count <= linecout)
                        {

                            cancel.Add(cancel_value);


                        }
                        while (pretickets.Count <= linecout)
                        {

                            pretickets.Add(preticket_value);


                        }


                    }

                    dataGridView1.Show();
                    dataGridView1.DataSource = ExportToExcel();
                }
                else
                {
                    MessageBox.Show("Invalid file type" + fileread);
                }
                createExcell();

               // MessageBox.Show("Excel file for " + po_value + " is created");
                convertedFile.Items.Add(po_value + ".xlsx");

            }
            MessageBox.Show("Conversion complete");


        }
         public static bool isNumeric(string str)
        {
            foreach(char c in str)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
               
            }
            return false;

        }

        public System.Data.DataTable ExportToExcel()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("PO#", typeof(string));
            table.Columns.Add("Start Date", typeof(string));
            table.Columns.Add("Cancel Date", typeof(string));
            table.Columns.Add("Vendor Style", typeof(string));
            table.Columns.Add("Ross item", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Label", typeof(string));
            table.Columns.Add("Cost", typeof(string));
            table.Columns.Add("Units", typeof(string));
            table.Columns.Add("Preticket ", typeof(string));

            for (int i = 0; i < linecout; i++)
            {
                table.Rows.Add(PO[i], start[i], cancel[i], style[i], item[i], descript[i], label[i], cost[i], units[i], pretickets[i]);

            }
            return table;
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }


        void createExcell()
        {

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
            Microsoft.Office.Interop.Excel.Range celLrangE;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);


                worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = openFileDialog.SafeFileName.ToString();

                int rowcount = 1;

                foreach (DataRow datarow in ExportToExcel().Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= ExportToExcel().Columns.Count; i++)
                    {

                        if (rowcount == 3)
                        {
                            worKsheeT.Cells[1, i] = ExportToExcel().Columns[i - 1].ColumnName;
                            worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        worKsheeT.Cells[rowcount, i] = datarow[i - 1].ToString();


                        if (rowcount > 3)
                        {
                            if (i == ExportToExcel().Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    celLrangE = worKsheeT.Range[worKsheeT.Cells[rowcount, 1], worKsheeT.Cells[rowcount, ExportToExcel().Columns.Count]];
                                }

                            }
                        }

                    }

                }


                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, ExportToExcel().Columns.Count]];
                celLrangE.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, ExportToExcel().Columns.Count]];

                worKbooK.SaveAs(exportName.Text.ToString() + po_value);
                for (int i = 0; i <= 10; i++)
                {
                    CopyWithProgress(totLine);
                }
                worKbooK.Close();
                excel.Quit();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                worKsheeT = null;
                celLrangE = null;
                worKbooK = null;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            file_out.Hide();

        }

        private void but_del_Click(object sender, EventArgs e)
        {

            if (pdfFile.SelectedItems.Count != 0)
            {
                while (pdfFile.SelectedIndex != -1)
                {
                    pdfFile.Items.RemoveAt(pdfFile.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Please select file to be delete");
            }
        }

        private void clear_list_Click(object sender, EventArgs e)
        {
            file_out.Clear();
            progressBar.Value = 1;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            convertedFile.Items.Clear();
            pdfFile.Items.Clear();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

