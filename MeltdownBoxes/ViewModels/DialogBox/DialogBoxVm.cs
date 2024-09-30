using MeltdownBoxes.Models.Structs;
using System.Diagnostics;
using System.Windows;

namespace MeltdownBoxes.ViewModels.DialogBox
{


    public class DialogBoxVm : DialogBoxProps, IDisposable
    {
        ResourceDictionary? resourceDictionary = new ResourceDictionary();

        private DialogType? _dialogType = null;

        private TaskCompletionSource<string>? _tcs;

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
                Debug.WriteLine("DialogBoxVm Dispose start");

                resourceDictionary = null;
                _dialogType = null;
                _tcs = null;

            }
            _disposed = true;
        }

        ~DialogBoxVm()
        {
            Dispose(false);
        }


        #endregion





        public DialogBoxVm(DialogSize sizeType, DialogType dialogType, string uID, string message, string? title)
        {

            try
            {


                _tcs = new TaskCompletionSource<string>();

                resourceDictionary.Source = new Uri("pack://application:,,,/MeltdownBoxes;component/Resources/DialogStyle.xaml");
                DialogSizeOptions sizeO = DialogSizeOptions.GetSizeOptions(sizeType);

                SizeW = sizeO.SizeWidth;
                SizeH = sizeO.SizeHeight;
                RowOne = sizeO.RowOne;
                RowTwo = sizeO.RowTwo;
                RowThree = sizeO.RowThree;
                ImW = sizeO.ImageWidth;
                ImH = sizeO.ImageHeight;
                TitleFS = sizeO.TitleFontSize;
                TitleFW = sizeO.TitleFontWeight;
                MesFS = sizeO.MessageFontSize;
                MesFW = sizeO.MessageFontWeight;
                BtnW = sizeO.ReplyButtonWidth;
                BtnH = sizeO.ReplyButtonHeight;
                RepBtnFS = sizeO.ReplyButtonFontSize;
                RepBtnFW = sizeO.ReplyButtonFontWeight;


                DialogTypeOptions typeO = DialogTypeOptions.GetDialogTypeOptions(dialogType, resourceDictionary);
                _dialogType = dialogType;

                ImSource = typeO.ImageSrc;
                TitleFC = typeO.TitleColor;
                MesFC = typeO.MessageColor;
                ReplyOneText = typeO.ReplyOneText;
                ReplyOneValue = typeO.ReplyOneValue;
                ReplyTwoText = typeO.ReplyTwoText;
                ReplyTwoValue = typeO.ReplyTwoValue;

                BtnBack = typeO.ReplyButtonBack;
                BtnBor = typeO.ReplyButtonBorder;

                RepBtnFC = typeO.ReplyButtonTextColor;
                RepOBtnHC = typeO.ReplyOneButtonHoverColor;
                RepOBtnTC = typeO.ReplyOneButtonHoverTextColor;
                RepTBtnHC = typeO.ReplyTwoButtonHoverColor;
                RepTBtnTC = typeO.ReplyTwoButtonHoverTextColor;


                Title = title;
                Message = message;

                ReplyOneText = typeO.ReplyOneText;
                ReplyTwoText = typeO.ReplyTwoText;
                ReplyOneValue = typeO.ReplyOneValue;
                ReplyTwoValue = typeO.ReplyTwoValue;



            }
            catch (Exception)
            {
                throw new InvalidOperationException("Could not create DialogBoxVm");

            }
        }

        protected override void Reply_Click(string? val)
        {
            _tcs!.SetResult(val ?? string.Empty);
        }

        public Task<string> ShowDialogAsync()
        {
            return _tcs!.Task;
        }


    }
}
