using MeltdownBoxes.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MeltdownBoxes.ViewModels.DialogBox
{
    public class DialogBoxProps : INotifyPropertyChanged
    {

        #region Props


        private string? _dialogUID;

        private double? _sizeW;
        private double? _sizeH;

        private double? _rowOne;
        private double? _rowTwo;
        private double? _rowThree;

        private ImageSource? _imSource;
        private double? _imW;
        private double? _imH;


        private string? _title;
        private string? _titleFC;
        private double? _titleFS;
        private string? _titleFW;

        private string? _message;
        private string? _mesFC;
        private string? _mesFW;
        private double? _mesFS;


        private string? _replyOneText;
        private string? _replyOneValue;
        private string? _replyTwoText;
        private string? _replyTwoValue;


        private string? _btnBack;
        private string? _btnBor;
        private double? _btnW;
        private double? _btnH;

        private double? _repBtnFS;
        private string? _repBtnFC;
        private string? _repBtnFW;


        private string? _repOBtnHC;
        private string? _repOBtnTC;

        private string? _repTBtnHC;
        private string? _repTBtnTC;



        private ICommand? _replyCommand;



        public ICommand? ReplyCommand
        {
            get
            {
                if (_replyCommand == null)
                {
                    _replyCommand = new RelayCommandValue<string>(Reply_Click);
                }
                return _replyCommand;
            }
        }


        #endregion

        #region Props Getter And Setter


        public string? DialogUID
        {
            get => _dialogUID;
            set
            {
                if (_dialogUID != value)
                {
                    _dialogUID = value;
                    OnPropertyChanged();
                }
            }
        }



        public double? SizeW
        {
            get => _sizeW;
            set
            {
                if (_sizeW != value)
                {
                    _sizeW = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? SizeH
        {
            get => _sizeH;
            set
            {
                if (_sizeH != value)
                {
                    _sizeH = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? RowOne
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

        public double? RowTwo
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

        public double? RowThree
        {
            get => _rowThree;
            set
            {
                if (_rowThree != value)
                {
                    _rowThree = value;
                    OnPropertyChanged();
                }
            }
        }

        public ImageSource? ImSource
        {
            get => _imSource;
            set
            {
                if (_imSource != value)
                {
                    _imSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? ImW
        {
            get => _imW;
            set
            {
                if (_imW != value)
                {
                    _imW = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? ImH
        {
            get => _imH;
            set
            {
                if (_imH != value)
                {
                    _imH = value;
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

        public string? TitleFC
        {
            get => _titleFC;
            set
            {
                if (_titleFC != value)
                {
                    _titleFC = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? TitleFS
        {
            get => _titleFS;
            set
            {
                if (_titleFS != value)
                {
                    _titleFS = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? TitleFW
        {
            get => _titleFW;
            set
            {
                if (_titleFW != value)
                {
                    _titleFW = value;
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

        public string? MesFC
        {
            get => _mesFC;
            set
            {
                if (_mesFC != value)
                {
                    _mesFC = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MesFW
        {
            get => _mesFW;
            set
            {
                if (_mesFW != value)
                {
                    _mesFW = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? MesFS
        {
            get => _mesFS;
            set
            {
                if (_mesFS != value)
                {
                    _mesFS = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ReplyOneText
        {
            get => _replyOneText;
            set
            {
                if (_replyOneText != value)
                {
                    _replyOneText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ReplyOneValue
        {
            get => _replyOneValue;
            set
            {
                if (_replyOneValue != value)
                {
                    _replyOneValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ReplyTwoText
        {
            get => _replyTwoText;
            set
            {
                if (_replyTwoText != value)
                {
                    _replyTwoText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ReplyTwoValue
        {
            get => _replyTwoValue;
            set
            {
                if (_replyTwoValue != value)
                {
                    _replyTwoValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? BtnBack
        {
            get => _btnBack;
            set
            {
                if (_btnBack != value)
                {
                    _btnBack = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? BtnBor
        {
            get => _btnBor;
            set
            {
                if (_btnBor != value)
                {
                    _btnBor = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? BtnW
        {
            get => _btnW;
            set
            {
                if (_btnW != value)
                {
                    _btnW = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? BtnH
        {
            get => _btnH;
            set
            {
                if (_btnH != value)
                {
                    _btnH = value;
                    OnPropertyChanged();
                }
            }
        }

        public double? RepBtnFS
        {
            get => _repBtnFS;
            set
            {
                if (_repBtnFS != value)
                {
                    _repBtnFS = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? RepBtnFC
        {
            get => _repBtnFC;
            set
            {
                if (_repBtnFC != value)
                {
                    _repBtnFC = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? RepBtnFW
        {
            get => _repBtnFW;
            set
            {
                if (_repBtnFW != value)
                {
                    _repBtnFW = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? RepOBtnHC
        {
            get => _repOBtnHC;
            set
            {
                if (_repOBtnHC != value)
                {
                    _repOBtnHC = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? RepOBtnTC
        {
            get => _repOBtnTC;
            set
            {
                if (_repOBtnTC != value)
                {
                    _repOBtnTC = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? RepTBtnHC
        {
            get => _repTBtnHC;
            set
            {
                if (_repTBtnHC != value)
                {
                    _repTBtnHC = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? RepTBtnTC
        {
            get => _repTBtnTC;
            set
            {
                if (_repTBtnTC != value)
                {
                    _repTBtnTC = value;
                    OnPropertyChanged();
                }
            }
        }




        #endregion




        protected virtual void Reply_Click(string? val) { }



        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
