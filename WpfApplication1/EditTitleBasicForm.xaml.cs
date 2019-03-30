using IMDbDotNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApplication1
{

    /// <summary>
    /// Interaction logic for EditTitleBasicForm.xaml
    /// </summary>
    public partial class EditTitleBasicForm : Window
    {
        public ObservableCollection<titlebasic> ObserveTitleBasicList { get; set; }
        public static List<titlebasic> TitleBasicList;
        private string titleBasicID;

        public EditTitleBasicForm()
        {
            Run();
        }

        //starts UI and populates it.  
        public void Run()
        {
            InitializeComponent();
        }

        //runs method to initialize HTTPClient
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindTitlebasicsList();
        }

        //add baseAddress and default request headers to static HTTPClient
        private void BindTitlebasicsList()
        {
            MainWindow.Client.BaseAddress = new Uri("http://localhost:2105/");
            MainWindow.Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/xml"));
        }

        //populates UI with a selected search criteria. 
        public void GetTitleBasicByID(string id)
        {
            titleBasicID = id;
            var url = "api/titlebasics/" + titleBasicID;
            HttpResponseMessage response = MainWindow.Client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var titlebasics = response.Content.ReadAsAsync<IEnumerable<titlebasic>>().Result;
                foreach (titlebasic temp in titlebasics)
                {
                    ObserveTitleBasicList = new ObservableCollection<titlebasic>(titlebasics);
                }
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            DataContext = ObserveTitleBasicList;
            Show();
        }

        //Saves changes and closes UI. 
        private async void SaveClose_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (titleBasicID != null)
            {
                await UpdateTitleBasicByIdAsync(titleBasicID);
            }
            else
            {
                await NewTitleBasic();
            }
            Close();
        }

        //saves changes but UI remains active.
        private async void Save_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (titleBasicID != null)
            {
                await UpdateTitleBasicByIdAsync(titleBasicID);
            }
            else
            {
                await NewTitleBasic();

            }
        }

        //reloads page with original information from the last save.
        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            GetTitleBasicByID(titleBasicID);
        }

        //creates new entry and saves it to databse from input from user.
        private async Task NewTitleBasic()
        {
            isAdultComboBox.SelectedValue = "False";
            titlebasic titlebasic = NewUser();        
            var response = await MainWindow.Client.PostAsXmlAsync("api/titlebasics", titlebasic);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Titlebasic Added");
                Run();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            titleBasicID = tconstTextBox.Text;
        }

        //updates employee information in database on selected employee
        private async Task UpdateTitleBasicByIdAsync(string id)
        {
            var url = "api/titlebasics/" + id;
            titlebasic titlebasic = NewUser();
            HttpResponseMessage response = await MainWindow.Client.PutAsXmlAsync(url, titlebasic);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Titlebasic updated");
                Run();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        //create new titlebasic object
        private titlebasic NewUser()
        {
            bool ifSuccessIsAdult = false;
            bool ifSuccessStartYear = short.TryParse(startYearTextBox.Text, out short tempStartYear);
            bool ifSuccessEndYear = short.TryParse(endYearTextBox.Text, out short tempEndYear);
            bool ifSuccessRunTimeMinutes = int.TryParse(runTimeMinutesTextBox.Text, out int tempRunTimeMinutes);

            if (isAdultComboBox.Text.Equals("True") || isAdultComboBox.Text.Equals("False"))
            {
                ifSuccessIsAdult = Convert.ToBoolean(isAdultComboBox.Text);
            }
            var titlebasic = new titlebasic
            {
                tconst = tconstTextBox.Text,
                titleType = titleTypeTextBox.Text,
                primaryTitle = primaryTitleTextBox.Text,
                originalTitle = originaltitleTextBox.Text,
                isAdult = ifSuccessIsAdult,
                startYear = tempStartYear,
                endYear = tempEndYear,
                runtimeMinutes = tempRunTimeMinutes,
                genres = genreTextBox.Text
            };

            return titlebasic;
        }
    }
}