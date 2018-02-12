using Stormlion.SNavigation;
using Stormlion.SNavigation.iOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SNavigationPage), typeof(SNavigationPageRenderer))]
namespace Stormlion.SNavigation.iOS
{
    public class SNavigationPageRenderer : NavigationRenderer
    {
        protected IVisualElementRenderer _navRenderer;

        protected VisualElement CurrentNavContent => SNavigationPage.GetNavContent((Element as SNavigationPage)?.CurrentPage);

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Element.PropertyChanged += HandlePropertyChanged;

            ChangedCurrentPage();
        }

        protected void ChangedCurrentPage()
        {
            if(_navRenderer != null)
            {
                _navRenderer.NativeView.RemoveFromSuperview();
            }

            if (CurrentNavContent == null)
                return;

            _navRenderer = Xamarin.Forms.Platform.iOS.Platform.CreateRenderer(CurrentNavContent);
            Xamarin.Forms.Platform.iOS.Platform.SetRenderer(CurrentNavContent, _navRenderer);
            View.AddSubview(_navRenderer.NativeView);
            View.SetNeedsLayout();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (CurrentNavContent == null)
                return;

            var navBarFrameBottom = Math.Min(NavigationBar.Frame.Bottom, 140);
            var toolbarY = NavigationBarHidden || NavigationBar.Translucent || !NavigationPage.GetHasNavigationBar((Element as SNavigationPage).CurrentPage) ? 0 : navBarFrameBottom;

            Thickness margin = (_navRenderer.Element as Xamarin.Forms.View).Margin;
            _navRenderer.NativeView.Frame = new CoreGraphics.CGRect(
                margin.Left,
                margin.Top,
                View.Bounds.Width - margin.Left - margin.Right,
                toolbarY - margin.Bottom - margin.Top
                );
            Xamarin.Forms.Layout.LayoutChildIntoBoundingRegion(_navRenderer.Element, new Rectangle(0, 0, View.Bounds.Width, toolbarY));
        }

        void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == NavigationPage.CurrentPageProperty.PropertyName)
            {
                ChangedCurrentPage();
            }
        }
    }
}

