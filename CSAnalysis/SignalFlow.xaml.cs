using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CSAnalysis
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignalFlow : Page
    {

        private int NodesNum = 0;
        private int EdgesNum = 0;
        private Graph theGraph;

        private int EdgesLeft;

        public SignalFlow()
        {
            this.InitializeComponent();
            InputGrid.Visibility = Visibility.Collapsed;
        }

        private void InputsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NodesNum = int.Parse(NodesBox.Text);
                EdgesNum = int.Parse(EdgesBox.Text);
            }
            catch (Exception) { return; }
            if (NodesNum != 0 && EdgesNum != 0) 
            {
                NodesBox.IsEnabled = false;
                EdgesBox.IsEnabled = false;
                InputsButton.IsEnabled = false;
                InputGrid.Visibility = Visibility.Visible;
                StartInput();
            }
        }

        private void StartInput()
        {
            theGraph = new Graph(NodesNum, EdgesNum);
            EdgesLeft = EdgesNum;
            AddEdgeText.Text = "Add the Edges " + EdgesLeft + " Left";
            for (int i = 0; i < NodesNum; ++i) 
            {
                YourNodes.Text += " y" + (i+1);
            }
        }

        private void EdgeButton_Click(object sender, RoutedEventArgs e)
        {
            int From = 0;
            int To = 0;
            string Value = null;
            try
            {
                From = FromBox.Text[1] - 48;
                To = ToBox.Text[1] - 48;
                Value = ValueBox.Text;
            }
            catch (Exception) { return; }
            if (From == 0 || To == 0 || Value == null) return;
            theGraph.AddEdge(From - 1, To - 1, Value);
            EdgesLeft--;
            AddEdgeText.Text = "Add the Edges " + EdgesLeft + " Left";
            if(EdgesLeft == 0)
            {
                FromBox.IsEnabled = false;
                ToBox.IsEnabled = false;
                ValueBox.IsEnabled = false;
                EdgeButton.IsEnabled = false;
            }
            AddedEdgesText.Text += "- Edge From y" + From + " To y" + To + " with a value " + Value + "\n";
            FromBox.Text = "";
            ToBox.Text = "";
            ValueBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            theGraph.Analyze();
            //theGraph.Debugging();
            ShowResults();
        }

        private void ShowResults()
        {
            //--------------------------------Paths---------------------------------
            ResultsText.Text = "Paths:\n";
            foreach(Path path in theGraph.Paths)
            {
                ResultsText.Text += "P" + (theGraph.Paths.IndexOf(path)+1) + "=";
                foreach(string value in path.Values)
                {
                    if(value != "1")
                    {
                        if (path.Values.IndexOf(value) != 0) ResultsText.Text += "*";
                        ResultsText.Text += value;
                    }
                }
                ResultsText.Text += "\n";
            }
            //--------------------------------Loops---------------------------------
            ResultsText.Text += "Loops:\n";
            foreach (Path loop in theGraph.Loops)
            {
                ResultsText.Text += "L" + (theGraph.Loops.IndexOf(loop) + 1) + "=";
                foreach (string value in loop.Values)
                {
                    if (value != "1")
                    {
                        if (loop.Values.IndexOf(value) != 0) ResultsText.Text += "*";
                        ResultsText.Text += value;
                    }
                }
                ResultsText.Text += "\n";
            }
            //--------------------------------Loops---------------------------------

        }
    }
}
