//using System;
//using System.Collections.Generic;
//using System.Windows;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using IMDbDotNetAPI.Models;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WpfApplication1
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public ObservableCollection<titlebasic> ObserveTitleBasicList { get; set; }
//        public static List<titlebasic> titleBasicList;
//        private string titleBasicID = null;
//        private int pageSize = 12;
//        private int pageIndex = 0;
//        public int ienumerableCount = 0;
//        public List<titlebasic> asList;
//        public List<titlebasic> pageList = new List<titlebasic>();
//        public static HttpClient Client = new HttpClient();

//        //start window
//        public MainWindow()
//        {
//            Run();
//        }

//        //initialize components
//        public void Run()
//        {
//            InitializeComponent();
//        }

//        //run httpclient initialization method
//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {
//            BindListAsync();
//        }

//        //add baseAddress and default request headers to static HTTPClient
//        private void BindListAsync()
//        {
//            Client.BaseAddress = new Uri("http://localhost:2105/");
//            Client.DefaultRequestHeaders.Clear();
//            Client.DefaultRequestHeaders.Accept.Add(
//               new MediaTypeWithQualityHeaderValue("application/xml"));
//        }

//        //create new blank Edit dialog and display
//        private void btnAdd_Click(object sender, RoutedEventArgs e)
//        {
//            EditTitleBasicForm edit = new EditTitleBasicForm();
//            edit.Show();
//        }

//        //create new Edit dialog and populate it with selected titlebasic object and display 
//        private void Edit_Button_Click(object sender, RoutedEventArgs e)
//        {
//            if (titleBasicID != null)
//            {
//                EditTitleBasicForm edit = new EditTitleBasicForm();
//                edit.GetTitleBasicByID(titleBasicID);
//                edit.Show();
//            }
//        }

//        //doesn't do anything.  Save function is on EditTitleBasicForm...not here
//        private void Save_Button_Click(object sender, RoutedEventArgs e)
//        {
//            MessageBox.Show("Saved");
//        }

//        //clears searchbox, page number, total count and creates new empty list and re-runs window
//        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
//        {
//            m_txtTest.Text = "";
//            PageNumber.Content = "";
//            TotalCount.Content = "";
//            titleBasicList = new List<titlebasic>();
//            ObserveTitleBasicList = new ObservableCollection<titlebasic>(titleBasicList);
//            DataContext = ObserveTitleBasicList;
//            Run();
//        }

//        //deletes selected entry from database as per tconst
//        private async void btnDelete_Click(object sender, RoutedEventArgs e)
//        {
//            var id = titleBasicID;

//            var url = "api/titlebasics/" + id;

//            HttpResponseMessage response = await Client.DeleteAsync(url);

//            if (response.IsSuccessStatusCode)
//            {
//                MessageBox.Show("You have deleted " + titleBasicID);
//            }
//            else
//            {
//                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
//            }
//        }

//        //calls search method when button clicked
//        private void btnSearch_Click(object sender, RoutedEventArgs e)
//        {
//            Search();
//        }

//        //calls search method when user double clicks on search box
//        private void M_txtTest_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
//        {
//            Search();
//        }

//        //calls search method when user hits enter in search box
//        private void M_txtTest_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
//        {
//            if (e.Key == System.Windows.Input.Key.Return)
//            {
//                Search();
//            }
//        }

//        //searches for user from database based on text in search box searching for tconst
//        private void Search()
//        {
//            var id = m_txtTest.Text.Trim();
//            var url = "api/titlebasics/?id=" + id + "&startindex=" + pageIndex + "&pagesize=" + pageSize;
//            HttpResponseMessage response = Client.GetAsync(url).Result;

//            if (response.IsSuccessStatusCode)
//            {
//                PageNumber.Content = pageIndex + 1;
//                var titlebasics = response.Content.ReadAsAsync<IEnumerable<titlebasic>>().Result;
//                ienumerableCount = titlebasics.Count();
//                TotalCount.Content = ienumerableCount;
//                asList = titlebasics.ToList();
//                ObserveTitleBasicList = new ObservableCollection<titlebasic>(asList);
//                DataContext = ObserveTitleBasicList;
//            }
//            else
//            {
//                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
//            }
//        }

//        //when selection changes in listview the tconst for that selection becomes the titleBasicID
//        private void ListView1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
//        {
//            foreach (titlebasic item in e.AddedItems)
//            {
//                titleBasicID = item.tconst;
//            }
//        }

//        //when mouse enters searchbox the word "Search" appears if the textbox is blank
//        private void SearchBar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
//        {
//            if (m_txtTest.Text == "")
//            {
//                m_txtTest.Text = "Search";
//            }
//        }

//        //if the searchbox contains the word "Search" when mouse enters searchbox the word "Search" disappears
//        private void SearchBar_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
//        {
//            if (m_txtTest.Text.Equals("Search"))
//            {
//                m_txtTest.Text = "";
//            }
//        }

//        //if pageIndex is greater than 0 subtracts 1 from pageIndex and runs search based on new pageindex
//        private void PreviousButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (pageIndex > 0)
//            {
//                pageIndex--;
//                PageNumber.Content = pageIndex + 1;
//                Search();
//            }
//        }

//        //advance pageIndex to next page and runs search based on new pageIndex
//        private void NextButton_Click(object sender, RoutedEventArgs e)
//        {
//            pageIndex++;
//            PageNumber.Content = pageIndex + 1;
//            Search();
//        }


//        //NOT USED.  COULD NOT GET IT TO PROPERLY CALL TITLEBASICCONTROLLER CLASS
//        //private async void GetCount()
//        //{
//        //    MessageBox.Show("Count Start");
//        //    var url = "api/titlebasics/?startindex=0"; //this line should be modified to correct URL
//        //    HttpResponseMessage response = await Client.GetAsync(url);

//        //    if (response.IsSuccessStatusCode)
//        //    {
//        //        var titlebasics = await response.Content.ReadAsAsync<IEnumerable<titlebasic>>();
//        //        ienumerableCount = titlebasics.Count();
//        //        TotalCount.Content = ienumerableCount.ToString();
//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
//        //    }
//        //}
//    }
//}
using System;
using System.Collections.Generic;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;
using IMDbDotNetAPI.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<titlebasic> ObserveTitleBasicList { get; set; }
        public static List<titlebasic> titleBasicList;
        private string titleBasicID = null;
        private int pageSize = 12;
        private int pageIndex = 0;
        public int ienumerableCount=0;
        public List<titlebasic> asList;
        public List<titlebasic> pageList = new List<titlebasic>();
        public static HttpClient Client = new HttpClient();

        //start window
        public MainWindow()
        {
            Run();
        }

        //initialize components
        public void Run()
        {
            InitializeComponent();
        }

        //run httpclient initialization method
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindListAsync();        
        }
        
        //add baseAddress and default request headers to static HTTPClient
        private void BindListAsync()
        {
            Client.BaseAddress = new Uri("http://localhost:2105/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/xml"));
        }

        //create new blank Edit dialog and display
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditTitleBasicForm edit = new EditTitleBasicForm();
            edit.Show();
        }

        //create new Edit dialog and populate it with selected titlebasic object and display 
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (titleBasicID != null)
            {
                EditTitleBasicForm edit = new EditTitleBasicForm();
                edit.GetTitleBasicByID(titleBasicID);
                edit.Show();
            }
        }

        //doesn't do anything.  Save function is on EditTitleBasicForm...not here
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saved");
        }

        //clears searchbox, page number, total count and creates new empty list and re-runs window
        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            m_txtTest.Text = "";
            PageNumber.Content = "";
            TotalCount.Content = "";
            titleBasicList = new List<titlebasic>();
            ObserveTitleBasicList = new ObservableCollection<titlebasic>(titleBasicList);
            DataContext = ObserveTitleBasicList;
            Run();
        }

        //deletes selected entry from database as per tconst
        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = titleBasicID;

            var url = "api/titlebasics/" + id;

            HttpResponseMessage response = await Client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("You have deleted " + titleBasicID);
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        //calls search method when button clicked
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        //calls search method when user double clicks on search box
        private void M_txtTest_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Search();
        }

        //calls search method when user hits enter in search box
        private void M_txtTest_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                Search();
            }
        }

        //searches for user from database based on text in search box searching for tconst
        private async void Search()
        {

            var id = m_txtTest.Text.Trim();
            var url = "api/titlebasics/?id=" + id + "&startindex=" + pageIndex + "&pagesize=" + pageSize;
            HttpResponseMessage response = Client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                PageNumber.Content = pageIndex + 1;
                var titlebasics = await response.Content.ReadAsAsync<IEnumerable<titlebasic>>();
                ienumerableCount = titlebasics.Count();
                TotalCount.Content = ienumerableCount;
                asList = titlebasics.ToList();
                ObserveTitleBasicList = new ObservableCollection<titlebasic>(asList);
                DataContext = ObserveTitleBasicList;              
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        //when selection changes in listview the tconst for that selection becomes the titleBasicID
        private void ListView1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (titlebasic item in e.AddedItems)
            {
                titleBasicID = item.tconst;
            }
        }

        //when mouse enters searchbox the word "Search" appears if the textbox is blank
        private void SearchBar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (m_txtTest.Text == "")
            {
                m_txtTest.Text = "Search";
            }
        }

        //if the searchbox contains the word "Search" when mouse enters searchbox the word "Search" disappears
        private void SearchBar_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (m_txtTest.Text.Equals("Search"))
            {
                m_txtTest.Text = "";
            }
        }

        //if pageIndex is greater than 0 subtracts 1 from pageIndex and runs search based on new pageindex
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex > 0)
            {
             
                pageIndex--;
                PageNumber.Content = pageIndex + 1;
                var t = Task.Run(() => {
                    Dispatcher.BeginInvoke(new ThreadStart(() => Search()));
                });
                t.Wait();
            }
        }

        //advance pageIndex to next page and runs search based on new pageIndex
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            pageIndex++;
            PageNumber.Content = pageIndex + 1;
            var t = Task.Run(() => {
                Dispatcher.BeginInvoke(new ThreadStart(() => Search()));
            });
            t.Wait();
        }


        //NOT USED.  COULD NOT GET IT TO PROPERLY CALL TITLEBASICCONTROLLER CLASS
        //private async void GetCount()
        //{
        //    MessageBox.Show("Count Start");
        //    var url = "api/titlebasics/?startindex=0"; //this line should be modified to correct URL
        //    HttpResponseMessage response = await Client.GetAsync(url);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var titlebasics = await response.Content.ReadAsAsync<IEnumerable<titlebasic>>();
        //        ienumerableCount = titlebasics.Count();
        //        TotalCount.Content = ienumerableCount.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
        //    }
        //}
    }
}



