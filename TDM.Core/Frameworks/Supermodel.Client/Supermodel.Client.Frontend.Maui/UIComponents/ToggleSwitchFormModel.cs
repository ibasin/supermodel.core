using Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;
using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;
using Supermodel.DataAnnotations.Exceptions;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class ToggleSwitchFormModel : SingleCellWritableUIComponentFormModel
{
    #region Constructors
    public ToggleSwitchFormModel()
    {
        Switch = new Switch
        {
            HorizontalOptions = LayoutOptions.End, 
            VerticalOptions = LayoutOptions.Center, 
            OnColor = FormsSettings.SwitchOnColor
        };
        Switch.SetBinding(Switch.IsToggledProperty, "IsToggled");
        Switch.PropertyChanged += (_, _) =>
        {
            if (_currentValue != Switch.IsToggled)
            {
                _currentValue = Switch.IsToggled;
                OnChanged?.Invoke((IBasicCRUDDetailPage)ParentPage!);
            }
        };
        Tapped += (_, _) => Switch.Focus();
        //{
        //    Switch.Focus();
        //    Switch.IsToggled = !Switch.IsToggled; //Surenra's change
        //};

        Grid.Add(Switch, 1);
    }
    #endregion

    #region ICustomMapper implemtation
    public override Task MapFromCustomAsync<T>(T other)
    {
        if (typeof(T) != typeof(bool) && typeof(T) != typeof(bool?))
        {
            throw new PropertyCantBeAutomappedException($"{GetType().Name} can't be auto-mapped to {typeof(T).Name}");
        }

        if (other is bool) IsToggled = (bool)(object)other;
        else IsToggled = (bool?)(object?)other ?? false;

        return Task.CompletedTask;
    }
    public override Task<T> MapToCustomAsync<T>(T other)
    {
        if (typeof(T) != typeof(bool) && typeof(T) != typeof(bool?))
        {
            throw new PropertyCantBeAutomappedException($"{GetType().Name} can't be auto-mapped to {typeof(T).Name}");
        }

        return Task.FromResult((T)(object)IsToggled);
    }
    #endregion

    #region EventHandling
    public Action<IBasicCRUDDetailPage>? OnChanged { get; set; }
    #endregion

    #region Properties
    public bool IsToggled
    {
        get => Switch.IsToggled;
        set
        {
            _currentValue = value;
            if (value == Switch.IsToggled) return;
            Switch.IsToggled = value;
            OnPropertyChanged();
        }
    }
    private bool _currentValue;
    public Switch Switch { get; }

    public override object WrappedValue => Switch.IsToggled;

    public override TextAlignment TextAlignmentIfApplies
    {
        get
        {
            switch (Switch.HorizontalOptions.Alignment)
            {
                case LayoutAlignment.Start: return TextAlignment.Start;
                case LayoutAlignment.Center: return TextAlignment.Center;
                case LayoutAlignment.End: return TextAlignment.End;
                default: throw new SupermodelException("Invalid value for Switch.HorizontalOptions.Alignment. This should never happen");
            }
        }
        set
        {
            switch (value)
            {
                case TextAlignment.Start:
                    Switch.HorizontalOptions = LayoutOptions.Start;
                    break;
                case TextAlignment.Center:
                    Switch.HorizontalOptions = LayoutOptions.Center;
                    break;
                case TextAlignment.End:
                    Switch.HorizontalOptions = LayoutOptions.End;
                    break;
                default: throw new SupermodelException("Invalid value for TextAlignmentIfApplies. This should never happen");
            }
        }
    }

    public bool Active
    {
        get => _active;
        set
        {
            if (_active == value) return;
            _active = IsEnabled = value;
            DisplayNameLabel.TextColor = value ? FormsSettings.LabelTextColor : FormsSettings.DisabledTextColor;
            Switch.OnColor = value ? FormsSettings.SwitchOnColor : FormsSettings.DisabledTextColor;
        }
    }
    private bool _active = true;
    #endregion
}