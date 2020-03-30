using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoApp1
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
   public sealed partial class MainPage : Page
   {
      const string cVoice1 = "Microsoft David Desktop";
      const string cVoice2 = "Microsoft Zira Desktop";
      string currentVoice = cVoice1;
      Random r = new Random();
      DispatcherTimer t = new DispatcherTimer();
      public MainPage()
      {
         this.InitializeComponent();
         t.Stop();
         t.Interval = TimeSpan.Zero;
         t.Tick += new EventHandler<object>(OnTick);
      }

      void voice1_onclick(object sender, RoutedEventArgs e)
      {
         currentVoice = cVoice1;
      }
      void voice2_onclick(object sender, RoutedEventArgs e)
      {
         currentVoice = cVoice2;
      }
      void AutoTimer_ValueChanged(object sender, RoutedEventArgs e)
      {
         if (AutoTimer.Value > 0)
         {
            timerLabel.Text = string.Format("Spin every {0} second(s)", AutoTimer.Value);
            t.Interval = new TimeSpan(0,0,0,(int)AutoTimer.Value);
            t.Start();
         }
         else
         {
            timerLabel.Text = "Click the button, or slide for timer.";
            t.Stop();
         }
      }

      void OnTick(object sender, object e)
      {
         Spin();
      }
      private void SpinButton_OnClick(object sender, RoutedEventArgs e)
      {
         Spin();
      }

      private void Spin()
      {
         string partColor = NextItem();
         SpinButton.Content = partColor;
         PlaySound(partColor);
      }
      void PlaySound(string partColor)
      {
         //player1.Source = MediaSource.CreateFromUri(new Uri("https://file-examples.com/wp-content/uploads/2017/11/file_example_MP3_700KB.mp3"));

         player1.Source = MediaSource.CreateFromUri(new Uri(string.Format("ms-appx:///Assets/{0}/{1}.mp3", currentVoice, partColor)));
      }


      string[] bodyParts = { "Left Hand", "Right Hand", "Left Foot", "Right Foot" };
      string[] colors = { "Red", "Green", "Yellow", "Blue" };
      private string NextItem()
      {
         var nextPart = r.Next(0, 3);
         var nextColor = r.Next(0, 3);

         return string.Join(" ", bodyParts[nextPart], colors[nextColor]);
      }
   }
}
