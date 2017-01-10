using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using LifeSimulation.SimObjects;

namespace Life
{
    public partial class SimulationForm : Form
    {
        LifeSimulation.ILifeSimulation simulation;
        private System.Timers.Timer timer;

        public SimulationForm(LifeSimulation.ILifeSimulation sim)
        {
            InitializeComponent();
            simulation = sim;

            timer = new System.Timers.Timer();
            timer.Interval = 5000; 
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            SetSimulationData();
        }

        private void timer_Elapsed(object sender, EventArgs e)
        {
            SetSimulationData();
            simulationPanel.Invalidate();
            lblCarnivoren.Invalidate();
            lblHerbivoren.Invalidate();
            lblNonivoren.Invalidate();
            lblOmnivoren.Invalidate();
            lblPlanten.Invalidate();

            Application.DoEvents();

            simulation.Step();
        }

        private void SimulationForm_Resize(object sender, EventArgs e)
        {
            simulationPanel.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // In de paint functie gaan we onze objecten tekenen
            // Deze wordt aangeroepen op het moment dat het scherm wordt geresized
            // Deze wordt ook aangeroepen op het moment dat er een simulatie stap wordt gezet

            // Voor water hoeven we niets te doen! Onze achtergrond is standaard BLAUW!
            Graphics g = e.Graphics;

            // 1. Berekenen van hoogte / breedte van ieder blokje
            if (simulation.Context.Layout == null) return;
            var height = (int)Math.Floor((float)simulationPanel.Height / simulation.Context.Layout.GridSizeY);
            var width = (int)Math.Floor((float)simulationPanel.Width / simulation.Context.Layout.GridSizeX);

            List<Rectangle> rectangles = new List<Rectangle>();

            Brush b = Brushes.Red;
            // 2. Alle territories tekenen
            Type tp = typeof(Brushes);
            foreach (var t in simulation.Context.Layout.Territories)
            {
                int xPos = ((t.XPos) * width) - width;
                int yPos = ((t.YPos) * height) - height;

                rectangles.Add(new Rectangle(xPos, yPos, width, height));
                b = (Brush)tp.GetProperty(t.Color.ToString()).GetValue(null, null);
            }

            if (rectangles.Count > 0)
                g.FillRectangles(b, rectangles.ToArray());
            rectangles.Clear();

            // 3. Alle obstacles tekenen
            foreach (var o in simulation.Context.GetSimObjects<Obstacle>().ToList())
            {
                int xPos = ((o.XPos) * width) - width;
                int yPos = ((o.YPos) * height) - height;

                rectangles.Add(new Rectangle(xPos, yPos, width, height));
                b = (Brush)tp.GetProperty(o.SimObjectColor.ToString()).GetValue(null, null);
            }

            if (rectangles.Count > 0)
                g.FillRectangles(b, rectangles.ToArray());
            rectangles.Clear();

            // 4. Alle sim objects
            foreach (var o in simulation.Context.GetSimObjects<Plant>().ToList())
            {
                int xPos = ((o.XPos) * width) - width;
                int yPos = ((o.YPos) * height) - height;

                rectangles.Add(new Rectangle(xPos, yPos, width, height));
                b = (Brush)tp.GetProperty(o.SimObjectColor.ToString()).GetValue(null, null);
            }

            if (rectangles.Count > 0)
                g.FillRectangles(b, rectangles.ToArray());
            rectangles.Clear();

            // 3. Alle beesten tekenen
            foreach (var o in simulation.Context.GetSimObjects<Creature>().ToList())
            {
                int xPos = ((o.XPos) * width) - width;
                int yPos = ((o.YPos) * height) - height;

                rectangles.Add(new Rectangle(xPos, yPos, width, height));
                b = (Brush)tp.GetProperty(o.SimObjectColor.ToString()).GetValue(null, null);
            }

            if (rectangles.Count > 0)
                g.FillRectangles(b, rectangles.ToArray());
        }

        private void btnStartPause_Click(object sender, EventArgs e)
        {
            if (simulation.Status == LifeSimulation.SimulationStatus.Started)
            {
                simulation.Pauze();
                btnStartPause.Text = "Start";
                timer.Stop();
            }
            else if ((simulation.Status == LifeSimulation.SimulationStatus.Pauzed)
                || (simulation.Status == LifeSimulation.SimulationStatus.New))
            {
                simulation.Start();
                btnStartPause.Text = "Pauze";
                timer.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            simulation.Stop();
            btnStartPause.Visible = false;
            timer.Stop();
        }

        public void SetSimulationData()
        {
            lblCarnivoren.Text = simulation.EnergyCarnivores.ToString(); //+ " / " + simulation.EnergyCarnivores + " / " + (simulation.EnergyCarnivores / simulation.Carnivores).ToString();
            lblHerbivoren.Text = simulation.Herbivores.ToString(); //+ " / " + simulation.EnergyHerbivores + " / " + (simulation.EnergyHerbivores / simulation.Herbivores).ToString();
            lblNonivoren.Text = simulation.Nonivores.ToString(); //+ " / " + simulation.EnergyNonivores + " / " + (simulation.EnergyNonivores / simulation.Nonivores).ToString();
            lblOmnivoren.Text = simulation.Omnivores.ToString();// + " / " + simulation.EnergyOmnivores + " / " + (simulation.EnergyOmnivores / simulation.Omnivores).ToString();
            lblPlanten.Text = simulation.Planten.ToString(); //+ " / " + simulation.EnergyPlanten + " / " + (simulation.EnergyPlanten / simulation.Planten).ToString();
        }
    }
}
