using MeltdownBoxes.Controls;
using MeltdownBoxes.Models.Structs;
using MeltdownBoxes.ViewModels.Commands;

using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace MeltdownBoxes.ViewModels
{
    public class AlertBoxVm : AlertBoxProps, IDisposable
    {
        ResourceDictionary? resourceDictionary = new ResourceDictionary();

        public delegate void EndTimerEventHandler(object sender, string endName);

        public event EndTimerEventHandler? EndTimer;

        private DispatcherTimer? _timer = new DispatcherTimer(DispatcherPriority.Render);


        #region TimerProps


        private int? _duration;
        private double? _initialWidth;
        private double? _targetWidth = 0;
        private double? _currentWidth;
        private int? _elapsedTime = 0;


        #endregion


        #region Dispose Methods


        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Debug.WriteLine("AlertBoxVm Dispose start");

                _timer!.Tick -= DispatcherTimer_Tick;
                _timer = null;
                _duration = null;
                _initialWidth = null;
                _targetWidth = null;
                _currentWidth = null;
                _elapsedTime = null;
                resourceDictionary = null;
                EndTimer = null;
            }
            _disposed = true;
        }


        ~AlertBoxVm()
        {
            Dispose(false);
        }


        #endregion



        public AlertBoxVm(AlertSize sizeType, AlertType alertType, string uId, string message, string? title = null, int? duration = 3000)
        {
            try
            {
                resourceDictionary.Source = new Uri("pack://application:,,,/MeltdownBoxes;component/Resources/AlertStyles.xaml");


                // SİZE SETTER
                AlertSizeOptions sizeO = AlertSizeOptions.GetSizeOption(sizeType);

                SizeWidth = sizeO.SizeWidth;
                SizeHeight = sizeO.SizeHeight;

                ColumnOne = sizeO.ColumnOne;
                ColumnTwo = sizeO.ColumnTwo;
                ColumnThree = sizeO.ColumnThree;
                ColumnFour = sizeO.ColumnFour;

                RowOne = sizeO.RowOne;
                RowTwo = sizeO.RowTwo;

                TitleFontSizeV = sizeO.TitleFontSize;
                TitleFontWeightsV = sizeO.TitleFontWeight;

                MessageFontSizeV = sizeO.MessageFontSize;
                MessageFontWeightsV = sizeO.MessageFontWeight;
                ImageWidth = sizeO.ImageWidth;
                ImageHeight = sizeO.ImageHeight;
                ProgressWidth = sizeO.ProgressWidth;

                ClosedWidth = sizeO.ClosedWidth;
                ClosedHeight = sizeO.ClosedHeight;

                ClosedIconWidth = sizeO.ClosedIconWidth;
                ClosedIconHeight = sizeO.ClosedIconHeight;

                ClosedClick = new RelayCommand(CommandExecute);


                // STYLE SETTER
                AlertTypeOptions typeO = AlertTypeOptions.GetTypeOption(alertType, resourceDictionary);

                ImageSource = typeO.ImageSource;
                ClosedImageSource = typeO.ClosedSource;
                TypeBackgroundColors = typeO.BackgroundColors;
                TypeColors = typeO.Colors;
                StringColor = typeO.StringColor;
                HoverColor = typeO.HoverColor;


                // CONTENT SETTER
                Title = title;
                Message = message;
                AlertUID = uId;


                // TIMER SETTER
                _timer.Interval = TimeSpan.FromMilliseconds(15);
                _timer.Tick += DispatcherTimer_Tick;
                _duration = BoxController.ShowDuration;// 3 seconds 3000 milisaniye default
         
                _initialWidth = ProgressWidth;
                _currentWidth = _initialWidth;

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace); 
                throw new InvalidOperationException("Could not create AlertBoxVm");
            }


        }


        public void StartTimer()
        {
            if (_timer != null)
            {
                _timer.Start();
            }
        }


        private void CommandExecute(object? parameter)
        {
            _duration = 0;
        }



        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            _elapsedTime += _timer!.Interval.Milliseconds;
            _currentWidth = _initialWidth - (_initialWidth - _targetWidth) * (_elapsedTime / (double)_duration!);
            if (_currentWidth > 0) ProgressWidth = _currentWidth;
            if (_elapsedTime >= _duration)
            {
                ProgressWidth = 0;
                _timer.Stop();
                if (AlertUID != null)
                {
                    EndTimer?.Invoke(this, AlertUID);
                    this.Dispose();
                }
            }
        }

    }
}
