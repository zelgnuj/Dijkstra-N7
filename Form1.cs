using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
namespace Winform_DoAn1
{
    public partial class Form1 : Form
    {
        public string Input(string k, string d)
        {
            double Distance(Toado a, Toado b)
            {
                return Math.Round(Math.Sqrt(Math.Pow((b.x - a.x), 2) + Math.Pow((b.y - a.y), 2)), 3);
            }
            

            Toado Q1 = new Toado(6, 4);
            Toado Q2 = new Toado(9, 6);
            Toado Q4 = new Toado(7, 3);
            Toado Q5 = new Toado(4, 2);
            Toado Q7 = new Toado(8, 1);
            Toado Q9 = new Toado(12, 10);
            Toado Q10 = new Toado(3, 4);
            Toado TP = new Toado(1, 5);
            Toado TB = new Toado(4, 7);
            Toado BT = new Toado(7, 7);
            Toado GV = new Toado(5, 9);
            Toado Q12 = new Toado(3, 11);

            Graph graph = new Graph(12);
            graph.AddVertex("Quận 1"); graph.AddVertex("Quận 2");
            graph.AddVertex("Quận 4"); graph.AddVertex("Quận 5");
            graph.AddVertex("Quận 7"); graph.AddVertex("Quận 9");
            graph.AddVertex("Quận 10"); graph.AddVertex("Quận Tân Phú");
            graph.AddVertex("Quận Tân Bình"); graph.AddVertex("Quận Bình Thạnh");
            graph.AddVertex("Quận Gò Vấp"); graph.AddVertex("Quận 12");
            graph.AddEdge(0, 1, Distance(Q1, Q2)); graph.AddEdge(0, 2, Distance(Q1, Q4)); graph.AddEdge(0, 3, Distance(Q1, Q5));
            graph.AddEdge(0, 6, Distance(Q1, Q10)); graph.AddEdge(0, 8, Distance(Q1, TB)); graph.AddEdge(0, 9, Distance(Q1, BT));
            graph.AddEdge(1, 0, Distance(Q2, Q1)); graph.AddEdge(1, 2, Distance(Q2, Q4)); graph.AddEdge(1, 4, Distance(Q2, Q7)); 
            graph.AddEdge(1, 5, Distance(Q2, Q9)); graph.AddEdge(1, 9, Distance(Q2, BT)); graph.AddEdge(2, 0, Distance(Q4, Q1)); 
            graph.AddEdge(2, 1, Distance(Q4, Q2)); graph.AddEdge(2, 3, Distance(Q4, Q5)); graph.AddEdge(2, 4, Distance(Q4, Q7));
            graph.AddEdge(3, 0, Distance(Q5, Q1)); graph.AddEdge(3, 2, Distance(Q5, Q4)); graph.AddEdge(3, 4, Distance(Q5, Q7)); 
            graph.AddEdge(3, 6, Distance(Q5, Q10)); graph.AddEdge(4, 1, Distance(Q7, Q2)); graph.AddEdge(4, 2, Distance(Q7, Q4));
            graph.AddEdge(4, 3, Distance(Q7, Q5)); graph.AddEdge(5, 1, Distance(Q9, Q1)); graph.AddEdge(6, 0, Distance(Q10, Q1));
            graph.AddEdge(6, 3, Distance(Q10, Q5)); graph.AddEdge(6, 7, Distance(Q10, TP)); graph.AddEdge(6, 8, Distance(Q10, TB));
            graph.AddEdge(7, 6, Distance(TP, Q10)); graph.AddEdge(7, 8, Distance(TP, TB)); graph.AddEdge(7, 11, Distance(TP, Q12));
            graph.AddEdge(8, 0, Distance(TB, Q1)); graph.AddEdge(8, 6, Distance(TB, Q10)); graph.AddEdge(8, 7, Distance(TB, TP));
            graph.AddEdge(8, 9, Distance(TB, BT)); graph.AddEdge(8, 10, Distance(TB, GV)); graph.AddEdge(8, 11, Distance(TB, Q12));
            graph.AddEdge(9, 0, Distance(BT, Q1)); graph.AddEdge(9, 1, Distance(BT, Q2)); graph.AddEdge(9, 8, Distance(BT, TB));
            graph.AddEdge(9, 10, Distance(BT, GV)); graph.AddEdge(10, 8, Distance(GV, TB)); graph.AddEdge(10, 9, Distance(GV, BT)); 
            graph.AddEdge(10, 11, Distance(GV, Q12)); graph.AddEdge(11, 7, Distance(Q12, TP)); graph.AddEdge(11, 8, Distance(Q12, TB));
            graph.AddEdge(11, 10, Distance(Q12, GV));
            return graph.Dijkstra(k, d);


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn điểm xuất phát!", "Yêu cầu chọn đầy đủ");
            }
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn đích đến!", "Yêu cầu chọn đầy đủ");
            }
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                textBox1.Text = Input(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            }

        }
  
    }
}