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

using Tyuiu.BakhtiyarovDR.Sprint7.Project.V15.Lib;

namespace Tyuiu.BakhtiyarovDR.Sprint7.Project.V15
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        DataService ds = new DataService();
        string openFilePath;
        int cols, rows;

        private void exitToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogTable_BDR.ShowDialog();
                openFilePath = openFileDialogTable_BDR.FileName;

                string[,] arrayValues = ds.LoadFromFileData(openFilePath);
                dataGridViewTable_BDR.ColumnCount = cols = arrayValues.GetLength(1);
                dataGridViewTable_BDR.RowCount = rows = arrayValues.GetLength(0);

                for (int i = 0; i < cols; i++)
                {
                    dataGridViewTable_BDR.Columns[i].Name = arrayValues[0, i];
                }


                for (int i = 1; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        dataGridViewTable_BDR[j, i - 1].Value = arrayValues[i, j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали файл!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogTable_BDR.FileName = "DataBase.csv";
                saveFileDialogTable_BDR.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialogTable_BDR.ShowDialog();

                string path = saveFileDialogTable_BDR.FileName;

                FileInfo fileInfo = new FileInfo(path);
                bool fileExists = fileInfo.Exists;
                if (fileExists)
                {
                    File.Delete(path);
                }

                int rows = dataGridViewTable_BDR.RowCount;
                int columns = dataGridViewTable_BDR.ColumnCount;
                string header = "";
                for (int j = 0; j < columns; j++)
                {
                    if (j != columns - 1)
                    {
                        header += dataGridViewTable_BDR.Columns[j].HeaderText + ";";
                    }
                    else
                    {
                        header += dataGridViewTable_BDR.Columns[j].HeaderText;
                    }
                }
                File.AppendAllText(path, header + Environment.NewLine, Encoding.UTF8);


                for (int i = 0; i < rows; i++)
                {
                    string str = "";
                    for (int j = 0; j < columns; j++)
                    {

                        if (j != columns - 1)
                        {
                            str += dataGridViewTable_BDR.Rows[i].Cells[j].Value + ";";
                        }
                        else
                        {
                            str += dataGridViewTable_BDR.Rows[i].Cells[j].Value;
                        }
                    }
                    File.AppendAllText(path, str + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRowsToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable_BDR.Columns.Count == 0) 
            { 
                MessageBox.Show("Сначала добавьте столбцы!", "Сообщение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridViewTable_BDR.Rows.Add();
            }
        }

        private void AddColumnsToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {

            FormWriteText formWriteText = new FormWriteText();
            formWriteText.ShowDialog();

            DataGridViewColumn column = new DataGridViewTextBoxColumn();// инициализируем колонку
            column.DataPropertyName = "Name";//имя
            column.Name = DataService.Text; //заголовок колонки
            dataGridViewTable_BDR.Columns.Add(column);


        }

        private void CloseTableToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            this.dataGridViewTable_BDR.Rows.Clear();
            this.dataGridViewTable_BDR.Columns.Clear();

        }

        private void developerToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            FormAboutDeveloper formAboutDeveloper = new FormAboutDeveloper();
            formAboutDeveloper.ShowDialog();
        }

        private void RemoveRowToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            if (dataGridViewTable_BDR.CurrentRow != null)
            {
                dataGridViewTable_BDR.Rows.Remove(dataGridViewTable_BDR.CurrentRow);
            }
        }

        private void RemoveColumnToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            int CellCount = dataGridViewTable_BDR.Columns.Count - 1;
            dataGridViewTable_BDR.Columns.Remove(dataGridViewTable_BDR.Columns[CellCount]);
        }

        private void DohodToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = Convert.ToInt32(toolStripTextBoxInputColumnDohod_BDR.Text);

                toolStripTextBoxInputColumnDohod_BDR.Clear();

                // Создаем массив для хранения данных из столбца
                double[] columnData = new double[dataGridViewTable_BDR.Rows.Count];

                // Используем цикл для записи данных из столбца в массив
                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnData[i] = Convert.ToDouble(dataGridViewTable_BDR.Rows[i].Cells[columnIndex].Value);
                }

                double res = ds.SummDohod(columnData);
                textBoxOutPutData_BDR.Text = Convert.ToString(res);
            }
            catch
            {
                MessageBox.Show("Сначала введите номер столбца в раскрывающемся поле операции!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MINSumToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = Convert.ToInt32(toolStripTextBoxInputColumnMIN_BDR.Text);

                toolStripTextBoxInputColumnMIN_BDR.Clear();

                double[] columnData = new double[dataGridViewTable_BDR.Rows.Count];

                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnData[i] = Convert.ToDouble(dataGridViewTable_BDR.Rows[i].Cells[columnIndex].Value);
                }

                double res = ds.MinDohod(columnData);
                textBoxOutPutData_BDR.Text = Convert.ToString(res);
            }
            catch
            {
                MessageBox.Show("Сначала введите номер столбца в раскрывающемся поле операции!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MAXSumToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = Convert.ToInt32(toolStripTextBoxInputColumnMAX_BDR.Text);

                toolStripTextBoxInputColumnMAX_BDR.Clear();

                double[] columnData = new double[dataGridViewTable_BDR.Rows.Count];

                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnData[i] = Convert.ToInt32(dataGridViewTable_BDR.Rows[i].Cells[columnIndex].Value);
                }

                double res = ds.MaxDohod(columnData);
                textBoxOutPutData_BDR.Text = Convert.ToString(res);
            }
            catch
            {
                MessageBox.Show("Сначала введите номер столбца в раскрывающемся поле операции!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AverageValueToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = Convert.ToInt32(toolStripTextBoxInputColumnAverageValue_BDR.Text);

                toolStripTextBoxInputColumnAverageValue_BDR.Clear();

                double[] columnData = new double[dataGridViewTable_BDR.Rows.Count];

                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnData[i] = Convert.ToInt32(dataGridViewTable_BDR.Rows[i].Cells[columnIndex].Value);
                }

                double res = ds.AverageValue(columnData);
                textBoxOutPutData_BDR.Text = Convert.ToString(res);
            }
            catch
            {
                MessageBox.Show("Сначала введите номер столбца в раскрывающемся поле операции!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountDocumentToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                int[] columnData = new int[dataGridViewTable_BDR.Rows.Count];

                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnData[i] = Convert.ToInt32(dataGridViewTable_BDR.Rows[i].Cells[0].Value);
                }

                int res = ds.CountDocument(columnData);
                textBoxOutPutData_BDR.Text = Convert.ToString(res);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildChartToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndexName = Convert.ToInt32(toolStripTextBoxInputColumnForChartName_BDR.Text);
                toolStripTextBoxInputColumnForChartName_BDR.Clear();

                string[] columnDataName = new string[dataGridViewTable_BDR.Rows.Count];
                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnDataName[i] = Convert.ToString(dataGridViewTable_BDR.Rows[i].Cells[columnIndexName].Value);
                }

                //

                int columnIndexData = Convert.ToInt32(toolStripTextBoxInputColumnForChartData_BDR.Text);
                toolStripTextBoxInputColumnForChartData_BDR.Clear();

                double[] columnData = new double[dataGridViewTable_BDR.Rows.Count];
                for (int i = 0; i < dataGridViewTable_BDR.Rows.Count; i++)
                {
                    columnData[i] = Convert.ToDouble(dataGridViewTable_BDR.Rows[i].Cells[columnIndexData].Value);
                }

                DataService.ArrayData = columnData;
                DataService.ArrayName = columnDataName;

                FormChart formChart = new FormChart();
                formChart.Show();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchToolStripMenuItem_BDR_Click(object sender, EventArgs e)
        {
            if (toolStripTextBoxSearch_BDR != null)
            {
                string currentText = toolStripTextBoxSearch_BDR.Text;
                foreach (DataGridViewRow row in dataGridViewTable_BDR.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && toolStripTextBoxSearch_BDR.Text != string.Empty && cell.Value.ToString().Contains(toolStripTextBoxSearch_BDR.Text))
                        {
                            cell.Style.BackColor = Color.Yellow;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void buttonUseFilter_BDR_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dataGridViewTable_BDR.Rows)
                {
                    if ((r.Cells[comboBoxColumnForFilter_BDR.SelectedIndex].Value).ToString().ToUpper().Contains(textBoxInputFilter_BDR.Text.ToUpper()))
                    {
                        dataGridViewTable_BDR.Rows[r.Index].Visible = true;
                        dataGridViewTable_BDR.Rows[r.Index].Selected = true;
                    }
                    else
                    {
                        dataGridViewTable_BDR.CurrentCell = null;
                        dataGridViewTable_BDR.Rows[r.Index].Visible = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewTable_BDR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManual formManual = new FormManual();
            formManual.Show();
        }

        
    }
}
