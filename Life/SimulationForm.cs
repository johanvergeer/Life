﻿using System;
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
    }
}
