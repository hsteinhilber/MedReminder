using Windows.UI.Xaml;

namespace MedReminder.ViewModels
{
    public interface IMedication
    {
        string Dose { get; }
        Visibility DoseVisibility { get; }
        string Frequency { get; }
        string Name { get; }
        string NextDose { get; }
    }
}