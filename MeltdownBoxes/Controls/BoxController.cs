using MeltdownBoxes.Models.Structs;
using MeltdownBoxes.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using static MeltdownBoxes.ViewModels.AlertBoxVm;

namespace MeltdownBoxes.Controls
{
    public static class BoxController
    {


        // Required for positioning
        // It is used for positioning popups.
        private static double _screenWidth = SystemParameters.PrimaryScreenWidth;
        private static double _screenHeight = SystemParameters.PrimaryScreenHeight;

        #region AlertBox

        // Alert Box Structures
        // The popup to be used for displaying the AlertBox.
        private static Popup _alertPopup = new Popup
        {
            AllowsTransparency = true,
            Child = null,
        };

        // It will be used to load multiple alert box objects into the popup.
        private static StackPanel _alertStack = new StackPanel
        {
            Orientation = Orientation.Vertical
        };


        // AlertBox Variables

        private static bool _isAlertBoxInitialize = false;
        private static bool _alertIsOpen = false;
        private static Queue<AlertBox> _bufferAlertBoxList = new Queue<AlertBox>();

        // AlertBox creation props
        public static AlertSize AlertControllerSize = AlertSize.Medium;
        public static int MaxChild = 6;
        public static int MaxBufferChild = 20;
        public static int ShowDuration = 3000;
        public static PopupAnimation _popupAnimation = PopupAnimation.Fade;

        #endregion



        #region DialogBox

        // DialogBox Variables
        private static bool _isDialogBoxInitialize = false;

        // The popup to be used for displaying the DialogBox.
        private static Popup _dialogPopup = new Popup
        {
            AllowsTransparency = true,
            StaysOpen = true,
            PopupAnimation = PopupAnimation.Fade,
        };

        // DialogBox creation props

        public static DialogSize DialogControllerSize = DialogSize.Medium;

        #endregion



        #region AlertBox Methodes



        /// <summary>
        /// Used to set constants for creating AlertBox instances during the initial program startup. 
        /// If this step is not initialized, the AlertBox will throw an error.
        /// </summary>
        /// <param name="sizeType">Enum value to set the size of the AlertBox.</param>
        /// <param name="placement">Enum value to determine the position where the AlertBox will be displayed.</param>
        /// <param name="popupAnimation">Determines the animation used to display the AlertBox. Accepts a <code>PopupAnimation</code> value.</param>
        /// <param name="maxChild">Specifies the maximum number of AlertBoxes to be displayed simultaneously. Default is 6.</param>
        /// <param name="duration">Specifies the time (in milliseconds) the AlertBox will remain on the screen. Default is 3000ms.</param>
        /// <param name="maxBuffer">Determines the maximum number of objects that can be created after exceeding the maxChild count. Default is 20.</param>
        /// <returns>Does not return a value. Throws <see cref="InvalidOperationException"/> if an error occurs.</returns>
        public static void AlertBoxInitialize(AlertSize sizeType, AlertPlacement placement, PopupAnimation? popupAnimation, int? maxChild, double? duration, int? maxBuffer)
        {
            try
            {
                AlertControllerSize = sizeType;

                var control = AlertSizeOptions.GetSizeOption(AlertControllerSize);
                var placementSize = AlertPlacementOptions.GetPlacementOption(placement, _screenWidth, _screenHeight, control.SizeWidth, control.SizeHeight, 10);

                _alertPopup.HorizontalOffset = placementSize.HorizontalOffsetV;
                _alertPopup.VerticalOffset = placementSize.VerticalOffsetV;

                if (maxChild != null) MaxChild = (int)maxChild;
                if (duration != null) ShowDuration = (int)duration;
                if (maxBuffer != null) MaxBufferChild = (int)maxBuffer;
                if (popupAnimation != null) _alertPopup.PopupAnimation = popupAnimation.Value;
                _isAlertBoxInitialize = true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("AlertBox could not be set!");
            }

        }



        /// <summary>
        /// Used to display AlertBox objects on a single popup without using multiple popups. 
        /// As a starting value, it can display content up to the number of children set by <see cref="AlertBoxInitialize"/>.
        /// </summary>
        /// <param name="alertBox">Accepts an AlertBox object as a child.</param>
        /// <returns>Does not return a value.</returns>
        /// <exception cref="Exception">Returns the default error state for any potential error that may occur.</exception>
        private static void StackPanelItems_Add(AlertBox alertBox)
        {
            try
            {
                if (_alertStack.Children.Count == 0 && _alertIsOpen == false)
                {
                    if (_alertPopup.Child == null) _alertPopup.Child = _alertStack;
                    _alertPopup.IsOpen = true;
                    _alertIsOpen = true;
                    _alertStack.Children.Add(alertBox);
                    alertBox.GetVm().StartTimer();
                }
                else
                {
                    _alertStack.Children.Add(alertBox);
                    alertBox.GetVm().StartTimer();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }


        }

        /// <summary>
        /// Initializes the area where AlertBoxes will be displayed and creates the necessary variables for the AlertBox instance.
        /// An end timer is added for the created instance, and once the time elapses, the AlertBox will dispose of itself.
        /// The created instance is added to the alertStack stack panel; if the maxChild count is exceeded, the instance is added to the queue.
        /// The timer method is not executed until the instance starts displaying.
        /// </summary>
        /// <param name="type">Specifies the type of AlertBox.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="title">The title to be displayed. It can be left empty; if left empty, it will not be displayed.</param>
        /// <returns>Does not return a value.</returns>
        /// <exception cref="InvalidOperationException">Thrown if AlertBoxInitialize has not been called.</exception>
        /// <exception cref="Exception">Returns the default error state for any potential error that may occur.</exception>
        private static void AlertBoxShow(AlertType type, string message, string? title)
        {
            try
            {
                if (!_isAlertBoxInitialize) throw new InvalidOperationException("AlertBox must be initialized before use.");

                AlertBox alert = new AlertBox(type, message, title);

                var x = alert.GetVm();
                x.EndTimer += (sender, args) =>
                {
                    EndAlertBox(args);
                    alert.Dispose();
                };


                if (_alertStack.Children.Count < MaxChild)
                {
                    StackPanelItems_Add(alert);
                }
                else if (_bufferAlertBoxList.Count < MaxBufferChild)
                {
                    _bufferAlertBoxList.Enqueue(alert);
                }
                else
                {
                    alert.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        /// <summary>
        /// Removes AlertBox instances that have expired from the stack panel.
        /// If there are no objects left in the stack panel, the alertPopup will be removed from display.
        /// </summary>
        /// <param name="uid">Unique ID information created for each AlertBox.</param>
        /// <exception cref="Exception">Thrown for any potential error that may occur.</exception>
        private static void EndAlertBox(string uid)
        {
            try
            {
                _alertStack.Children.Remove(FindChildByUid<AlertBox>(_alertStack, uid));
                if (_bufferAlertBoxList.Count > 0)
                {
                    StackPanelItems_Add(_bufferAlertBoxList.Dequeue());
                }
                else if (_alertStack.Children.Count == 0)
                {
                    _alertPopup.IsOpen = false;
                    _alertIsOpen = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion



        #region DialogBox Methodes

        /// <summary>
        /// Sets the constants used for creating AlertBox instances during the initial program startup. 
        /// If this step is not initialized, the AlertBox will throw an error.
        /// </summary>
        /// <param name="sizeType">Enum value used to set the size of the DialogBox.</param>
        /// <param name="dialogPlacement">Enum value to determine the position where the DialogBox will be displayed.</param>
        /// <param name="screenPadding">Offset value used for positioning. Default is 10.</param>
        /// <exception cref="InvalidOperationException">Thrown if any issue occurs during the initialization phase.</exception>
        public static void DialogBoxInitialize(DialogSize sizeType, DialogPlacement dialogPlacement, int screenPadding = 10)
        {
            try
            {
                DialogControllerSize = sizeType;
                var control = DialogSizeOptions.GetSizeOptions(DialogControllerSize);
                var placmentSize = DialogPlacementOptions.GetPlacementOption(dialogPlacement, _screenWidth, _screenHeight, control.SizeWidth, control.SizeHeight, screenPadding);

                _dialogPopup.HorizontalOffset = placmentSize.HorizontalOffsetV;
                _dialogPopup.VerticalOffset = placmentSize.VerticalOffsetV;

                _dialogPopup.Width = control.SizeWidth + 20;
                _dialogPopup.Height = control.SizeHeight + 20;

                _isDialogBoxInitialize = true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("DialogBox could not be set!");
            }
        }

        /// <summary>
        /// Throws an error if the DialogBox has not been initialized.
        /// A method that returns a value of type <typeparamref name="T"/> based on the DialogBox types.
        /// The method awaits the result of an asynchronous operation.
        /// It returns its own value based on the returned result.
        /// </summary>
        /// <typeparam name="T">The type of value returned by the method.</typeparam>
        /// <param name="dialogType">Accepts the type of the DialogBox as an enum.</param>
        /// <param name="message">The message to be displayed in the DialogBox.</param>
        /// <param name="title">The title to be displayed in the DialogBox. It can be left empty; if left empty, it will not be shown.</param>
        /// <returns>Returns either a bool or string value depending on the DialogBox type.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the DialogBox has not been initialized.</exception>
        /// <exception cref="InvalidCastException">Thrown if an invalid cast occurs.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if an argument is out of range.</exception>

        public static async Task<T> DialogBoxShow<T>(DialogType dialogType, string message, string? title)
        {
            try
            {
                if (!_isDialogBoxInitialize) throw new InvalidOperationException("DialogBox must be initialized before use.");

                DialogBox dialogBox = new DialogBox(dialogType, message, title);

                _dialogPopup.Child = dialogBox;
                _dialogPopup.IsOpen = true;

                string? result = null;

                try
                {
                    result = await dialogBox.GetVm().ShowDialogAsync();
                }
                finally
                {

                    _dialogPopup.IsOpen = false;
                    dialogBox.Dispose();
                }

                return dialogType switch
                {
                    DialogType.Confirmation => bool.TryParse(result, out bool confirmationResult)
                                                ? (T)(object)confirmationResult
                                                : throw new InvalidCastException($"Cannot convert {result} to {typeof(T)} for Confirmation dialog"),

                    DialogType.Continue => bool.TryParse(result, out bool confirmationResult)
                                                ? (T)(object)confirmationResult
                                                : throw new InvalidCastException($"Cannot convert {result} to {typeof(T)} for Confirmation dialog"),

                    DialogType.Retry => bool.TryParse(result, out bool confirmationResult)
                                                ? (T)(object)confirmationResult
                                                : throw new InvalidCastException($"Cannot convert {result} to {typeof(T)} for Confirmation dialog"),
                    DialogType.Warning => bool.TryParse(result, out bool confirmationResult)
                                                ? (T)(object)confirmationResult
                                                : throw new InvalidCastException($"Cannot convert {result} to {typeof(T)} for Confirmation dialog"),



                    _ => throw new ArgumentOutOfRangeException(nameof(dialogType), dialogType, null)
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        #endregion




        // Methods to be used for users to quickly create dialog boxes of their desired type.

        public static Task<bool> ConfirmedDialog(string message, string? title) => DialogBoxShow<bool>(DialogType.Confirmation, message, title);
        public static Task<bool> ContinueDialog(string message, string? title) => DialogBoxShow<bool>(DialogType.Continue, message, title);
        public static Task<bool> RetryDialog(string message, string? title) => DialogBoxShow<bool>(DialogType.Retry, message, title);
        public static Task<bool> WarningDialog(string message, string? title) => DialogBoxShow<bool>(DialogType.Warning, message, title);



        // Methods to be used for users to quickly create alert boxes of their desired type.

        public static void Error(string message, string? title) => AlertBoxShow(AlertType.Error, message, title);
        public static void Warning(string message, string? title) => AlertBoxShow(AlertType.Warning, message, title);
        public static void Success(string message, string? title) => AlertBoxShow(AlertType.Success, message, title);
        public static void Information(string message, string? title) => AlertBoxShow(AlertType.Information, message, title);
        public static void Other(string message, string? title) => AlertBoxShow(AlertType.Other, message, title);

        #region Helpers


        /// <summary>
        /// Recursively retrieves the parent of a specified type <typeparamref name="T"/> 
        /// from the visual tree of a given child DependencyObject.
        /// </summary>
        /// <typeparam name="T">The type of the parent to retrieve, constrained to DependencyObject.</typeparam>
        /// <param name="child">The child DependencyObject whose parent is to be found.</param>
        /// <returns>
        /// Returns the parent of type <typeparamref name="T"/> if found; otherwise, returns null.
        /// </returns>
        /// <exception cref="Exception">Returns null if an error occurs while retrieving the parent.</exception>
        private static T? GetParent<T>(DependencyObject child) where T : DependencyObject
        {
            
            try
            {
                DependencyObject parentObject = VisualTreeHelper.GetParent(child);

                if (parentObject == null) return null;

                T? parent = parentObject as T;
                if (parent != null)
                {
                    return parent;
                }
                else
                {
                    return GetParent<T>(parentObject);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Recursively searches for a child <typeparamref name="T"/> within a parent DependencyObject 
        /// by its unique identifier (Uid).
        /// </summary>
        /// <typeparam name="T">The type of the child element to search for, constrained to FrameworkElement.</typeparam>
        /// <param name="parent">The parent DependencyObject in which to search for the child.</param>
        /// <param name="uid">The unique identifier (Uid) of the child element to find.</param>
        /// <returns>
        /// Returns the first matching child of type <typeparamref name="T"/> if found; otherwise, returns null.
        /// </returns>
        /// <exception cref="Exception">Returns null if an error occurs during the search process.</exception>
        private static T? FindChildByUid<T>(this DependencyObject parent, string uid) where T : FrameworkElement
        {
            try
            {
                if (parent == null) return null;
                var count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                    if (child != null && child.Uid == uid && child is T matchedElement)
                    {
                        return matchedElement;
                    }

                    var result = FindChildByUid<T>(child!, uid);
                    if (result != null)
                        return result;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        #endregion
    }
}
