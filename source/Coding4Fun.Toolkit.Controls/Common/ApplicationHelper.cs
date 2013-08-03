﻿
#if WINDOWS_STORE
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Display;
using Windows.UI.Core;

#elif WINDOWS_PHONE
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;

#endif

namespace Coding4Fun.Toolkit.Controls.Common
{
	public static class ApplicationSpace
	{
#if WINDOWS_STORE
		const int DefaultLogicalppi = 96;
		const int Percent = 100; 
#endif

		public static int ScaleFactor()
		{
			return
#if WINDOWS_STORE
	// http://code.msdn.microsoft.com/windowsapps/Scaling-sample-cf072f4f/sourcecode?fileId=43958&pathId=589460989
				(int) ((DisplayProperties.LogicalDpi * Percent) / DefaultLogicalppi);
#elif WINDOWS_PHONE
#if WP8
				Application.Current.Host.Content.ScaleFactor;
#else
            100;
#endif
#endif
		}

		public static bool IsDesignMode
		{
			get
			{
#if WINDOWS_STORE
				return DesignMode.DesignModeEnabled;
#elif WINDOWS_PHONE
				return DesignerProperties.IsInDesignTool;
#endif
			}
		}

		public static
#if WINDOWS_STORE
			CoreDispatcher
#elif WINDOWS_PHONE
			Dispatcher
#endif
		CurrentDispatcher
		{
			get
			{
#if WINDOWS_STORE
				var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
#elif WINDOWS_PHONE
				var dispatcher = Deployment.Current.Dispatcher;
#endif

				return dispatcher;
			}
		}
	}
}