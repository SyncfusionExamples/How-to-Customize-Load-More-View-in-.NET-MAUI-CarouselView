# How-to-Customize-Load-More-View-in-.NET-MAUI-CarouselView
This section explains how to customize the Load More View in the .NET MAUI Carousel View using the SfCarousel control. The LoadMoreView property allows you to define a custom UI that is displayed when the carousel reaches the end of the currently available items and loads additional content.

## XAML

Define the SfCarousel control, enable load more functionality by setting AllowLoadMore to True, and customize the load more indicator using the LoadMoreView property.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:carousel="clr-namespace:Syncfusion.Maui.Carousel;assembly=Syncfusion.Maui.Carousel"
             xmlns:local="clr-namespace:Sample"
             x:Class="Sample.MainPage"
             Title="CustomizeLoadMoreView">

    <ContentPage.BindingContext>
        <local:CarouselViewModel/>
    </ContentPage.BindingContext>

    <ContentPage.Content>
        <carousel:SfCarousel x:Name="carousel"
                             ItemsSource="{Binding ImageCollection}"
                             AllowLoadMore="True"
                             LoadMoreItemsCount="2"
                             ViewMode="Linear">

            <carousel:SfCarousel.ItemTemplate>
                <DataTemplate>
                    <Image Source="{Binding Image}"
                           Aspect="AspectFit"/>
                </DataTemplate>
            </carousel:SfCarousel.ItemTemplate>

            <carousel:SfCarousel.LoadMoreView>
                <Grid BackgroundColor="SkyBlue">
                    <Label Text="Load More..."
                           FontSize="14"
                           TextColor="White"
                           FontAttributes="Bold"
                           HorizontalTextAlignment="Center"
                           VerticalTextAlignment="Center" />
                </Grid>
            </carousel:SfCarousel.LoadMoreView>

        </carousel:SfCarousel>
    </ContentPage.Content>

</ContentPage>
```

## C#

Create a view model that contains the image collection and bind it to the carousel. When the user reaches the end of the carousel, the customized LoadMoreView is displayed while additional items are loaded based on the value specified in the LoadMoreItemsCount property.
```csharp
using System.ComponentModel;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    // Model
    public class CarouselModel
    {
        public CarouselModel(string imageString)
        {
            Image = imageString;
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }

    // ViewModel
    public class CarouselViewModel : INotifyPropertyChanged
    {
        public CarouselViewModel()
        {
            ImageCollection.Add(new CarouselModel("image1.png"));
            ImageCollection.Add(new CarouselModel("image2.png"));
            ImageCollection.Add(new CarouselModel("image3.png"));
            ImageCollection.Add(new CarouselModel("image4.png"));
            ImageCollection.Add(new CarouselModel("image5.png"));
        }

        private List<CarouselModel> imageCollection = new List<CarouselModel>();

        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set
            {
                imageCollection = value;
                OnPropertyChanged(nameof(ImageCollection));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
```
