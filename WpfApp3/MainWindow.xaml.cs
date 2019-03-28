using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using TagLib;
using WMPLib;
using WpfApp3.Classes;
using WpfApp3.Frames;
using WpfApp3.Windows;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private Playlist currentPlaylist;

        private FrmLocal frmLocal;

        private FrmDownload frmDownload;

        private FrmPlayList frmPlayList;

        private FrmYoutube frmYoutube;

        private bool isShuffleTrue, isRepeatTrue;

        public MainWindow()
        {
            InitializeComponent();

            sliderVolume.Value = 30;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartTitleAnimation();
        }
        private void BtnLocal_Click(object sender, RoutedEventArgs e)
        {
            frmLocal = new FrmLocal(mediaPlayer);
            frmMain.Content = frmLocal;
            currentPlaylist = frmLocal.GetPlaylist();
            
            HideGridBtn();
        }

        private void BtnYouTube_Click(object sender, RoutedEventArgs e)
        {
            if(frmYoutube == null)
                 frmYoutube = new FrmYoutube(mediaPlayer);

            frmMain.Content = frmYoutube;

            HideGridBtn();
        }
        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            frmDownload = new FrmDownload(mediaPlayer);
            frmMain.Content = frmDownload;
            currentPlaylist = frmDownload.GetPlaylist();

            HideGridBtn();
        }

        private void BtnPlayList_Click(object sender, RoutedEventArgs e)
        {
            OpenPlaylistWindow openPlaylistWindow  = new OpenPlaylistWindow(mediaPlayer, frmMain);
            openPlaylistWindow.ShowDialog();

            if(openPlaylistWindow.GetCurrentFramePlaylist() != null)
            {
                frmPlayList = openPlaylistWindow.GetCurrentFramePlaylist();
                currentPlaylist = frmPlayList.GetPlaylist();
            }

            HideGridBtn();
        }

        private void BtnListButtons_Click(object sender, RoutedEventArgs e)
        {
            if (gridBtnChoices.IsVisible != true)
                gridBtnChoices.Visibility = Visibility.Visible;
            else
            {
                HideGridBtn();
            }
        }
        private void HideGridBtn()
        {
            gridBtnChoices.Visibility = Visibility.Hidden;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            SetWindowState();
        }
        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Top_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                if (e.ClickCount == 2)
                    SetWindowState();
                else
                {
                    SetWindowState();
                    DragMove();
                }
        }
        private void SetWindowState()
        {
            Thickness marginThickness;

            if (WindowState == WindowState.Normal)
            {
                marginThickness = new Thickness(7);
                gridMain.Margin = marginThickness;
                WindowState = WindowState.Maximized;
            }
            else
            {
                marginThickness = new Thickness(0);
                gridMain.Margin = marginThickness;
                WindowState = WindowState.Normal;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Thickness marginThickness;

            if (WindowState == WindowState.Maximized)
            {
                marginThickness = new Thickness(7);
                btnMin.Content = FindResource("imgMin");
            }
            else
            {
                marginThickness = new Thickness(0);
                btnMin.Content = FindResource("imgMax");
            }

            gridMain.Margin = marginThickness;
        }
        private void StartTitleAnimation()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.To = -txtMovingText.ActualWidth;
            doubleAnimation.From = canMain.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:15"));
            txtMovingText.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }
        private void BtnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (btnPlayPause.Content == FindResource("imgPlay") && mediaPlayer.Source != null)
            {
                mediaPlayer.Play();
                btnPlayPause.Content = FindResource("imgPause");
            }
            else
            {
                mediaPlayer.Pause();
                btnPlayPause.Content = FindResource("imgPlay");
            }
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            sliderMediaProgress.Value = mediaPlayer.Position.TotalSeconds;

            labelMediaProgressTime.Content = TimeSpan.FromSeconds(sliderMediaProgress.Value).ToString(@"mm\:ss");
        }

        private void SliderMediaProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = TimeSpan.FromSeconds(e.NewValue);
            mediaPlayer.Position = ts;
        }
        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = sliderVolume.Value / 100;// 0 to 1 //0.5 is default
            labelVolume.Content = (int)(sliderVolume.Value);
        }
        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            SetMaxSliderMedia();

            btnPlayPause.Content = FindResource("imgPause");

            LoadBackGroundsAndText();

            if (frmMain.Content == frmLocal)
                frmLocal.ChangeSelectedIndex();
            else if(frmMain.Content == frmPlayList)
                frmPlayList.ChangeSelectedIndex();
            else if(frmMain.Content == frmDownload)
                frmDownload.ChangeSelectedIndex();

            StartSliderMedia();
        }
        private void StartSliderMedia()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0);
            dispatcherTimer.Start();
        }
        private void SetMaxSliderMedia()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds);
            sliderMediaProgress.Maximum = ts.TotalSeconds;
            labelMediaProgressTotalTime.Content = TimeSpan.FromSeconds(ts.TotalSeconds).ToString(@"mm\:ss");
        }
        private void LoadBackGroundsAndText()
        {
            string currentMediaName = Path.GetFileNameWithoutExtension(mediaPlayer.Source.ToString());
            txtMovingText.Text = currentMediaName;

            BitmapImage bitmapImage = currentPlaylist.MediaList[currentPlaylist.GetCurrentPosition()].GetBitmapImage();

            imgMainBackground.Source = bitmapImage;
            imgPlayPauseBackground.ImageSource = bitmapImage;
        }

        private void BtnPlayNext_10sec_Click(object sender, RoutedEventArgs e)
        {
            sliderMediaProgress.Value += 10;
        }

        private void BtnPlayPrevious_10sec_Click(object sender, RoutedEventArgs e)
        {
            sliderMediaProgress.Value -= 10;
        }
        
        private void BtnRepeat_Click(object sender, RoutedEventArgs e)
        {
            isRepeatTrue = (btnRepeat.Content == FindResource("imgRepeatFalse") ? true : false);
            btnRepeat.Content = FindResource(btnRepeat.Content == FindResource("imgRepeatFalse") ? "imgRepeatTrue" : "imgRepeatFalse");
        }

        private void Btn_Shuffle_Click(object sender, RoutedEventArgs e)
        {
            isShuffleTrue = (btn_Shuffle.Content == FindResource("imgShuffleFalse") ? true : false);
            btn_Shuffle.Content = FindResource(btn_Shuffle.Content == FindResource("imgShuffleFalse") ? "imgShuffleTrue" : "imgShuffleFalse");
        }

        private void BtnPlayNext_Click(object sender, RoutedEventArgs e)
        {
            if(mediaPlayer != null)
                currentPlaylist.Next(isShuffleTrue, isRepeatTrue);
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            currentPlaylist.Next(isShuffleTrue, isRepeatTrue);
        }

        private void BtnPlayPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer != null)
                currentPlaylist.Prev();
        }
    }
}

