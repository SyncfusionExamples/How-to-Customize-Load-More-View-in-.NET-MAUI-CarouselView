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

    //View Model
    public class CarouselViewModel : INotifyPropertyChanged
    {
        public CarouselViewModel()
        {
            ImageCollection.Add(new CarouselModel("person1.jpg"));
            ImageCollection.Add(new CarouselModel("person2.jpg"));
            ImageCollection.Add(new CarouselModel("person3.jpg"));
            ImageCollection.Add(new CarouselModel("person4.jpg"));
            ImageCollection.Add(new CarouselModel("person5.jpg"));
            ImageCollection.Add(new CarouselModel("person6.png"));
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