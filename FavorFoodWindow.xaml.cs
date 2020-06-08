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
using System.IO;
using System.Collections.ObjectModel;

namespace _18600287
{
    /// <summary>
    /// Interaction logic for FavorFoodWindow.xaml
    /// </summary>
    public partial class FavorFoodWindow : Window
    {
        public FavorFoodWindow()
        {
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			string line;
			string[] strContainAfterSplit;
			
			var favorFoodList = new ObservableCollection<CFoodRecepies>();
			var folder = AppDomain.CurrentDomain.BaseDirectory;
			FileStream fileStream = new FileStream($"{folder}FavorFood.txt", FileMode.Open, FileAccess.Read);
			CFoodRecepies tmp = new CFoodRecepies();            //temp

			using (StreamReader rd = new StreamReader(fileStream, Encoding.UTF8))
			{
				for (int i = 0; i < 4; i++)
				{
					line = rd.ReadLine();
					strContainAfterSplit = line.Split('-');
					tmp.FoodImage = strContainAfterSplit[0];
					tmp.FoodName = strContainAfterSplit[1];
					tmp.Like = int.Parse(strContainAfterSplit[2]);
					tmp.DisLike = int.Parse(strContainAfterSplit[3]);

					favorFoodList.Add(tmp);
				}
			}
			FavorFoodListBox.ItemsSource = favorFoodList;
		}

		//Detail TextBlock

		//Like Button

		//Dislike Button.
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Write Back Into File Even Data Change Or Not 
		}
	}
}
