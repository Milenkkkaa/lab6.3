using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6._3
{
    public partial class fHouse : Form
    {
        public fHouse(Building t)
        {
            TheBuilding = t;
            InitializeComponent();
        }
        public Building TheBuilding;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (TheBuilding == null)
            {
                MessageBox.Show("House object is null.");
                return;
            }
            if (double.TryParse(tbWidth.Text.Trim(), out double width) &&
                double.TryParse(tbLength.Text.Trim(), out double length) &&
                double.TryParse(tbHeight.Text.Trim(), out double height) &&
                int.TryParse(tbRoom.Text.Trim(), out int room) &&
                int.TryParse(tbFloor.Text.Trim(), out int floor) &&
                double.TryParse(tbValue.Text.Trim(), out double value) &&
                double.TryParse(tbPrice.Text.Trim(), out double price))
            {
                TheBuilding.Width = width;
                TheBuilding.Length = length;
                TheBuilding.Height = height;
                TheBuilding.Room = room;
                TheBuilding.Floor = floor;
                TheBuilding.Value = value;
                TheBuilding.Price = price;
                TheBuilding.HasForniture = chbHasForniture.Checked;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your values.");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void fHouse_Load(object sender, EventArgs e)
        {
            if (TheBuilding != null)
            {
                tbWidth.Text = TheBuilding.Width.ToString();
                tbLength.Text = TheBuilding.Length.ToString();
                tbHeight.Text = TheBuilding.Height.ToString();
                tbRoom.Text = TheBuilding.Room.ToString();
                tbFloor.Text = TheBuilding.Floor.ToString();
                tbValue.Text = TheBuilding.Value.ToString();
                tbPrice.Text = TheBuilding.Price.ToString();
                chbHasForniture.Checked = TheBuilding.HasForniture;
            }
        }
    }
}
