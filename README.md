# Gu.PropertyGrid
Small lib with styles for using ItemsControl as a property grid.

## Sample

```
<ItemsControl Style="{StaticResource {x:Static propertyGrid:Keys.PropertyGridStyleKey}}">
    <TextBlock Style="{StaticResource {x:Static propertyGrid:Keys.HeaderTextBlockStyleKey}}" Text="Sample header text" />

    <HeaderedContentControl Header="SomeProperty">
        <TextBox Text="Value" />
    </HeaderedContentControl>

    <HeaderedContentControl Header="Some bool property">
        <CheckBox />
    </HeaderedContentControl>

    <ItemsControl Style="{StaticResource {x:Static propertyGrid:Keys.PropertyGridStyleKey}}">
        <TextBlock Style="{StaticResource {x:Static propertyGrid:Keys.HeaderTextBlockStyleKey}}" Text="Nested header text" />

        <HeaderedContentControl Header="SomeProperty">
            <TextBox Text="Value" />
        </HeaderedContentControl>

        <HeaderedContentControl Header="Some bool property">
            <CheckBox />
        </HeaderedContentControl>
    </ItemsControl>
</ItemsControl>
```

Renders:

![Render](http://i.imgur.com/uUQ5flQ.png)

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
