﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LifeSimulation.SimObjects;
using LifeSimulation;

namespace Life
{


    public partial class SimulationForm : Form
    {
        LifeSimulation.ILifeSimulation simulation;
        private System.Timers.Timer timer;
        private Graphics _graphics;
        private int _width;
        private int _height;

        public SimulationForm(LifeSimulation.ILifeSimulation sim)
        {
            InitializeComponent();
            simulation = sim;

            timer = new System.Timers.Timer
            {
                Interval = 1000,
                AutoReset = false
            };

            timer.Elapsed += timer_Elapsed;

            SetSimulationData();
        }

        private void timer_Elapsed(object sender, EventArgs e)
        {
            simulation.Step();

            SetSimulationData();
            simulationPanel.Invalidate();
            lblCarnivoren.Invalidate();
            lblHerbivoren.Invalidate();
            lblNonivoren.Invalidate();
            lblOmnivoren.Invalidate();
            lblPlanten.Invalidate();

            Application.DoEvents();

            timer.Start();
        }

        private void SimulationForm_Resize(object sender, EventArgs e)
        {
            simulationPanel.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            // In de paint functie gaan we onze objecten tekenen
            // Deze wordt aangeroepen op het moment dat het scherm wordt geresized
            // Deze wordt ook aangeroepen op het moment dat er een simulatie stap wordt gezet

            // Voor water hoeven we niets te doen! Onze achtergrond is standaard BLAUW!
            _graphics = paintEventArgs.Graphics;
            _graphics.Clear(Color.Blue);

            // 1. Berekenen van hoogte / breedte van ieder blokje
            if (simulation.Context.Layout == null) return;
            _width = (int)Math.Floor((float)simulationPanel.Width / simulation.Context.Layout.GridSizeX);
            _height = (int)Math.Floor((float)simulationPanel.Height / simulation.Context.Layout.GridSizeY);

            var context = simulation.Context;
            // Draw all territories
            DrawRectagles(context.Layout.Territories);
            // Draw all SimObjects
            DrawRectagles(context.GetSimObjects<Plant>());
            DrawRectagles(context.GetCreatures(Digestion.Carnivore));
            DrawRectagles(context.GetCreatures(Digestion.Herbivore));
            DrawRectagles(context.GetCreatures(Digestion.OmnivoreCreature));
            DrawRectagles(context.GetCreatures(Digestion.OmnivorePlant));
            DrawRectagles(context.GetCreatures(Digestion.Nonivore));
        }

        private void DrawRectagles(IEnumerable<ISimObject> objects)
        {
            if (!objects.Any()) return;

            var brush = new SolidBrush(objects.First().Color);
            var rectangles = new List<Rectangle>();
            foreach (var t in objects)
            {
                var xPos = ((t.XPos) * _width) - _width;
                var yPos = ((t.YPos) * _height) - _height;

                rectangles.Add(new Rectangle(xPos, yPos, _width, _height));
            }

            _graphics.FillRectangles(brush, rectangles.ToArray());
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
            //lblCarnivoren.Text = simulation.EnergyCarnivores.ToString(); //+ " / " + simulation.EnergyCarnivores + " / " + (simulation.EnergyCarnivores / simulation.Carnivores).ToString();
            //lblHerbivoren.Text = simulation.Herbivores.ToString(); //+ " / " + simulation.EnergyHerbivores + " / " + (simulation.EnergyHerbivores / simulation.Herbivores).ToString();
            //lblNonivoren.Text = simulation.Nonivores.ToString(); //+ " / " + simulation.EnergyNonivores + " / " + (simulation.EnergyNonivores / simulation.Nonivores).ToString();
            //lblOmnivoren.Text = simulation.Omnivores.ToString();// + " / " + simulation.EnergyOmnivores + " / " + (simulation.EnergyOmnivores / simulation.Omnivores).ToString();
            //lblPlanten.Text = simulation.Planten.ToString(); //+ " / " + simulation.EnergyPlanten + " / " + (simulation.EnergyPlanten / simulation.Planten).ToString();
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
