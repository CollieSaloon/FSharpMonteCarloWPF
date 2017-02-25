using DevExpress.Xpf.Charts;
using Microsoft.FSharp.Collections;
using MyFSLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FSCSDemoWPF
{

    public partial class Page1 : Page
    {

        //these are the variables that are set to the values given by the user
        //changing these values affects the behavior of the Monte Carlo simulations
        private double sp;
        private double er;
        private double vol;
        private int iter;

        public Page1()
        {
            InitializeComponent();
        }

        //computes the Monte Carlo simulation that based on the user inputs and displays the result in line diagram in a chart control.
        private void fillChart()
        {
            //clears existing points in the line chart
            Series1.Points.Clear();

            FSharpList<FSharpList<double>> l = null;

            FSharpList<double> l2 = null;

            //F sharp function monteListofLists is located in the monte2 module of MyFSLibrary
            //this function builds an F sharp list of run lists that is then passed to the function that finds the average of all the runs
            //the number of runs lists that are produced is equal the number of iterations
            var FListOfRuns = monte2.monteListofLists(sp, er, vol, iter, l);

            //F sharp function finalMonteCarloAvg is located in the finalMonte module of MyFSLibrary
            //this function that takes a list of lists and returns a single list that is the average of all of the runs lists
            var FList = finalMonte.finalMonteCarloAvg(FListOfRuns, l2, iter);

            int counter = 0;

            //this foreach loop adds the all points to the line diagram of the chart from FList which contains the average of all the runs 
            foreach (var item in FList)
            {
                counter++;

                SeriesPoint p = new SeriesPoint(counter, item);

                Series1.Points.Add(p);
            }
            
        }
      
        //when DisplayButton is clicked, the values in the text boxes are assigned to their appropriate global variables and the fillChart method is invoked.
        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtER.Text.ToString() != string.Empty && txtITER.Text.ToString() != string.Empty && txtSP.Text.ToString() != string.Empty && txtVOL.Text.ToString() != string.Empty)
            {
                sp = Convert.ToDouble(txtSP.Text.ToString());
                er = Convert.ToDouble(txtER.Text.ToString());
                vol = Convert.ToDouble(txtVOL.Text.ToString());
                iter = Convert.ToInt32(txtITER.Text.ToString());

                fillChart();
            }
        }
    }
}
