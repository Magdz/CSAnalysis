using System;
using System.Collections.Generic;
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

        public SignalFlow()
        {
            this.InitializeComponent();
        }

        private void InputsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NodesNum = int.Parse(NodesBox.Text);
                EdgesNum = int.Parse(EdgesBox.Text);
            }
            catch (Exception)
            {
                return;
            }
            if (NodesNum != 0 && EdgesNum != 0) 
            {
                NodesBox.IsEnabled = false;
                EdgesBox.IsEnabled = false;
                InputsButton.IsEnabled = false;
                StartInput();
            }
        }

        private void StartInput()
        {

        }
    }
}
