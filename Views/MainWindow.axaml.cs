using System;
using AngelSixMVVM.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace AngelSixMVVM.Views;

public partial class MainWindow : Window
{
    #region Private Members

    private Control mChannelConfigPopup;
    private Control mChannelConfigButton;
    private Control mMainGrid;

    #endregion
    public MainWindow()
    {
        InitializeComponent();

        mChannelConfigButton = this.FindControl<Control>("ChannelConfigBtn") ??
                                throw new Exception("Cannot find channel config btn by name.");
        mChannelConfigPopup = this.FindControl<Control>("ChannelConfigPopup") ??
                                throw new Exception("Cannot find channel config popup by name.");
        mMainGrid = this.FindControl<Control>("MainGrid") ??
                        throw new Exception("Cannot find main grid by name.");
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        // Get relative position of button in relation to main grid
        var position = mChannelConfigButton.TranslatePoint(new Point(), mMainGrid) ?? throw new Exception("Cannot get translate point from config btn.");

        // Set margin of popup so it appears at top left of button
        Dispatcher.UIThread.Post( () =>
        {
            mChannelConfigPopup.Margin = new Thickness(position.X, 0, 0, mMainGrid.Bounds.Height - position.Y);
        });
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        ((MainWindowViewModel)DataContext).ChannelConfigBtnClickCommand.Execute(null);
    }
}