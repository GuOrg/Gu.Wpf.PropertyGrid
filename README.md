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
