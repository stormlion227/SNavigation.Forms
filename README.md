# SNavigation.Forms

SNavigation(Xamarin.Forms) allows you to put any elements on navigation bar.

[![NuGet](https://img.shields.io/nuget/v/SNavigation.Forms.svg)](https://www.nuget.org/packages/SNavigation.Forms/)

Supports Android and iOS.

## Screen-Shots

<img src="ScreenShots/screenshot_android.gif" alt="SNavigation Android"/> <img src="ScreenShots/screenshot_ios.gif" alt="SNavigation iOS"/>

## Setup

* Install the [nuget package](https://www.nuget.org/packages/SNavigation.Forms) in portable and all platform specific projects.

### Android

In MainActivity.cs file

```cs
Stormlion.SNavigation.Droid.Platform.Init(this);
```

### iOS

In AppDelegate.cs file

```cs
Stormlion.SNavigation.iOS.Platform.Init();
```
## Usage

```cs
MainPage = new SNavigationPage(new Page1())
{
    BarBackgroundColor = Color.SkyBlue,
};
```

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage x:Class="Test.Page1"
             xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:snav="clr-namespace:Stormlion.SNavigation;assembly=Stormlion.SNavigation">
    <snav:SNavigationPage.NavContent>
        <Grid Margin="50,0,50,0">
            <SearchBar BackgroundColor="White" Placeholder="Search ..." />
        </Grid>
    </snav:SNavigationPage.NavContent>
    <ContentPage.Content>
        ...
    </ContentPage.Content>
</ContentPage>
```

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage x:Class="Test.Page2"
             xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:snav="clr-namespace:Stormlion.SNavigation;assembly=Stormlion.SNavigation">
    <snav:SNavigationPage.NavContent>
        <Grid Margin="50,0,50,0">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="1*" />
                <ColumnDefinition Width="1*" />
                <ColumnDefinition Width="1*" />
            </Grid.ColumnDefinitions>
            <BoxView Grid.Column="0" BackgroundColor="LightGray" />
            <BoxView Grid.Column="1" BackgroundColor="LightBlue" />
            <BoxView Grid.Column="2" BackgroundColor="Orange" />
        </Grid>
    </snav:SNavigationPage.NavContent>
    <ContentPage.Content>
        ...
    </ContentPage.Content>
</ContentPage>
```

## Contributions
Contributions are welcome!
