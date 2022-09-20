using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;

namespace tutorial_WPF.Views
    
{
    /// <summary>
    /// SQLite.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SQLite : Window
    {
        public static string dbFolderPath = @"C:/SQLiteTest";
        private string dbPath = string.Format("{0}{1}", dbFolderPath, "/test.sqlite");
        private SQLiteConnection conn;

        public SQLite()
        {
            InitializeComponent();

           
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SQLiteConnect()
        {
            
        }
        
        /// <summary>
        /// 생성처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string sql = "Create table Members (name varchar(20), age int)";

            SQLiteCommand command = new SQLiteCommand(sql, conn);
            int result = command.ExecuteNonQuery();

            sql = "create index idx01 on members(name)";
            command = new SQLiteCommand(sql, conn);
            result = command.ExecuteNonQuery();
        }
        
        /// <summary>
        /// 커넥팅 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenConnect_Click(object sender, RoutedEventArgs e)
        {
            //DB파일 생성
            SQLiteConnection.CreateFile(dbPath);
            
            conn = new SQLiteConnection("DataSource=C:/SQLiteTest/test.sqlite;Version=3;");
            conn.Open();
        }
        
        /// <summary>
        /// DB Insert 테스트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            string sql = "insert into members (name, age) values ('이성범', 6)";

            SQLiteCommand command = new SQLiteCommand(sql, conn);
            int result = command.ExecuteNonQuery(); // 중복 인서트시 에러발생 

            MessageBox.Show(result.ToString()); 
        }

        private void FolderCreate_Click(object sender, RoutedEventArgs e)
        {
            //폴더 생성
            DirectoryInfo di = new DirectoryInfo(dbFolderPath);
            if(di.Exists == false)
            {
                di.Create();
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select * from members";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader["name"] + " " + reader["age"]);
            }
            
        }
    }
}
