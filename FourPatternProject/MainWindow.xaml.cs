using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FourPatternProject.Models;

namespace FourPatternProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int offsetX = 4;
        const int offsetY = 4;
        RobotApp app;

        public MainWindow()
        {
            InitializeComponent();
            app = new RobotApp(4,-4,4,-4,0,0);
            app.OnRobotMove += RobotMove;
            Status.Text = "Hello User";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var code = TextBox.Text;
            StartButton.IsEnabled = false;
            ResetButton.IsEnabled = false;
            Status.Text = "";
            Task.Run(() =>
            {
                app.MoveToStart();
                try
                {
                    app.Execute(code);
                }
                catch(Exception ex)
                {
                    app.MoveToStart();
                    Dispatcher.Invoke(() =>
                    {
                        Status.Text = ex.Message;
                    });
                }
                finally
                {
                    Dispatcher.Invoke(() =>
                    {
                        StartButton.IsEnabled = true;
                        ResetButton.IsEnabled = true;
                    });
                }
            });
            
        }

        private void RobotMove(object sender, RobotMoveEventArgs e)
        {
            Dispatcher.Invoke(
                () =>
                {
                    Grid.SetRow(RobotView, -e.Y + offsetY);
                    Grid.SetColumn(RobotView, e.X + offsetX);
                });
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            app.MoveToStart();
        }
    }
}
