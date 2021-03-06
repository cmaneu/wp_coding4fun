﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Coding4Fun.Toolkit.Controls.Common;
using Windows.System.Threading;
using Windows.UI;
using Windows.UI.Xaml.Input;

using Coding4Fun.Toolkit.Test.WindowsStore.Samples;
using Windows.UI.Xaml.Media;

namespace Coding4Fun.Toolkit.Test.WindowsStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
	public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

			Loaded += MainPage_Loaded;
		}

		void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			ThreadPool.RunAsync(state =>
			{
				try
				{
					LayoutRoot.Background = new SolidColorBrush(Colors.Red);

				}
				catch (Exception ex0)
				{
					Debug.WriteLine("caught: " + ex0);
				}

				SafeDispatcher.Run(() =>
				{
					LayoutRoot.Background = new SolidColorBrush(Colors.Transparent);
				});
			});
		}

		private void LockScreenTapped(object sender, TappedRoutedEventArgs e)
		{
			Frame.Navigate(typeof(LockScreenPreview));
		}

		private void ColorControlsTapped(object sender, TappedRoutedEventArgs e)
		{
			Frame.Navigate(typeof(ColorControls));
		}

		private void ButtonControlsTapped(object sender, TappedRoutedEventArgs e)
		{
			Frame.Navigate(typeof(ButtonControls));
		}

		private void AudioWrappersTapped(object sender, TappedRoutedEventArgs e)
		{
			Frame.Navigate(typeof(Samples.Audio));
		}

		private void StorageTapped(object sender, TappedRoutedEventArgs e)
		{
			Frame.Navigate(typeof(Samples.Storage));
		}

		private void ChatBubbleTapped(object sender, TappedRoutedEventArgs e)
		{
			Frame.Navigate(typeof(ChatBubbleControls));
		}

        private void SuperImageTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof (Samples.SuperImage));
        }
    }
}
