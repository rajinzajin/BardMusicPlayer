﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BardMusicPlayer.Controls;

/// <summary>
/// Interaction logic for NumericUpDown.xaml
/// </summary>
public sealed partial class OctaveNumericUpDown
{
    public EventHandler<int>? OnValueChanged;

    public OctaveNumericUpDown()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(OctaveNumericUpDown), new PropertyMetadata(OnValueChangedCallBack));

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    private static void OnValueChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is OctaveNumericUpDown c)
        {
            c.OnValueChangedC(c.Value);
        }
    }

    private void OnValueChangedC(string c)
    {
        NumValue = Convert.ToInt32(c);
    }


    /* Track UP/Down */
    private int _numValue;

    private int NumValue
    {
        get => _numValue;
        set
        {
            _numValue = value;
            Text.Text = "ø" + NumValue;
            OnValueChanged?.Invoke(this, _numValue);
        }
    }
    private void NumUp_Click(object sender, RoutedEventArgs e)
    {
        NumValue++;
    }

    private void NumDown_Click(object sender, RoutedEventArgs e)
    {
        NumValue--;
    }

    private void OctaveNumericUpDown_Key(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                NumUp_Click(sender, e);
                break;
            case Key.Down:
                NumDown_Click(sender, e);
                break;
        }
    }

    private void TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Text == null)
            return;

        var str = MyRegex().Replace(Text.Text, "");
        if (int.TryParse(str, out var val))
        {
            NumValue = val;
        }
    }

    [GeneratedRegex("[^\\d|\\.\\-]")]
    private static partial Regex MyRegex();
}