using MeltdownBoxes.Controls;
using MeltdownBoxes.Models.Structs;
using MeltdownBoxes.ViewModels.DialogBox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeltdownBoxes.View
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : UserControl, IDisposable
    {

        private DialogBoxVm? _vm;
        public DialogBox(DialogType dialogType, string message, string? title)
        {
            try
            {
                InitializeComponent();

                Guid uniqueId = Guid.NewGuid();
                _vm = new DialogBoxVm(BoxController.DialogControllerSize, dialogType, uniqueId.ToString(), message, title);
                DataContext = _vm;
            }
            catch (Exception)
            {

                throw new InvalidOperationException("Could not create DialogBox");
            }
        }


        public DialogBoxVm GetVm()
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
                Debug.WriteLine("DialogBox dispose");
                _vm?.Dispose();
                _vm = null;
            }
            _disposed = true;
        }

        ~DialogBox()
        {
            Dispose(false);
        }

        #endregion
    }
}
