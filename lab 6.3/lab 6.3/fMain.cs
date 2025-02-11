﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6._3
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }


        private void fMain_Load(object sender, EventArgs e)
        {
            gvHouses.AutoGenerateColumns = false;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Width";
            column.Name = "Ширина";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Length";
            column.Name = "Довжина";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Height";
            column.Name = "Висота";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Room";
            column.Name = "Кількість кімнат";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Floor";
            column.Name = "Кількість поверхів";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.Name = "Вартість опалення";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Price";
            column.Name = "Вартість м кв";
            gvHouses.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "HasForniture";
            column.Name = "Чи є меблі та техніка?";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "GetCost";
            column.Name = "Ціна за будинок";
            gvHouses.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Heating";
            column.Name = "Ціна за опалення";
            gvHouses.Columns.Add(column);

            bindSrcHouses.Add(new House(40, 34, 3, 4, 5, 18, 20000, true, 432, 423));
            EventArgs args = new EventArgs(); OnResize(args);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Building building = new House();
            fHouse ft = new fHouse(building);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcHouses.Add(building);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Building building = (Building)bindSrcHouses.List[bindSrcHouses.Position];
            fHouse ft = new fHouse(building);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcHouses.List[bindSrcHouses.Position] = building;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcHouses.RemoveCurrent();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcHouses.Clear();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 9 * btnAdd.Width + 3 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }
        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Текстові файли (*.txt) |*.txt|All files (*.*) |*.*";
            saveFileDialog.Title = "Зберегти дані у текстовому форматі";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            StreamWriter sw;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8);
                try
                {
                    foreach (Building building in bindSrcHouses.List)
                    {
                        sw.Write(building.Width + "\t" + building.Length + "\t" +
                            building.Height + "\t" + building.Room + "\t" +
                            building.Floor + "\t" + building.Value +
                            "\t" + building.Price + "\t" + building.HasForniture + "\t" + building.GetCost + "\t" +
                            building.Heating + "\t\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sw.Close();
                }
            }
        }
        private void btnSaveAsBinary_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Файли даних (*.tablets) |*.tablets|All files (*.*) |*.*";
            saveFileDialog.Title = "Зберегти дані у бінарному форматі";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            BinaryWriter bw;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bw = new BinaryWriter(saveFileDialog.OpenFile());
                try
                {
                    foreach (Building building in bindSrcHouses.List)
                    {
                        bw.Write(building.Width);
                        bw.Write(building.Length);
                        bw.Write(building.Height);
                        bw.Write(building.Room);
                        bw.Write(building.Floor);
                        bw.Write(building.Value);
                        bw.Write(building.Price);
                        bw.Write(building.HasForniture);
                        bw.Write(building.GetCost);
                        bw.Write(building.Heating);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bw.Close();
                }
            }
        }
        private void btnOpenFromText_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли (*.txt) |*.txt|All files (*.*) |*.*";
            openFileDialog.Title = "Прочитати дані у текстовому форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
            StreamReader sr;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindSrcHouses.Clear();
                sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
                string s;
                try
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] split = s.Split('\t');
                        Building building = new House(double.Parse(split[0]), double.Parse(split[1]), 
                            double.Parse(split[2]),
                            int.Parse(split[3]), int.Parse(split[4]), double.Parse(split[5]), double.Parse(split[6]),
                            bool.Parse(split[7]), double.Parse(split[8]), double.Parse(split[9]));
                        bindSrcHouses.Add(building);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sr.Close();
                }
            }
        }
        private void btnOpenFromBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли даних (*.tablets) |*.tablets|All files (*.*) |*.*";
            openFileDialog.Title = "Прочитати дані у бінарному форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
            BinaryReader br;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindSrcHouses.Clear();
                br = new BinaryReader(openFileDialog.OpenFile());
                try
                {
                    Building building; while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        building = new House();
                        for (int i = 1; i <= 10; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    building.Width = br.ReadDouble(); break;
                                case 2:
                                    building.Length = br.ReadDouble(); break;
                                case 3:
                                    building.Height = br.ReadDouble(); break;
                                case 4:
                                    building.Room = br.ReadInt32(); break;
                                case 5:
                                    building.Floor = br.ReadInt32(); break;
                                case 6:
                                    building.Value = br.ReadDouble(); break;
                                case 7:
                                    building.Price = br.ReadDouble(); break;
                                case 8:
                                    building.HasForniture = br.ReadBoolean(); break;
                                case 9:
                                    building.GetCost = br.ReadDouble(); break;
                                case 10:
                                    building.Heating = br.ReadDouble(); break;
                            }
                        }
                        bindSrcHouses.Add(building);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    br.Close();
                }
            }
        }
    }
}
