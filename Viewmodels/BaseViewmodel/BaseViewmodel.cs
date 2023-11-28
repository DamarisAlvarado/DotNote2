using CommunityToolkit.Mvvm.ComponentModel;

namespace DotNote2.Viewmodels.BaseViewmodel
{
    /// <summary>
    /// Clase base para todos los viewmodels
    /// </summary>
    public partial class BaseViewmodel : ObservableObject
    {
        /// <summary>
        /// Propiedad que devuelve <i>true</i> si esta ocupado el viewmodel. <br/>
        /// En otro caso devuelve <i>false</i>. <br/>
        /// Notifica IsNotBusy por cualquier cambio que este sufra.
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        public bool isBusy;

        /// <summary>
        /// Devuelve si el viewmodel <i>true</i> si no esta ocupado. <br/>
        /// En otro caso es <i>false</i>.
        /// </summary>
        public bool IsNotBusy => !IsBusy;
    }
}
