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
    public partial class SimulationForm : Form
    {
        LifeSimulation.ILifeSimulation simulation;
        public SimulationForm(LifeSimulation.ILifeSimulation sim)
        {
            InitializeComponent();
            simulation = sim;
        }

        private void simulationPanel_Paint(object sender, PaintEventArgs e)
        {
            // In de paint functie gaan we onze objecten tekenen
            // Deze wordt aangeroepen op het moment dat het scherm wordt geresized
            // Deze wordt ook aangeroepen op het moment dat er een simulatie stap wordt gezet

            // Voor water hoeven we niets te doen! Onze achtergrond is standaard BLAUW!
            Graphics g = e.Graphics;

            // 1. Berekenen van hoogte / breedte van ieder blokje
            float height = simulationPanel.Height / simulation.Context.Layout.GridSizeY;
            float width = simulationPanel.Width / simulation.Context.Layout.GridSizeX;

            // 2. Alle territories tekenen
            foreach (var t in simulation.Context.Layout.Territories)
            {
                float xPos = ((t.XPos) * width) - width;
                float yPos = ((t.YPos) * height) - height;
                g.FillRectangle(Brushes.Red, xPos, yPos, width, height);
            }
        }

        private void SimulationForm_Resize(object sender, EventArgs e)
        {
            simulationPanel.Invalidate();
        }
    }
}
