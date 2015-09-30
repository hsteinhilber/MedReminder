using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MedReminder.ViewModels
{
    public class MedicineViewModel
    {
        public string Name { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public Visibility DoseVisibility { get; set; }
        public string NextDose { get; set; }
    }
}
