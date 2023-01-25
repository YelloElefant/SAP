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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;
using Core;
using Client.Core;
using System.Threading;

namespace form
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {


    public MainWindow()
    {
      InitializeComponent();
      //SocketClassClient.ExecuteServerAsync();


    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      string[] methods = new String[2] { "http://", "https://" };
      url.Text.Trim();
      try
      {

        Uri uri = new Uri(url.Text);
        brow.Navigate(uri);
        url.Text = brow.Source.ToString();

      }
      catch (System.Exception)
      {

        if (url.Text.Contains("https://"))
        {
          var splitUrl = url.Text.Split('/');
          var splitUrlString = splitUrl[1];
          splitUrlString = methods[0] + splitUrlString;
        }


        Uri uri = new Uri(url.Text);
        brow.Navigate(uri);

      }

    }
  }
}

