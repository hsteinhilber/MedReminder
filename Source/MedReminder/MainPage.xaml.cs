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

namespace MedReminder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.MedicationList.Items.Add(new ViewModels.MedicineViewModel() { Name = "Tylenol", Dose = "200 mg", Frequency = "as needed", DoseVisibility = Visibility.Collapsed });
            this.MedicationList.Items.Add(new ViewModels.MedicineViewModel() { Name="Amoxicillan", Dose="100 mg", Frequency="3 times per day", DoseVisibility=Visibility.Visible, NextDose="at 2:00 pm" });
            this.MedicationList.Items.Add(new ViewModels.MedicineViewModel() { Name="Fluoxitine", Dose="40 mg", Frequency="1 time per day", DoseVisibility=Visibility.Visible, NextDose="tomorrow at 8:00 am" });
            this.MedicationList.Items.Add(new ViewModels.MedicineViewModel() { Name="Asprin", Dose="85 mg", Frequency="with a food just before bed", DoseVisibility=Visibility.Visible, NextDose="at 7:00 pm" });
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DefaultProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
