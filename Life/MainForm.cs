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

            // Standaard waarden zetten
            LifeApplication = new LifeApplication();
            UserManager = new UserManager.UserManager();

            // Layouts maken
            LifeApplication.CreateLayout("Layout 1", 200);
            LifeApplication.Layouts[0].AddTerritory(new LifeSimulation.Layouts.Territory(1, 1));

            // Species maken
            LifeApplication.CreateSpecies("Tijgers", 10, 4, LifeSimulation.SimObjects.Digestion.Carnivore, 0, 0 ,0,0,0);
        }

        private void afsluitenMainMenu_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void startSimulatieToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // TODO INITEN MET GOEDE WAARDEN
            ILifeSimulation simulation = new LifeSimulation.LifeSimulation(LifeApplication.Layouts[0], 100, 20, 20, 20, 20, 10, 10, 5, LifeApplication.Species);
            // Toevoegen aan mainForm
            LifeApplication.AddSimulation(simulation);

            // Nieuw formulier maken en simulation meesturen.
            SimulationForm sf = new SimulationForm(simulation);
            sf.MdiParent = this;
            sf.Show();            
        }
    }
}
