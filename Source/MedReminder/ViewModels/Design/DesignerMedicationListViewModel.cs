using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MedReminder.ViewModels.Design
{
    public class DesignerMedicationListViewModel : IMedicationListViewModel
    {
        private List<IMedication> _medications;

        public IList<IMedication> Medications
        {
            get
            {
                return _medications ?? (_medications = new List<IMedication>()
                {
                    new DesignerMedication() { Name="Tylenol" , Dose="200 mg" , Frequency="as needed" , DoseVisibility=Visibility.Collapsed },
                    new DesignerMedication() { Name="Amoxicillan" , Dose="300 mg" , Frequency="3 times per day" , DoseVisibility=Visibility.Visible , NextDose="at 2:00 pm" },
                    new DesignerMedication() { Name="Fluoxetine" , Dose="40 mg" , Frequency="1 time per day" , DoseVisibility=Visibility.Visible , NextDose="tomorrow at 8:00 am" },
                    new DesignerMedication() { Name="Asprin" , Dose="85 mg" , Frequency="2 times per day" , DoseVisibility=Visibility.Visible , NextDose="at 8:00 pm" },
                    new DesignerMedication() { Name="Prazosin" , Dose="20 mg" , Frequency="one pill in the am, two pills just before bed" , DoseVisibility=Visibility.Visible , NextDose="at 8:00 pm" }
                });
            }
        }

        public class DesignerMedication : IMedication
        {
            public string Name { get; set; }
            public string Dose { get; set; }
            public string Frequency { get; set; }
            public Visibility DoseVisibility { get; set; }
            public string NextDose { get; set; }
        }
    }
}