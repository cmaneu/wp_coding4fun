﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Coding4Fun.Toolkit.Controls
{
    public class ProgressOverlay : ContentControl
    {
        private Storyboard _fadeIn;
        private Storyboard _fadeOut;
        private Grid _layoutGrid;

		private const string FadeInName = "FadeInStoryboard";
        private const string FadeOutName = "FadeOutStoryboard";
        private const string LayoutGridName = "LayoutGrid";
        
        public ProgressOverlay()
        {
            DefaultStyleKey = typeof(ProgressOverlay);
        }

        public object ProgressControl
        {
            get { return (object)GetValue(ProgressControlProperty); }
            set { SetValue(ProgressControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressControl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressControlProperty =
            DependencyProperty.Register("ProgressControl", typeof(object), typeof(ProgressOverlay), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            _fadeIn = GetTemplateChild(FadeInName) as Storyboard;
            _fadeOut = GetTemplateChild(FadeOutName) as Storyboard;
            _layoutGrid = GetTemplateChild(LayoutGridName) as Grid;
            
            if(_fadeOut != null)
                _fadeOut.Completed += FadeOutCompleted;
        }

        void FadeOutCompleted(object sender, EventArgs e)
        {
            _layoutGrid.Opacity = 1;
            Visibility = Visibility.Collapsed;
        }

        public void Show()
        {
            if (_fadeIn == null)
                ApplyTemplate();
            
            Visibility = Visibility.Visible;
            
            if (_fadeOut != null)
                _fadeOut.Stop();

            if (_fadeIn != null)
                _fadeIn.Begin();
        }

        public void Hide()
        {
            if (_fadeOut == null)
                ApplyTemplate();

            if (_fadeIn != null)
                _fadeIn.Stop();

            if (_fadeOut != null) 
                _fadeOut.Begin();
        }
    }
}
