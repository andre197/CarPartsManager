﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarPartsManager.App.Base
{
    public partial class BaseControl : UserControl
    {
        public Validator Validator { get; set; } = new Validator();

        public BaseControl()
        {
            InitializeComponent();
        }
    }
}
