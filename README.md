# Gu.PropertyGrid

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)
[![Build status](https://ci.appveyor.com/api/projects/status/vhg6ru7ennq82ek7/branch/master?svg=true)](https://ci.appveyor.com/project/JohanLarsson/gu-wpf-propertygrid/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.PropertyGrid.svg)](https://www.nuget.org/packages/Gu.Wpf.PropertyGrid/)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.PropertyGrid.NumericSettingControls.svg)](https://www.nuget.org/packages/Gu.Wpf.PropertyGrid.NumericSettingControls/)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.PropertyGrid.UnitSettingControls.svg)](https://www.nuget.org/packages/Gu.Wpf.PropertyGrid.UnitSettingControls/)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/JohanLarsson/Gu.Wpf.PropertyGrid?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Library with controls for making property grids

**Note:** Master branch & docs are not in sync with the nuget, sry about this.

## Sample

```xaml
<Grid validationScope:Scope.ForInputTypes="Scope" validationScope:Scope.HasErrorsOneWayToSourceBinding="{Binding ViewHasErrors, Mode=OneWayToSource}">
    <Grid.RowDefinitions>
        <RowDefinition />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <propertyGrid:Rows Grid.Row="0"
                        DataContext="{Binding EditableCopy}"
                        OldDataContext="{Binding DataContext.LastSaved,
                                                RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}">
        <TextBlock Style="{StaticResource HeaderTextBlockStyle}" Text="Core" />

        <propertyGrid:StringRow Header="string" Value="{Binding StringValue}" />

        <propertyGrid:StringRow Header="readonly string"
                                IsReadOnly="True"
                                Value="{Binding StringValue}" />

        <propertyGrid:CheckBoxRow Header="INotifyDataErrorInfo has error" Value="{Binding HasErrors, ValidatesOnNotifyDataErrors=True}" />

        <propertyGrid:CheckBoxRow Header="checkbox" Value="{Binding BoolValue}" />
        <propertyGrid:BoolRow Header="bool" Value="{Binding BoolValue}" />

        <propertyGrid:ToggleButtonRow Header="togglebutton" Value="{Binding BoolValue}" />


        <propertyGrid:EnumRow Header="enum" Value="{Binding CurrentStringComparison}" />

        <propertyGrid:SelectorRow Header="selector"
                                    ItemsSource="{x:Static demo:SettingsVm.LengthUnits}"
                                    Value="{Binding CurrentLengthUnit}" />

        <propertyGrid:ComboBoxRow Header="combobox"
                                    ItemsSource="{x:Static demo:SettingsVm.LengthUnits}"
                                    Value="{Binding CurrentLengthUnit}" />
            
        <propertyGrid:ContentRow Header="content">
            <Button Command="{Binding DataContext.SaveCommand, RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" Content="Save" />
        </propertyGrid:ContentRow>

        <TextBlock Style="{StaticResource HeaderTextBlockStyle}" Text="Numeric" />

        <propertyGrid:IntRow Header="int" Value="{Binding IntValue}" />

        <propertyGrid:IntRow Header="readonly int"
                                IsReadOnly="True"
                                Value="{Binding IntValue}" />

        <propertyGrid:IntRow CanValueBeNull="True"
                                Header="int?"
                                Value="{Binding NullableIntValue}" />

        <propertyGrid:DoubleRow Header="double" Value="{Binding DoubleValue}" />

        <propertyGrid:DoubleRow Header="readonly double"
                                IsReadOnly="True"
                                Value="{Binding DoubleValue}" />

        <propertyGrid:DoubleRow CanValueBeNull="True"
                                Header="double?"
                                Value="{Binding NullableDoubleValue}" />

        <TextBlock Style="{StaticResource HeaderTextBlockStyle}" Text="Units" />

        <propertyGrid:LengthRow Header="Length" Value="{Binding LengthValue}" />

        <propertyGrid:LengthRow Header="readonly length"
                                IsReadOnly="True"
                                Value="{Binding LengthValue}" />

        <propertyGrid:LengthRow CanValueBeNull="True"
                                Header="Nullable length"
                                Value="{Binding NullableLengthValue}" />

        <propertyGrid:SpeedRow Header="Speed (readonly)"
                                IsReadOnly="True"
                                Unit="km/h"
                                Value="{Binding SpeedValue}" />

        <propertyGrid:LengthRow DecimalDigits="2"
                                Header="Length"
                                MaxValue="15 mm"
                                MinValue="-15 mm"
                                Unit="{Binding CurrentLengthUnit}"
                                Value="{Binding LengthValue}" />
    </propertyGrid:Rows>

    <Grid Grid.Row="1">
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Button Grid.Column="0"
                Command="{Binding SaveCommand}"
                Content="Save" />
        <Button Grid.Column="1"
                Command="{Binding UndoAllCommand}"
                Content="Undo" />
    </Grid>
</Grid>
```

Renders:

![Render](http://i.stack.imgur.com/DkWs1.gif)

## AttachedProperties
### Grid
Made RowDefinitions & ColumnDefinitions attached properties so that the grid can be styled if many grids need the same rows and columns.

##### Sample style

When used in a style either the style must have `x:Shared="False"` or the rows and columns can be declared with `x:Shared="False"` like this:
About [x:Shared](https://msdn.microsoft.com/en-us/library/aa970778(v=vs.110).aspx) in short it means that instances in resources are not reused.

```
<propertyGrid:RowDefinitions x:Key="RowDefinitions" x:Shared="False">
    <RowDefinition Height="Auto" />
    <RowDefinition Height="Auto" />
</propertyGrid:RowDefinitions>

<propertyGrid:ColumnDefinitions x:Key="ColumnDefinitions" x:Shared="False">
    <ColumnDefinition SharedSizeGroup="{x:Static propertyGrid:SharedSizeGroups.LabelColumn}" />
    <ColumnDefinition MinWidth="{Binding Path=(propertyGrid:SettingControl.ValueMinWidth),
                                            RelativeSource={RelativeSource AncestorType={x:Type propertyGrid:SettingControlBase}}}"
                        MaxWidth="{Binding Path=(propertyGrid:SettingControl.ValueMaxWidth),
                                            RelativeSource={RelativeSource AncestorType={x:Type propertyGrid:SettingControlBase}}}"
                        SharedSizeGroup="{x:Static propertyGrid:SharedSizeGroups.ValueColumn}" />
    <ColumnDefinition MinWidth="{Binding Path=(propertyGrid:SettingControl.SuffixMinWidth),
                                            RelativeSource={RelativeSource AncestorType={x:Type propertyGrid:SettingControlBase}}}"
                        MaxWidth="{Binding Path=(propertyGrid:SettingControl.SuffixMaxWidth),
                                            RelativeSource={RelativeSource AncestorType={x:Type propertyGrid:SettingControlBase}}}"
                        SharedSizeGroup="{x:Static propertyGrid:SharedSizeGroups.SuffixColumn}" />
</propertyGrid:ColumnDefinitions>

<Style x:Key="{x:Static propertyGrid:Keys.RootGridStyleKey}" TargetType="{x:Type Grid}">
    <Setter Property="propertyGrid:Grid.RowDefinitions" Value="{StaticResource RowDefinitions}" />
    <Setter Property="propertyGrid:Grid.ColumnDefinitions" Value="{StaticResource ColumnDefinitions}" />
</Style>
```

##### Xaml sample
Wrote typeconverters so that they can be used in xaml like this:

```
<Grid p:Grid.ColumnDefinitions="* *" p:Grid.RowDefinitions="* *">
    <Rectangle Grid.Row="0"
               Grid.Column="0"
               Fill="Blue" />
    <Rectangle p:Grid.Cell="1 1"
               Fill="Yellow" />
</Grid>
```

### OneWayToSource
Attached property that lets you bind readonly dependency properties `OneWayToSource`to datacontes.

##### Sample
```
<TextBox Text="{Binding Text}"
         p:OneWayToSource.Bind="{p:Paths From={x:Static Validation.HasErrorProperty},
                                         To=ViewHasErrors}" />
```
