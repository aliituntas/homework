using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mining
{
    public partial class Form1 : Form
    {
        //int popsize;
        //int orneklem_size;
        //int[] Populasyon_copy = new int[1000000];
        //int[] Orneklem_copy = new int[10000];
        //float pop_ortalama,pop_stdsapma,pop_varyans;

        //int orneklem_size = int.Parse(textBox4.Text);
        //int[] Orneklem = new int[orneklem_size];
        //public int[] Orneklem
        //{
        //    get { return Orneklem; }
        //    set { Orneklem = value; }
        //}
        //public int[] Populasyon
        //{
        //    get { return Populasyon; }
        //    set { Orneklem = value; }
        //}
        int click = 1;
        public static class Arrayler
        {
            
            public static int[] Orneklem;
            public static int[] Populasyon;
        }

        public Form1()
        {
            InitializeComponent();
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int orneklem_size = int.Parse(textBox4.Text);
            Arrayler.Orneklem = new int[orneklem_size];
            Random randomNumber2 = new Random();
            double  varyans_ort1, varyans_ort2, varyans_ort3, varyans_ort4, varyans_ort5, std_ort;
            double ort_ort = 0.0;
            double ort_toplam = 0.0;
            for (int i = 0; i < Arrayler.Orneklem.Length; i++)
            {
                Arrayler.Orneklem[i] = Arrayler.Populasyon[randomNumber2.Next(int.Parse(textBox2.Text), int.Parse(textBox1.Text))];
                

            }
            guncel_ort.Text = Arrayler.Orneklem.Average().ToString();

            double varyans_orneklem = variance(Arrayler.Orneklem);

            double stdSapma_orneklem = standardDeviation(varyans_orneklem);

            guncel_std.Text = stdSapma_orneklem.ToString();
            guncel_var.Text = varyans_orneklem.ToString();

            ort_toplam += Arrayler.Orneklem.Average();
            ort_ort =ort_toplam/  click;

            label17.Text = ort_ort.ToString();
            label23.Text = click.ToString();
            label15.Text = ort_toplam.ToString();
            click++;

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            int popsize = int.Parse(textBox1.Text);
            Arrayler.Populasyon = new int[popsize];
            Random randomNumber = new Random();
            

            for (int i = 0; i < Arrayler.Populasyon.Length; i++)
            {
                Arrayler.Populasyon[i] = randomNumber.Next(int.Parse(textBox2.Text), int.Parse(textBox3.Text));
               // Populasyon[i] = Populasyon_copy[i];
            }
            
            pop_ort.Text = Arrayler.Populasyon.Average().ToString();

            double varyans = variance( Arrayler.Populasyon);

            double stdSapma = standardDeviation(varyans);

            pop_std.Text = stdSapma.ToString();
            pop_var.Text = varyans.ToString();
        }
        private double variance(int[] nums)
        {
            if (nums.Length > 1)
            {

                // Get the average of the values
                double avg = getAverage(nums);

                // Now figure out how far each point is from the mean
                // So we subtract from the number the average
                // Then raise it to the power of 2
                double sumOfSquares = 0.0;

                foreach (int num in nums)
                {
                    sumOfSquares += Math.Pow((num - avg), 2.0);
                }

                // Finally divide it by n - 1 (for standard deviation variance)
                // Or use length without subtracting one ( for population standard deviation variance)
                return sumOfSquares / (double)(nums.Length - 1);
            }
            else { return 0.0; }
        }
       
        private double variance(int[] nums,int a)
        {
            if (nums.Length > 1)
            {

                // Get the average of the values
                double avg = getAverage(nums);

                // Now figure out how far each point is from the mean
                // So we subtract from the number the average
                // Then raise it to the power of 2
                double sumOfSquares = 0.0;

                foreach (int num in nums)
                {
                    sumOfSquares += Math.Pow((num - avg), 2.0);
                }

                // Finally divide it by n - 1 (for standard deviation variance)
                // Or use length without subtracting one ( for population standard deviation variance)
                return sumOfSquares / (double)(nums.Length - a);
            }
            else { return 0.0; }
        }

        // Square root the variance to get the standard deviation
        private double standardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }

        // Get the average of our values in the array
        private double getAverage(int[] nums)
        {
            int sum = 0;

            if (nums.Length > 1)
            {

                // Sum up the values
                foreach (int num in nums)
                {
                    sum += num;
                }

                // Divide by the number of values
                return sum / (double)nums.Length;
            }
            else { return (double)nums[0]; }
        }

        
    }
}
