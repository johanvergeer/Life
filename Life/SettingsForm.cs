using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life
{
    public partial class SettingsForm : Form
    {
        public int nElements { get; private set; }
        public int omnivores { get; private set; }
        public int herbivores { get; private set; }
        public int carnivores { get; private set; }
        public int nonivores { get; private set; }
        public int plants { get; private set; }
        public int obstacles { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            nElements = Convert.ToInt32(eElements.Text);
            herbivores = Convert.ToInt32(eHerbivores.Text);
            omnivores = Convert.ToInt32(eOmnivores.Text);
            carnivores = Convert.ToInt32(eCarnivores.Text);
            nonivores = Convert.ToInt32(eNonivores.Text);
            plants = Convert.ToInt32(ePlants.Text);
            obstacles = Convert.ToInt32(eObstacels.Text);

            DialogResult = DialogResult.OK;
        }

        private void InputKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
