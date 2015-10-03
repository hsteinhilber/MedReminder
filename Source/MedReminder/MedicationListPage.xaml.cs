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

                var flipView = findElementInItemsControlItemAtIndex(MedicationList, index, "MedicationFlipView") as FlipView;
                if (flipView == null)
                    continue;

                flipView.SelectedIndex = 0;
            }
        }

        DependencyObject findElementInItemsControlItemAtIndex(ItemsControl itemsControl,
                                                                int itemOfIndexToFind,
                                                                string nameOfControlToFind)
        {
            if (itemOfIndexToFind >= itemsControl.Items.Count) return null;

            DependencyObject depObj = null;
            object o = itemsControl.Items[itemOfIndexToFind];
            if (o != null)
            {
                var item = itemsControl.ContainerFromItem(o);
                if (item != null)
                {
                    //GridViewItem it = item as GridViewItem;
                    //var i = it.FindName(nameOfControlToFind);
                    depObj = getVisualTreeChild(item, nameOfControlToFind);
                    return depObj;
                }
            }
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
