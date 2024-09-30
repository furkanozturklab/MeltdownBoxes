using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MeltdownBoxes.Models.Structs
{


    public enum DialogSize
    {

        Small,
        Medium,
        Large,
    }


    public enum DialogType
    {
        Confirmation,
        Continue,
        Retry,
        Warning,
    }



    public enum DialogPlacement
    {
        TopLeft,
        TopRight,
        TopCenter,
        BottomLeft,
        BottomRight,
        BottomCenter,
        Center,
        CenterLeft,
        CenterRight,
    }



    public struct DialogSizeOptions
    {

        public double SizeWidth { get; set; }
        public double SizeHeight { get; set; }


        public double RowOne { get; set; }
        public double RowTwo { get; set; }
        public double RowThree { get; set; }

        public double ImageWidth { get; set; }
        public double ImageHeight { get; set; }

        public double TitleFontSize { get; set; }
        public double MessageFontSize { get; set; }
        public string TitleFontWeight { get; set; }
        public string MessageFontWeight { get; set; }


        public double ReplyButtonWidth { get; set; }
        public double ReplyButtonHeight { get; set; }
        public double ReplyButtonFontSize { get; set; }
        public string ReplyButtonFontWeight { get; set; }


        private DialogSizeOptions(double width, double height, double ro, double rt, double rth, double iw, double ih, double tf, double mf, string tfw, string mfw, double bw, double bh, double bf, string bfw)
        {


            SizeWidth = width;
            SizeHeight = height;
            RowOne = ro;
            RowTwo = rt;
            RowThree = rth;
            ImageWidth = iw;
            ImageHeight = ih;
            TitleFontSize = tf;
            MessageFontSize = mf;
            TitleFontWeight = tfw;
            MessageFontWeight = mfw;
            ReplyButtonWidth = bw;
            ReplyButtonHeight = bh;
            ReplyButtonFontSize = bf;
            ReplyButtonFontWeight = bfw;
        }



        public static DialogSizeOptions GetSizeOptions(DialogSize sizeType)
        {

            return sizeType switch
            {

                DialogSize.Small => new DialogSizeOptions(400, 200, 90, 60, 50, 46, 46, 14, 12, "Medium", "Normal", 100, 30, 12, "Medium"),
                DialogSize.Medium => new DialogSizeOptions(500, 300, 150, 80, 70, 86, 86, 18, 14, "SemiBold", "Medium", 150, 35, 14, "SemiBold"),
                DialogSize.Large => new DialogSizeOptions(600, 400, 200, 100, 100, 124, 124, 18, 14, "SemiBold", "Medium", 180, 40, 16, "SemiBold"),
                _ => throw new ArgumentOutOfRangeException(nameof(sizeType), sizeType, null)
            };

        }
    }

    public struct DialogTypeOptions
    {


        public ImageSource ImageSrc { get; set; }


        public string TitleColor { get; set; }
        public string MessageColor { get; set; }


        public string ReplyOneText { get; set; }
        public string ReplyTwoText { get; set; }
        public string ReplyOneValue { get; set; }
        public string ReplyTwoValue { get; set; }


        public string ReplyButtonBack { get; set; }
        public string ReplyButtonBorder { get; set; }
        public string ReplyButtonTextColor { get; set; }
        public string ReplyOneButtonHoverColor { get; set; }
        public string ReplyOneButtonHoverTextColor { get; set; }
        public string ReplyTwoButtonHoverColor { get; set; }
        public string ReplyTwoButtonHoverTextColor { get; set; }




        private DialogTypeOptions(ImageSource src, string tc, string mc, string rot, string rtt, string rov, string rtv, string rbb, string rbbo, string rbc, string robhc, string robhtc, string rtbhc, string rtbhtc)
        {
            ImageSrc = src;
            TitleColor = tc;
            MessageColor = mc;
            ReplyOneText = rot;
            ReplyTwoText = rtt;
            ReplyOneValue = rov;
            ReplyTwoValue = rtv;

            ReplyButtonBack = rbb;
            ReplyButtonBorder = rbbo;
            ReplyButtonTextColor = rbc;
            ReplyOneButtonHoverColor = robhc;
            ReplyOneButtonHoverTextColor = robhtc;
            ReplyTwoButtonHoverColor = rtbhc;
            ReplyTwoButtonHoverTextColor = rtbhtc;
        }



        public static DialogTypeOptions GetDialogTypeOptions(DialogType dialogType, ResourceDictionary rs)
        {
            return dialogType switch
            {

                DialogType.Confirmation => new DialogTypeOptions((DrawingImage)rs["ConfirmedDrawingImage"], "#1e293b", "#475569", "Yes", "No", "true", "false", "#F5F7FA", "#CBD0DD", "#1e293b", "#22c55e", "#FFFFFF", "#dc2626", "#FFFFFF"),
                DialogType.Continue => new DialogTypeOptions((DrawingImage)rs["ContinueDrawingImage"], "#1e293b", "#475569", "Continue", "Cancel", "true", "false", "#F5F7FA", "#CBD0DD", "#1e293b", "#54C4CC", "#FFFFFF", "#fbbf24", "#1e293b"),
                DialogType.Retry => new DialogTypeOptions((DrawingImage)rs["RetryDrawingImage"], "#1e293b", "#475569", "Continue", "Cancel", "true", "false", "#F5F7FA", "#CBD0DD", "#1e293b", "#22c55e", "#FFFFFF", "#dc2626", "#FFFFFF"),
                DialogType.Warning => new DialogTypeOptions((DrawingImage)rs["WarningDrawingImage"], "#1e293b", "#475569", "Yes", "No", "true", "false", "#F5F7FA", "#CBD0DD", "#1e293b", "#22c55e", "#FFFFFF", "#dc2626", "#FFFFFF"),
                _ => throw new ArgumentOutOfRangeException(nameof(dialogType), dialogType, null)
            };

        }

    }


    public struct DialogPlacementOptions
    {


        public double HorizontalOffsetV { get; set; }
        public double VerticalOffsetV { get; set; }


        private DialogPlacementOptions(double horizontalOffsetV, double verticalOffsetV)
        {

            HorizontalOffsetV = horizontalOffsetV;
            VerticalOffsetV = verticalOffsetV;

        }


        public static DialogPlacementOptions GetPlacementOption(DialogPlacement placementType, double screenWidth, double screenHeight, double popupWidth, double popupHeight, double padding)
        {



            return placementType switch
            {

                DialogPlacement.TopLeft => new DialogPlacementOptions(padding, padding),
                DialogPlacement.TopRight => new DialogPlacementOptions((screenWidth - popupWidth - padding), padding),
                DialogPlacement.BottomLeft => new DialogPlacementOptions(padding, (screenHeight - popupHeight - padding)),
                DialogPlacement.BottomRight => new DialogPlacementOptions((screenWidth - popupWidth - padding), (screenHeight - popupHeight - padding)),
                DialogPlacement.Center => new DialogPlacementOptions(((screenWidth - popupWidth) / 2), ((screenHeight - popupHeight) / 2)),
                DialogPlacement.TopCenter => new DialogPlacementOptions(((screenWidth - popupWidth) / 2), padding),
                DialogPlacement.BottomCenter => new DialogPlacementOptions(((screenWidth - popupWidth) / 2), (screenHeight - popupHeight - padding)),
                DialogPlacement.CenterLeft => new DialogPlacementOptions(padding, ((screenHeight - popupHeight) / 2)),
                DialogPlacement.CenterRight => new DialogPlacementOptions((screenWidth - popupWidth - padding), ((screenHeight - popupHeight) / 2)),

                _ => throw new ArgumentOutOfRangeException(nameof(placementType), placementType, null)
            };
        }

    }
}
