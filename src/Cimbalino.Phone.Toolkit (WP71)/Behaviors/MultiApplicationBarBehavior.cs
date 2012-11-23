// ****************************************************************************
// <copyright file="MultiApplicationBarBehavior.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.ComponentModel;
using System.Windows;
using Microsoft.Phone.Controls;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that creates a collection of bindable <see cref="Microsoft.Phone.Shell.ApplicationBar" /> controls.
    /// </summary>
    [System.Windows.Markup.ContentProperty("ApplicationBars")]
    public class MultiApplicationBarBehavior : SafeBehavior<FrameworkElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiApplicationBarBehavior" /> class.
        /// </summary>
        public MultiApplicationBarBehavior()
        {
            ApplicationBars = new ApplicationBarCollection();
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            AssociatedObject.LayoutUpdated += AssociatedObjectOnLayoutUpdated;

            base.OnAttached();
        }

        /// <summary>
        /// Gets or sets the list of Application Bars.
        /// </summary>
        /// <value>The list of Application Bars.</value>
        public ApplicationBarCollection ApplicationBars
        {
            get { return (ApplicationBarCollection)GetValue(ApplicationBarsProperty); }
            set { SetValue(ApplicationBarsProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ApplicationBars" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ApplicationBarsProperty =
            DependencyProperty.Register("ApplicationBars", typeof(ApplicationBarCollection), typeof(MultiApplicationBarBehavior), null);

        /// <summary>
        /// Gets or sets the index of the selected Application Bar.
        /// </summary>
        /// <value>the index of the selected Application Bar.</value>
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="SelectedIndex" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(MultiApplicationBarBehavior), new PropertyMetadata(-1, OnSelectedIndexChanged));

        /// <summary>
        /// Called after the index of the selected Application Bar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (MultiApplicationBarBehavior)d;

            element.Update();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Application Bar is visible.
        /// </summary>
        /// <value>true if the Application Bar is visible; otherwise, false.</value>
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="IsVisible" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("Visible", typeof(bool), typeof(MultiApplicationBarBehavior), new PropertyMetadata(true, OnIsVisibleChanged));

        /// <summary>
        /// Called after the visible state of the Application Bar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (MultiApplicationBarBehavior)d;

            element.Update();
        }

        private void AssociatedObjectOnLayoutUpdated(object sender, EventArgs eventArgs)
        {
            AssociatedObject.LayoutUpdated -= AssociatedObjectOnLayoutUpdated;

            Update();
        }

        private void Update()
        {
            if (DesignerProperties.IsInDesignTool)
            {
                return;
            }

            var page = AssociatedObject.Parent as PhoneApplicationPage;

            if (page == null)
            {
                throw new Exception("This MultiApplicationBarBehavior element can only be attached to the LayoutRoot element");
            }

            var selectedIndex = SelectedIndex;

            if (IsVisible && selectedIndex >= 0 && selectedIndex <= ApplicationBars.Count - 1)
            {
                page.ApplicationBar = ApplicationBars[selectedIndex].InternalApplicationBar;
            }
            else
            {
                page.ApplicationBar = null;
            }
        }
    }
}