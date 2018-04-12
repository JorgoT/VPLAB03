using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGame
{
    public partial class ScoreTable : Form
    {
        List<Igrac> igraci;
        public ScoreTable(List<Igrac> l)
        {
            InitializeComponent();
            igraci = l;
            foreach (Igrac i in igraci) {
                listBox1.Items.Add(i);
            }
        }

        
    }
}
