using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moscowtraffic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double square = 190000;
        double square_work = 214000;
        double square_rich = 0;
        double square_poor = 0;
        //double const_square = square;
        //double const_square_work = square_work;
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Осталось: " + square.ToString() + " м2";
            label3.Text = "Осталось: " + square.ToString() + " м2";
            label4.Text = "Осталось: " + square_work.ToString() + " м2";
            dataGridView1.Rows.Add("Площадь Ильича");
            dataGridView1.Rows.Add("Римская");
            dataGridView1.Rows.Add("МЦД-4");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double text = Convert.ToDouble(textBox1.Text);
            if (radioButton1.Checked || radioButton2.Checked)
            {
                if (square + text <= 190000)
                {
                    square += text;
                    if (radioButton1.Checked)
                    {
                        square_poor -= text;
                        label12.Text = (Convert.ToInt16(label12.Text) - 1).ToString();
                    }
                    else
                    {
                        square_rich -= text;
                        label13.Text = (Convert.ToInt16(label13.Text) - 1).ToString();
                    }
                }

                else
                {
                    MessageBox.Show("Вы превысили лимит по площади:" + (square + text - 190000).ToString() + " м2");
                }
                label2.Text = "Осталось: " + square.ToString() + " м2";
                label3.Text = "Осталось: " + square.ToString() + " м2";
            }
            else if (radioButton3.Checked)
            {
                if (square_work + text <= 214000)
                {
                    square_work -= text;
                    label14.Text = (Convert.ToInt16(label14.Text) - 1).ToString();
                }

                else
                {
                    MessageBox.Show("Вы превысили лимит по площади:" + (square_work + text - 214000).ToString() + " м2");
                }
                label4.Text = "Осталось: " + square_work.ToString() + " м2";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double text = Convert.ToDouble(textBox1.Text);
            if (radioButton1.Checked || radioButton2.Checked)
            {
                if (square >= text)
                { 
                    square -= text;
                    if (radioButton1.Checked)
                    {
                        square_poor += text;
                        label12.Text = (Convert.ToInt16(label12.Text)+1).ToString();
                    }
                    else
                    {
                        square_rich += text;
                        label13.Text = (Convert.ToInt16(label13.Text)+1).ToString();
                    }
                }

                else
                {
                    MessageBox.Show("Недостаточно площади:" + (text - square).ToString() + " м2");
                }
                label2.Text = "Осталось: " + square.ToString() + " м2";
                label3.Text = "Осталось: " + square.ToString() + " м2";
            }
            else if (radioButton3.Checked)
            {
                if (square_work >= text)
                {
                    label14.Text = (Convert.ToInt16(label14.Text) + 1).ToString();
                    square_work -= text;
                }

                else
                {
                    MessageBox.Show("Недостаточно площади:" + (text - square_work).ToString() + " м2");
                }
                label4.Text = "Осталось: " + square_work.ToString() + " м2";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double workers_load = (214000-square_work) / 35 * 0.57 * 0.35;
            double peoples_rich_load = (square_rich) / 45 * 0.57 * 0.1;
            double peoples_poor_load = (square_poor) / 25 * 0.57 * 0.1;

            label9.Text = Math.Round((Convert.ToDouble(label9.Text) + (peoples_poor_load + peoples_rich_load + workers_load)* 0.7 * 1/14), 0).ToString() + " чел./час пик" + "\n" + Math.Round((3500 + (peoples_poor_load + peoples_rich_load + workers_load) * 0.7 * 3.5 / 15.4), 0).ToString() + " чел./час пик";
            label8.Text = Math.Round((Convert.ToDouble(label8.Text) + (peoples_poor_load + peoples_rich_load + workers_load) * 0.7 * 8.4 / 14),0).ToString() + " чел./час пик";
            label7.Text = Math.Round((Convert.ToDouble(label7.Text) + (peoples_poor_load + peoples_rich_load + workers_load) * 0.7 * 4.6 / 14),0).ToString() + " чел./час пик";

            label11.Text = Math.Round((Convert.ToDouble(label11.Text) + (peoples_poor_load + peoples_rich_load + workers_load) * 0.3 /1.2 * 300/2850), 0).ToString() + " ТС/час пик";
            label5.Text = Math.Round((Convert.ToDouble(label5.Text) + (peoples_poor_load + peoples_rich_load + workers_load) * 0.3 / 1.2 * 2400 / 2850), 0).ToString() + " ТС/час пик";
            label10.Text = Math.Round((Convert.ToDouble(label10.Text) + (peoples_poor_load + peoples_rich_load + workers_load) * 0.3 / 1.2 * 150 / 2850), 0).ToString() + " ТС/час пик";

            button3.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
             square = 190000;
             square_work = 214000;
             square_rich = 0;
             square_poor = 0;
            label9.Text = "1000";
            label8.Text = "8400";
            label7.Text = "4600";
            label11.Text = "300";
            label5.Text = "2400";
            label10.Text = "150";
            label2.Text = "Осталось: " + square.ToString() + " м2";
            label3.Text = "Осталось: " + square.ToString() + " м2";
            label4.Text = "Осталось: " + square_work.ToString() + " м2";
            label12.Text = "0";
            label13.Text = "0";
            label14.Text = "0";
            button3.Enabled = true;
        }
    }
}
