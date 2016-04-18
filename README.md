# Gu.PropertyGrid
Library with controls for making property grids
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)
[![Build status](https://ci.appveyor.com/api/projects/status/vhg6ru7ennq82ek7?svg=true)](https://ci.appveyor.com/project/JohanLarsson/gu-wpf-propertygrid)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.PropertyGrid.svg)](https://www.nuget.org/packages/Gu.Wpf.PropertyGrid/)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.PropertyGrid.NumericSettingControls.svg)](https://www.nuget.org/packages/Gu.Wpf.PropertyGrid.NumericSettingControls/)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.PropertyGrid.UnitSettingControls.svg)](https://www.nuget.org/packages/Gu.Wpf.PropertyGrid.UnitSettingControls/)

## Sample

```
<Grid validationScope:Scope.ForInputTypes="Scope"
        validationScope:Scope.HasErrorsOneWayToSourceBinding="{Binding ViewHasErrors,
                                                                        Mode=OneWayToSource}">
    <Grid.RowDefinitions>
        <RowDefinition />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <p:SettingsControl Grid.Row="0"
                        DataContext="{Binding EditableCopy}"
                        OldDataContext="{Binding DataContext.LastSaved,
                                                RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}"
                        SuffixMinWidth="20"
                        ValueMinWidth="150">
        <TextBlock Style="{StaticResource HeaderTextBlockStyle}"
                    Text="Core" />

        <p:StringSettingControl Header="string"
                                Value="{Binding StringValue}" />

        <p:StringSettingControl Header="readonly string"
                                IsReadOnly="True"
                                Value="{Binding StringValue}" />

        <p:CheckBoxSettingControl Header="INotifyDataErrorInfo has error"
                                    Value="{Binding HasErrors,
                                                    ValidatesOnNotifyDataErrors=True}" />

        <p:CheckBoxSettingControl Header="checkbox"
                                    Value="{Binding BoolValue}" />

        <p:ToggleButtonSettingControl Header="togglebutton"
                                        Value="{Binding BoolValue}" />


        <p:EnumSettingControl Header="enum"
                                Value="{Binding CurrentStringComparison}" />

        <p:SelectorSettingControl Header="selector"
                                    ItemsSource="{x:Static demo:SettingsVm.LengthUnits}"
                                    Value="{Binding CurrentLengthUnit}" />

        <p:ContentSettingControl Header="content">
            <Button Command="{Binding DataContext.SaveCommand,
                                        RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}"
                    Content="Save" />
        </p:ContentSettingControl>

        <TextBlock Style="{StaticResource HeaderTextBlockStyle}"
                    Text="NumericSettingControls" />

        <p:IntSettingControl Header="int"
                                Value="{Binding IntValue}" />

        <p:IntSettingControl CanValueBeNull="True"
                                Header="int?"
                                Value="{Binding NullableIntValue}" />

        <p:DoubleSettingControl Header="double"
                                Value="{Binding DoubleValue}" />

        <p:DoubleSettingControl CanValueBeNull="True"
                                Header="double?"
                                Value="{Binding NullableDoubleValue}" />

        <TextBlock Style="{StaticResource HeaderTextBlockStyle}"
                    Text="UnitSettingControls" />

        <p:LengthSettingControl Header="Length"
                                IsEnabled="False"
                                Value="{Binding LengthValue}" />

        <p:LengthSettingControl CanValueBeNull="True"
                                Header="Nullable length"
                                Value="{Binding NullableLengthValue}" />

        <p:SpeedSettingControl Header="Speed (readonly)"
                                IsReadOnly="True"
                                Unit="km/h"
                                Value="{Binding SpeedValue}" />

        <p:LengthSettingControl DecimalDigits="2"
                                Header="Length"
                                MaxValue="15 mm"
                                MinValue="-15 mm"
                                Unit="{Binding CurrentLengthUnit}"
                                Value="{Binding LengthValue}" />
    </p:SettingsControl>
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
