using LifeSimulation;
using System.Windows.Forms;
using UserManager;
using ReportManager;

namespace Life
{
    public partial class MainForm : Form
    {
        public ILifeApplication LifeApplication{ get; set; }
        public IUserManager UserManager{ get; set; }
        public IReportManager ReportManager{ get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void afsluitenMainMenu_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
