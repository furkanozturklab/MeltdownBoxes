using System.Windows.Media;
using System.Windows;

namespace MeltdownBoxes.Models.Structs
{

    public enum AlertSize
    {
        Small,
        Medium,
        Large
    }

    public enum AlertType
    {
        Error,
        Warning,
        Information,
        Success,
        Other,
    }

    public enum AlertPlacement
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

    public struct AlertSizeOptions
    {
        public double SizeWidth { get; set; }
        public double SizeHeight { get; set; }

        public double ColumnOne { get; set; }
        public double ColumnTwo { get; set; }
        public double ColumnThree { get; set; }
        public double ColumnFour { get; set; }

        public double RowOne { get; set; }
        public double RowTwo { get; set; }

        public double TitleFontSize { get; set; }
        public string TitleFontWeight { get; set; }
        public double MessageFontSize { get; set; }
        public string MessageFontWeight { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public double ProgressWidth { get; set; }
        public double ClosedWidth { get; set; }
        public double ClosedHeight { get; set; }

        public double ClosedIconWidth { get; set; }
        public double ClosedIconHeight { get; set; }


        private AlertSizeOptions(double sWidth, double sHeight, double cO, double cT, double cTh, double cF, double rO, double rT, double tSize, string tWei, double mSize, string mWei, int iWidth, int iHeight, double pWidth, double cWidth, double cHeight, double cIW, double cIH)
        {
            SizeWidth = sWidth;
            SizeHeight = sHeight;
            ColumnOne = cO;
            ColumnTwo = cT;
            ColumnThree = cTh;
            ColumnFour = cF;
            RowOne = rO;
            RowTwo = rT;
            TitleFontSize = tSize;
            TitleFontWeight = tWei;
            MessageFontSize = mSize;
            MessageFontWeight = mWei;
            ImageWidth = iWidth;
            ImageHeight = iHeight;
            ProgressWidth = pWidth;

            ClosedWidth = cWidth;
            ClosedHeight = cHeight;

            ClosedIconWidth = cIW;
            ClosedIconHeight = cIH;
        }

        public static AlertSizeOptions GetSizeOption(AlertSize sizeType)
        {
            return sizeType switch
            {
                AlertSize.Small => new AlertSizeOptions(350, 60, 3, 38, 273, 36, 57, 3, 10, "SemiBold", 8, "Medium", 18, 18, 350, 24, 24, 14, 14),
                AlertSize.Medium => new AlertSizeOptions(500, 80, 5, 56, 383, 56, 75, 5, 13, "SemiBold", 11, "Medium", 28, 28, 500, 28, 28, 16, 16),
                AlertSize.Large => new AlertSizeOptions(650, 100, 5, 64, 517, 64, 95, 5, 14, "SemiBold", 12, "Medium", 32, 32, 650, 36, 36, 18, 18),
                _ => throw new ArgumentOutOfRangeException(nameof(sizeType), sizeType, null)
            };
        }
    }

    public struct AlertTypeOptions
    {

        public string BackgroundColors { get; set; }
        public string Colors { get; set; }
        public string StringColor { get; set; }
        public string HoverColor { get; set; }
        public ImageSource ImageSource { get; set; }
        public ImageSource ClosedSource { get; set; }

        public AlertTypeOptions(string bg, string c, string sC, string hC, ImageSource iS, ImageSource cS)
        {
            BackgroundColors = bg;
            Colors = c;
            StringColor = sC;
            HoverColor = hC;
            ImageSource = iS;
            ClosedSource = cS;
        }


        public static AlertTypeOptions GetTypeOption(AlertType alertType, ResourceDictionary rs)
        {
            return alertType switch
            {
                AlertType.Error => new AlertTypeOptions("#fef2f2", "#dc2626", "#9a3412", "#FECACA", (DrawingImage)rs["alertErrorDrawingImage"], (DrawingImage)rs["closedErrorDrawingImage"]),
                AlertType.Warning => new AlertTypeOptions("#FFF7ED", "#EA580C", "#991b1b", "#fed7aa", (DrawingImage)rs["alertWarningDrawingImage"], (DrawingImage)rs["closedWarningDrawingImage"]),
                AlertType.Information => new AlertTypeOptions("#f0f9ff", "#0284c7", "#0c4a6e", "#bae6fd", (DrawingImage)rs["alertInfoDrawingImage"], (DrawingImage)rs["closedInfoDrawingImage"]),
                AlertType.Success => new AlertTypeOptions("#f0fdf4", "#16a34a", "#166534", "#bbf7d0", (DrawingImage)rs["alertSuccessDrawingImage"], (DrawingImage)rs["closedSuccessDrawingImage"]),
                AlertType.Other => new AlertTypeOptions("#F8FAFC", "#475569", "#0f172a", "#e2e8f0", (DrawingImage)rs["alertOtherDrawingImage"], (DrawingImage)rs["closedOtherDrawingImage"]),

                _ => throw new ArgumentOutOfRangeException(nameof(alertType), alertType, null)
            };
        }

    }


    public struct AlertPlacementOptions
    {


        public double HorizontalOffsetV { get; set; }
        public double VerticalOffsetV { get; set; }


        private AlertPlacementOptions(double horizontalOffsetV, double verticalOffsetV)
        {

            HorizontalOffsetV = horizontalOffsetV;
            VerticalOffsetV = verticalOffsetV;

        }


        public static AlertPlacementOptions GetPlacementOption(AlertPlacement placementType, double screenWidth, double screenHeight, double popupWidth, double popupHeight, double padding)
        {



            return placementType switch
            {

                AlertPlacement.TopLeft => new AlertPlacementOptions(padding, padding),
                AlertPlacement.TopRight => new AlertPlacementOptions((screenWidth - popupWidth - padding), padding),
                AlertPlacement.BottomLeft => new AlertPlacementOptions(padding, (screenHeight - popupHeight - padding)),
                AlertPlacement.BottomRight => new AlertPlacementOptions((screenWidth - popupWidth - padding), (screenHeight - popupHeight - padding)),
                AlertPlacement.Center => new AlertPlacementOptions(((screenWidth - popupWidth) / 2), ((screenHeight - popupHeight) / 2)),
                AlertPlacement.TopCenter => new AlertPlacementOptions(((screenWidth - popupWidth) / 2), padding),
                AlertPlacement.BottomCenter => new AlertPlacementOptions(((screenWidth - popupWidth) / 2), (screenHeight - popupHeight - padding)),
                AlertPlacement.CenterLeft => new AlertPlacementOptions(padding, ((screenHeight - popupHeight) / 2)),
                AlertPlacement.CenterRight => new AlertPlacementOptions((screenWidth - popupWidth - padding), ((screenHeight - popupHeight) / 2)),

                _ => throw new ArgumentOutOfRangeException(nameof(placementType), placementType, null)
            };
        }

    }
}
