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
    public sealed partial class MedicationListPage : Page
    {
        public MedicationListPage()
        {
            this.InitializeComponent();
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

        private void MedicationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int index = 0; index < MedicationList.Items.Count; ++index)
            {
                if (index == MedicationList.SelectedIndex)
                    continue;

                var flipView = findElementInVisualTree(MedicationList, index, "MedicationFlipView") as FlipView;
                if (flipView == null)
                    continue;

                flipView.SelectedIndex = 0;
            }
        }

        private void MedicationFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var flipView = sender as FlipView;
            if (flipView == null)
                return;

            if (flipView.SelectedIndex != 1)
                return;

            var item = flipView.DataContext;
            if (item == null)
                return;

            var listViewItem = MedicationList.ContainerFromItem(item) as ListViewItem;
            if (listViewItem == null)
                return;

            listViewItem.IsSelected = true;
        }

        DependencyObject findElementInVisualTree(ItemsControl itemsControl, int childIndex, string controlName)
        {
            if (childIndex >= itemsControl.Items.Count)
                return null;

            var item = itemsControl.ContainerFromIndex(childIndex);
            if (item != null)
                return getVisualTreeChild(item, controlName);

            return null;
        }

        DependencyObject getVisualTreeChild(DependencyObject obj, String name)
        {
            DependencyObject dependencyObject = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < childrenCount; i++)
            {
                var oChild = VisualTreeHelper.GetChild(obj, i);
                var childElement = oChild as FrameworkElement;
                if (childElement != null)
                {
                    //Code to take care of Paragraph/Run
                    if (childElement is RichTextBlock || childElement is TextBlock)
                    {
                        dependencyObject = childElement.FindName(name) as DependencyObject;
                        if (dependencyObject != null)
                            return dependencyObject;
                    }

                    if (childElement.Name == name)
                    {
                        return childElement;
                    }
                }
                dependencyObject = getVisualTreeChild(oChild, name);
                if (dependencyObject != null)
                    return dependencyObject;
            }
            return dependencyObject;
        }

    }
}
