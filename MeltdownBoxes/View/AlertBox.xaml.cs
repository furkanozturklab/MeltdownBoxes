using MeltdownBoxes.Controls;
using MeltdownBoxes.Models.Structs;
using MeltdownBoxes.ViewModels;
using System.Diagnostics;
using System.Windows.Controls;


namespace MeltdownBoxes.View
{
    /// <summary>
    /// Interaction logic for AlertBox.xaml
    /// </summary>
    public partial class AlertBox : UserControl, IDisposable
    {
        private AlertBoxVm? _vm;

        public AlertBox(AlertType type, string message, string? title)
        {
            try
            {
                InitializeComponent();

                Guid uniqueId = Guid.NewGuid();
                _vm = new AlertBoxVm(BoxController.AlertControllerSize, type, uniqueId.ToString(), message, title);

                DataContext = _vm;
            }
            catch (Exception)
            {

                throw new InvalidOperationException("Could not create AlertBox message");
            }

        }

        public AlertBoxVm GetVm()
        {
            return _vm!;
        }


        #region Dispose Methods

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Debug.WriteLine("AlertBox dispose");
                _vm = null;
            }
            _disposed = true;
        }

        ~AlertBox()
        {
            Dispose(false);
        }

        #endregion
    }
}
