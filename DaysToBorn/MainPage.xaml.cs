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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DaysToBorn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DateTime conceptionDate = new DateTime(2015, 9, 12);
            DateTime birthday = new DateTime(2016, 6, 18);
            txtConceptionDate.Text = conceptionDate.ToString("dd/MM/yyyy");
            txtBirthDate.Text = birthday.ToString("dd/MM/yyyy");
            var daysActual = Convert.ToInt32((DateTime.Today - conceptionDate).TotalDays);
            var daysRemaining = Convert.ToInt32((birthday - DateTime.Today).TotalDays);

            txtTimeActual.Text = WeekFormat(daysActual);
            txtTimeRemaining.Text = WeekFormat(daysRemaining);

        }

        private string WeekFormat(int days)
        {
            string weeks = days / 7 + " semanas";
            if (days % 7 != 0)
            {
                weeks += " y ";
                if (days % 7 == 1)
                    weeks += "1 día";
                else
                    weeks += days % 7 + " días";
            }
            return weeks;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SplitViewPane_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                MySplitView.IsPaneOpen = false;
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
