﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Coding4Fun.Toolkit.Controls
{
    public class ActionPopUp<T, TPopUpResult> : PopUp<T, TPopUpResult>
    {
        private const string ActionButtonAreaName = "actionButtonArea";
        protected Panel ActionButtonArea;

        public override void OnApplyTemplate()
        {
            Focus();

            base.OnApplyTemplate();
            ActionButtonArea = GetTemplateChild(ActionButtonAreaName) as Panel;

            SetButtons();
        }

		#region Control Events
		#endregion

		#region helper methods
		private void SetButtons()
		{
			if (ActionButtonArea == null)
				return;

			ActionButtonArea.Children.Clear();

			var hasContent = false;

			foreach (var button in ActionPopUpButtons)
			{
				ActionButtonArea.Children.Add(button);

				hasContent |= (button.Content != null);
			}

			if (hasContent)
				ActionButtonArea.Margin = new Thickness();
		}
		#endregion

		#region Dependency Property Callbacks
		private static void OnActionPopUpButtonsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var sender = ((ActionPopUp<T, TPopUpResult>)o);

			if (sender != null && e.NewValue != e.OldValue)
				sender.SetButtons();
		}
		#endregion

		#region Dependency Properties / Properties
		public List<Button> ActionPopUpButtons
		{
			get { return (List<Button>)GetValue(ActionPopUpButtonsProperty); }
			set { SetValue(ActionPopUpButtonsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ActionPopUpButtons.  This enables animation, styling, binding, etc...
		public readonly DependencyProperty ActionPopUpButtonsProperty =
			DependencyProperty.Register("ActionPopUpButtons", typeof(List<Button>), typeof(ActionPopUp<T, TPopUpResult>), new PropertyMetadata(new List<Button>(), OnActionPopUpButtonsChanged));

		#endregion
	}
}
