using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsMvp.Forms;

namespace SampleApp
{
    public partial class Form1 : MvpForm<String>
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
