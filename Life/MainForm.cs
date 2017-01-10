using LifeSimulation;
using System.Windows.Forms;
using UserManager;
using ReportManager;
using LifeSimulation.SimObjects;

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
            // Vooraf geprogrammeerde Layout inladen
            Layout1 l1 = new Layout1(LifeApplication.Layouts[0]);

            // Species maken
            LifeApplication.CreateSpecies("Dog", 15, 4, Digestion.OmnivorePlant, 20, 60, 10, 100, 0, 95, 20);
            LifeApplication.CreateSpecies("Kat", 15, 4, Digestion.Carnivore, 20, 60, 10, 100, 0, 95, 20);
            LifeApplication.CreateSpecies("Giraffe", 15, 4, Digestion.Herbivore, 20, 60, 10, 100, 0, 95, 20);
            LifeApplication.CreateSpecies("Niksnut", 15, 4, Digestion.Nonivore, 20, 60, 10, 100, 0, 95, 20);
            LifeApplication.CreateSpecies("Mens", 15, 4, Digestion.OmnivoreCreature, 20, 60, 10, 100, 0, 95, 20);
        }

        private void afsluitenMainMenu_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void startSimulatieToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();

            if (sf.DialogResult == DialogResult.OK)
            {
                ILifeSimulation simulation = new LifeSimulation.LifeSimulation(LifeApplication.Layouts[0], sf.nElements, LifeApplication.Species, sf.plants, sf.carnivores, sf.herbivores, sf.omnivores, sf.nonivores, sf.obstacles, 100);
                // Toevoegen aan mainForm
                LifeApplication.AddSimulation(simulation);

                // Nieuw formulier maken en simulation meesturen.
                SimulationForm simForm = new SimulationForm(simulation);
                simForm.MdiParent = this;
                simForm.Show();
            }  
        }
    }
}
