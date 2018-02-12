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

```
    Stormlion.SNavigation.Droid.Platform.Init(this);
```

### iOS

In AppDelegate.cs file

```
    Stormlion.SNavigation.iOS.Platform.Init();
```
## Usage

```
    MainPage = new SNavigationPage(new Page1())
    {
        BarBackgroundColor = Color.SkyBlue,
    };
```

```
	<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
				 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
				 xmlns:snav="clr-namespace:Stormlion.SNavigation;assembly=Stormlion.SNavigation"
				 x:Class="Test.Page1"
				 >
		<snav:SNavigationPage.NavContent>
			<Grid Margin="50, 0, 50, 0"
				  >
				<SearchBar BackgroundColor="White"
						   Placeholder="Search ..."
						   />
			</Grid>
		</snav:SNavigationPage.NavContent>
		<ContentPage.Content>
			...
		</ContentPage.Content>
	</ContentPage>
```

```
	<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
				 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
				 xmlns:snav="clr-namespace:Stormlion.SNavigation;assembly=Stormlion.SNavigation"
				 x:Class="Test.Page2"
				 >
		<snav:SNavigationPage.NavContent>
			<Grid Margin="50, 0, 50, 0">
				<Grid.ColumnDefinitions>
					<ColumnDefinition Width="1*" />
					<ColumnDefinition Width="1*" />
					<ColumnDefinition Width="1*" />
				</Grid.ColumnDefinitions>
				<BoxView Grid.Column="0"
						 BackgroundColor="LightGray"
						 />
				<BoxView Grid.Column="1"
						 BackgroundColor="LightBlue"
						 />
				<BoxView Grid.Column="2"
						 BackgroundColor="Orange"
						 />
			</Grid>
		</snav:SNavigationPage.NavContent>
		<ContentPage.Content>
			...
		</ContentPage.Content>
	</ContentPage>
```

## Contributions
Contributions are welcome!

## Contributors
* **[Marko Rothstein](https://www.facebook.com/profile.php?id=100014026622428)**


## Donation
If this project help you reduce time to develop, you can give me a cup of coffee :)

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=stormlion227@gmail.com&item_name=Donate+to+free+developer)
