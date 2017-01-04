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
            foreach (var o in simulation.Context.GetSimObjects<LifeSimulation.SimObjects.Obstacle>().ToList())
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
            foreach (var o in simulation.Context.GetSimObjects<LifeSimulation.SimObjects.Plant>().ToList())
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
            foreach (var o in simulation.Context.GetSimObjects<LifeSimulation.SimObjects.Creature>().ToList())
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
            }
            else if ((simulation.Status == LifeSimulation.SimulationStatus.Pauzed)
                || (simulation.Status == LifeSimulation.SimulationStatus.New))
            {
                simulation.Start();
                btnStartPause.Text = "Pauze";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            simulation.Stop();
            btnStartPause.Visible = false;
        }
    }
}
