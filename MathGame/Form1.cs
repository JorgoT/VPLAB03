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
    public partial class Form1 : Form
    {
        public Equation e { get; set; }
        public List<Igrac> igraci;
        private Timer time;
        private int remaining;
        private int score;
        public Form1()
        {
            InitializeComponent();
            time = new Timer();
            init();
            this.igraci = new List<Igrac>();
            label6.Text = score + "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            int.TryParse(textBox4.Text,out tmp);

            if (tmp == this.e.res)
            {
                score++;
                progressBar2.Increment(1);
                if (score % 10 == 0) {
                    remaining += 10000;
                    progressBar1.Value -= 10;
                }
            }

            refreshScore();

        }

        public void init() {
            this.remaining = 60000;
            InitializeMyTimer();
            this.textBox5.Text = "Default";
            e = new Equation();
            textBox1.Text = this.e.a + "";
            textBox2.Text = this.e.op + "";
            textBox3.Text = this.e.b + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.score = 0;
            progressBar2.Value = 0;
            remaining = 60000;
            time.Stop();
            time = new Timer();          
            InitializeMyTimer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeMyTimer()
        {       
            time.Interval = 1000;
            progressBar1.Value = 0;
            time.Tick += new EventHandler(IncreaseProgressBar);
            time.Tick += new EventHandler(setTime);
            time.Start();
        }

        private void IncreaseProgressBar(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                time.Stop();
                updateScoreTable();
            }
        }

        public void setTime(object sender, EventArgs e) {
            remaining -= 1000;
            TimeSpan ts = TimeSpan.FromMilliseconds(remaining);
            label4.Text = ts.ToString(@"hh\:mm\:ss");
        }

        public void refreshScore() {
            label6.Text = score + "";
            this.e = new Equation();
            textBox1.Text = this.e.a + "";
            textBox2.Text = this.e.op + "";
            textBox3.Text = this.e.b + "";
        }

        public void updateScoreTable() {
            Igrac i = new Igrac(textBox5.Text,this.score);
            igraci.Add(i);
            igraci = igraci.OrderByDescending(x => x.points).ToList();
            this.score = 0;
            progressBar2.Value = 0;
            label6.Text = score + "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScoreTable st = new ScoreTable(igraci);
            time.Stop();
            st.Show();
        }
    }
}
