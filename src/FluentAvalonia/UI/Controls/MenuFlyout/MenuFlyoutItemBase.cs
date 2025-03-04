﻿using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace FluentAvalonia.UI.Controls;

public class MenuFlyoutItemBase : TemplatedControl
{
    static MenuFlyoutItemBase()
    {
        FocusableProperty.OverrideDefaultValue<MenuFlyoutItemBase>(true);
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);

        var args = new RoutedEventArgs(MenuItem.PointerEnteredItemEvent, this);
        RaiseEvent(args);
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);

        var args = new RoutedEventArgs(MenuItem.PointerExitedItemEvent, this);
        RaiseEvent(args);
    }

    protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
    {
        base.OnPointerCaptureLost(e);

        // Internal Bug: Clicking on a MenuFlyoutSubItem is triggering a PointerCaptureLost event being raised
        // which causes flickering of the submenu - disabling this
        // Side-effect is for touch/pen devices won't trigger exited event if device is lost - but that should
        // only be a minimal impact - the submenu would just stay open until cancelled by user
        var args = new RoutedEventArgs(MenuItem.PointerExitedItemEvent, this);
        RaiseEvent(args);
    }
}

