using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Font { Arial, Calibri, Consolas, Rockwell, Tahoma, Verdana };
        enum BtnColor { White, Black, IndianRed, SpringGreen, LightYellow, HotPink, DodgerBlue, Azure };
        enum ActiveBtnColor { White, Black, IndianRed, SpringGreen, LightYellow, HotPink, DodgerBlue, Azure };
        enum BorderBtnColor { White, Black, IndianRed, SpringGreen, LightYellow, HotPink, DodgerBlue, Azure };

        bool autogenerate = false;
        private string pathCityImage = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Resources\", "default.jpg");
        static string pathTxt = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Resources\", "cityNames.txt");
        ObservableCollection<CityDataEntry> city = new ObservableCollection<CityDataEntry> { };
        public ObservableCollection<CityDataEntry> Items { get => city; }

        CityEntities db = new CityEntities();
        System.Windows.Data.CollectionViewSource cityEntryViewSource;
        System.Windows.Data.CollectionViewSource cityEntitiesViewSource;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSettings();

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection = new SeriesCollection();

            this.DataContext = this;

            cityEntryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cityEntryViewSource")));
            cityEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cityEntitiesViewSource")));
        }

        #region Charts
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        #endregion

        #region MenuBar
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Visibility = Visibility.Visible;
            Settings.Visibility = Visibility.Hidden;
            Diagrams.Visibility = Visibility.Hidden;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Visibility = Visibility.Hidden;
            Settings.Visibility = Visibility.Visible;
            Diagrams.Visibility = Visibility.Hidden;
        }

        private void DiagramsButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Visibility = Visibility.Hidden;
            Settings.Visibility = Visibility.Hidden;

            #region Update PieChart
            var cityEntryViewSource = db.CityEntries.Local;
            int lat9060 = 0, lat6030 = 0, lat300 = 0, lat030 = 0, lat3060 = 0, lat6090 = 0;
            foreach (var item in cityEntryViewSource)
            {
                var latitude = double.Parse(item.Latitude, System.Globalization.CultureInfo.InvariantCulture);
                if (latitude < -60){ lat9060 += 1;}
                else if (-30 > latitude && latitude >= -60) { lat6030 += 1; }
                else if (0 > latitude && latitude >= -30) { lat300 += 1; }
                else if (30 > latitude && latitude >= 0) { lat030 += 1; }
                else if (60 > latitude && latitude >= 30) { lat3060 += 1; }
                else { lat6090 += 1; }
            }
            var lat9060Values = new ChartValues<int> { lat9060 }; Lat9060.Values = lat9060Values;
            var lat6030Values = new ChartValues<int> { lat6030 }; Lat6030.Values = lat6030Values;
            var lat300Values = new ChartValues<int> { lat300 }; Lat300.Values = lat300Values;
            var lat030Values = new ChartValues<int> { lat030 }; Lat030.Values = lat030Values;
            var lat3060Values = new ChartValues<int> { lat3060 }; Lat3060.Values = lat3060Values;
            var lat6090Values = new ChartValues<int> { lat6090 }; Lat6090.Values = lat6090Values;
            #endregion

            #region Update ColumnChart
            SeriesCollection.Clear();
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Number of cities",
                Values = new ChartValues<int> { }
            });

            List<string> labelList = new List<string>();
            foreach (var item in cityEntryViewSource)
            {
                var country = item.CountryName;
                if (!(labelList.Contains(country))) { labelList.Add(country); }
            }

            Labels = labelList.ToArray();
            int[] val = new int[Labels.Length];

            foreach (var item in cityEntryViewSource)
            {
                var country = item.CountryName;
                var index = labelList.IndexOf(country);
                val[index] += 1;
            }

            foreach (var item in val)
            {
                SeriesCollection[0].Values.Add(item);
            }
            
            Formatter = value => value.ToString("N");
            #endregion

            Diagrams.Visibility = Visibility.Visible;
        }
        #endregion

        #region SettingsButtons
        private void Default_Button_Click(object sender, RoutedEventArgs e)
        {
            // Set default settings
            Properties.Settings.Default.userFont = Properties.Resources.font;
            Properties.Settings.Default.userBtnFontSize = Properties.Resources.btnFontSize;
            Properties.Settings.Default.userBtnColor = Properties.Resources.btnColor;
            Properties.Settings.Default.userActiveBtnColor = Properties.Resources.activeBtnColor;
            Properties.Settings.Default.userBtnBorderColor = Properties.Resources.btnBorderColor;
            Properties.Settings.Default.Save();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            // Save user settings
            if (fontComboBox.SelectedIndex != -1)
                Properties.Settings.Default.userFont = fontComboBox.Text;
            if (btnFontSizeComboBox.SelectedIndex != -1)
                Properties.Settings.Default.userBtnFontSize = btnFontSizeComboBox.Text;
            if (btnColorComboBox.SelectedIndex != -1)
                Properties.Settings.Default.userBtnColor = btnColorComboBox.Text;
            if (activeBtnColorComboBox.SelectedIndex != -1)
                Properties.Settings.Default.userActiveBtnColor = activeBtnColorComboBox.Text;
            if (btnBorderColorComboBox.SelectedIndex != -1)
                Properties.Settings.Default.userBtnBorderColor = btnBorderColorComboBox.Text;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region HomeButtons
        private void AddPlaceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                city.Add(new CityDataEntry { CityName = inputCity.Text, CountryName = inputCountry.Text, Latitude = inputLatitude.Text, Longitude = inputLongitude.Text/*, Image = ImageSource(pathCityImage)*/ });
            }
            catch (FormatException es)
            {
                if (e.Source != null)
                    Console.WriteLine("FormatException: {0}", es.Source);
                throw;
            }
        }

        private void SaveToDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            autogenerate = false;   // Stop auto generate 
            var id = db.CityEntries.Count() + 1;
            foreach (var item in city)
            {
                var newEntry = new CityEntry() { Id = id, CityName = item.CityName, CountryName = item.CountryName, Latitude = item.Latitude, Longitude = item.Longitude/*, Image = item.Image*/ };
                db.CityEntries.Local.Add(newEntry);
                try
                {
                    db.SaveChanges();
                    id++;
                }
                catch (Exception ex)
                {
                    db.CityEntries.Local.Remove(newEntry);
                    Debug.WriteLine("Error, id is not unique");
                }
            }
            city.Clear();   // Clear ObservableCollection
        }

        private async void loadFromApiButton_Click(object sender, RoutedEventArgs e)
        {
            string responseXML = await GeocodingConnection.LoadDataAsync(inputCityApi.Text);
            CityDataEntry result;

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseXML)))
            {
                result = ParseGeocoding_XmlReader.Parse(stream);
                Items.Add(new CityDataEntry()
                {
                    CityName = result.CityName,
                    CountryName = result.CountryName,
                    Latitude = result.Latitude,
                    Longitude = result.Longitude
                });
            }
        }

        private void AddLocalXMLFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.InitialDirectory = "c:\\";
            openDlg.Filter = "XML Files (*xml)|*.xml|All Files (*.*)|*.*";

            if (openDlg.ShowDialog() == true)
            {
                var newEntry = new CityDataEntry();
                newEntry = ParseGeocoding_XmlReader.ParseLocal(openDlg.FileName);
                try
                {
                    city.Add(newEntry);
                }
                catch (FormatException es)
                {
                    if (e.Source != null)
                        Console.WriteLine("FormatException: {0}", es.Source);
                    throw;
                }
            }
        }

        private async void AutoGenerateButton_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            autogenerate = true;
            List<string> cityList = LocalTxt(pathTxt);
            while (autogenerate == true)
            {
                Random random = new Random();
                index = random.Next(0, cityList.Count);
                string responseXML = await GeocodingConnection.LoadDataAsync(cityList.ElementAt(index));
                CityDataEntry result;

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseXML)))
                {
                    result = ParseGeocoding_XmlReader.Parse(stream);
                    Items.Add(new CityDataEntry()
                    {
                        CityName = result.CityName,
                        CountryName = result.CountryName,
                        Latitude = result.Latitude,
                        Longitude = result.Longitude
                    });
                }
                await Task.Delay(10000);
            }
        }
        #endregion
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.CityEntries.Local.Concat(db.CityEntries.ToList());
            cityEntryViewSource.Source = db.CityEntries.Local;
            //cityEntitiesViewSource.Source = db.CityEntries.Local;
            System.Windows.Data.CollectionViewSource cityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cityViewSource")));
        }

        private static List<string> LocalTxt(string filePath)
        {
            List<string> cityNames = new List<string>();
            try
            {
                File.OpenRead(filePath);
            }
            catch (FileNotFoundException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("FileNotFoundException: {0}", ex.Source);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("DirectoryNotFoundException: {0}", ex.Source);
                throw;
            }
            catch (IOException ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException: {0}", ex.Source);
                throw;
            }
            string fileContent = File.ReadAllText(filePath);
            string[] integerString = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var record in integerString)
            {
                cityNames.Add(record);
            }
            return cityNames;
        }
        private void InitializeSettings()
        {
            fontComboBox.ItemsSource = Enum.GetValues(typeof(Font));
            btnColorComboBox.ItemsSource = Enum.GetValues(typeof(BtnColor));
            activeBtnColorComboBox.ItemsSource = Enum.GetValues(typeof(ActiveBtnColor));
            btnBorderColorComboBox.ItemsSource = Enum.GetValues(typeof(BorderBtnColor));
            for (var i = 16; i <= 30; i += 2)
                btnFontSizeComboBox.Items.Add(i);
        }
    }
}
