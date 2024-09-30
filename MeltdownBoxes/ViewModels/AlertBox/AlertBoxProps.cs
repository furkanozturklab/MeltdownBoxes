using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MeltdownBoxes.ViewModels
{
    public class AlertBoxProps : INotifyPropertyChanged
    {




        #region Props


        private double _columOne;
        private double _columTwo;
        private double _columThree;
        private double _columFour;


        private double _rowOne;
        private double _rowTwo;


        private double _sizeWidth = 0;
        private double _sizeHeight = 0;
        private string? _message;
        private string? _title;

        private double? _titleFontSizeV = 14;
        private string? _titleFontWeightsV = "SemiBold";

        private double? _messageFontSizeV = 12;
        private string? _messageFontWeightsV = "Medium";



        private string? _alertUID;


        private string? _typeBackgroundColors;
        private string? _typeColors;
        private string? _stringColor;
        private string? _hoverColor;



        private int _imageWidth;
        private int _imageHeight;
        private ImageSource? _imageSource;
        private ImageSource? _closedImageSource;


        private double? _progressWidth;


        private double? _closedWidth;
        private double? _closedHeight;
        private double? _closedIconWidth;
        private double? _closedIconHeight;


        public ICommand? ClosedClick { get; set; }

        #endregion




        #region Getter And Setter


        public double SizeWidth
        {
            get => _sizeWidth;
            set
            {
                if (_sizeWidth != value)
                {
                    _sizeWidth = value;
                    OnPropertyChanged();
                }
            }
        }

        public double SizeHeight
        {
            get => _sizeHeight;
            set
            {
                if (_sizeHeight != value)
                {
                    _sizeHeight = value;
                    OnPropertyChanged();
                }
            }
        }



        public string? Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? AlertUID
        {
            get => _alertUID;
            set
            {
                if (_alertUID != value)
                {
                    _alertUID = value;
                    OnPropertyChanged();
                }
            }
        }
        public double? TitleFontSizeV
        {
            get => _titleFontSizeV;
            set
            {
                if (_titleFontSizeV != value)
                {
                    _titleFontSizeV = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? TitleFontWeightsV
        {
            get => _titleFontWeightsV;
            set
            {
                if (_titleFontWeightsV != value)
                {
                    _titleFontWeightsV = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? MessageFontSizeV
        {
            get => _messageFontSizeV;
            set
            {
                if (_messageFontSizeV != value)
                {
                    _messageFontSizeV = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MessageFontWeightsV
        {
            get => _messageFontWeightsV;
            set
            {
                if (_messageFontWeightsV != value)
                {
                    _messageFontWeightsV = value;
                }
            }
        }


        public string? TypeBackgroundColors
        {
            get => _typeBackgroundColors;
            set
            {
                if (_typeBackgroundColors != value)
                {
                    _typeBackgroundColors = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? TypeColors
        {
            get => _typeColors;
            set
            {
                if (_typeColors != value)
                {
                    _typeColors = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? StringColor
        {
            get => _stringColor;
            set
            {
                if (_stringColor != value)
                {
                    _stringColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? HoverColor
        {
            get => _hoverColor;
            set
            {
                if (_hoverColor != value)
                {
                    _hoverColor = value;
                    OnPropertyChanged();
                }
            }
        }



        public ImageSource? ImageSource
        {
            get => _imageSource;
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public ImageSource? ClosedImageSource
        {
            get => _closedImageSource;
            set
            {
                if (_closedImageSource != value)
                {
                    _closedImageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ImageWidth
        {
            get => _imageWidth;
            set
            {
                if (_imageWidth != value)
                {
                    _imageWidth = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ImageHeight
        {
            get => _imageHeight;
            set
            {
                if (_imageHeight != value)
                {
                    _imageHeight = value;
                    OnPropertyChanged();
                }
            }
        }


        public double? ProgressWidth
        {
            get => _progressWidth;
            set
            {
                if (_progressWidth != value)
                {
                    _progressWidth = value;
                    OnPropertyChanged();
                }
            }
        }


        public double? ClosedWidth
        {
            get => _closedWidth;
            set
            {
                if (_closedWidth != value)
                {
                    _closedWidth = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? ClosedHeight
        {
            get => _closedHeight;
            set
            {
                if (_closedHeight != value)
                {
                    _closedHeight = value;
                    OnPropertyChanged();
                }
            }
        }


        public double? ClosedIconWidth
        {
            get => _closedIconWidth;
            set
            {
                if (_closedIconWidth != value)
                {
                    _closedIconWidth = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? ClosedIconHeight
        {
            get => _closedIconHeight;
            set
            {
                if (_closedIconHeight != value)
                {
                    _closedIconHeight = value;
                    OnPropertyChanged();
                }
            }
        }

        public double ColumnOne
        {
            get => _columOne;
            set
            {
                if (_columOne != value)
                {
                    _columOne = value;
                    OnPropertyChanged();
                }
            }
        }

        public double ColumnTwo
        {
            get => _columTwo;
            set
            {
                if (_columTwo != value)
                {
                    _columTwo = value;
                    OnPropertyChanged();
                }
            }
        }

        public double ColumnThree
        {
            get => _columThree;
            set
            {
                if (_columThree != value)
                {
                    _columThree = value;
                    OnPropertyChanged();
                }
            }
        }

        public double ColumnFour
        {
            get => _columFour;
            set
            {
                if (_columFour != value)
                {
                    _columFour = value;
                    OnPropertyChanged();
                }
            }
        }

        public double RowOne
        {
            get => _rowOne;
            set
            {
                if (_rowOne != value)
                {
                    _rowOne = value;
                    OnPropertyChanged();
                }
            }
        }

        public double RowTwo
        {
            get => _rowTwo;
            set
            {
                if (_rowTwo != value)
                {
                    _rowTwo = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion








        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
