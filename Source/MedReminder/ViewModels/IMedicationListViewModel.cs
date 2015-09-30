using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReminder.ViewModels
{
    public interface IMedicationListViewModel
    {
        IList<IMedication> Medications { get; }
    }
}
