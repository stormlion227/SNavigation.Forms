using Stormlion.SNavigation;
using Stormlion.SNavigation.iOS;
using System.ComponentModel;
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
            NavigationBar.AddSubview(_navRenderer.NativeView);
            View.SetNeedsLayout();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (CurrentNavContent == null)
                return;

            Thickness margin = (_navRenderer.Element as View).Margin;
            _navRenderer.NativeView.Frame = new CoreGraphics.CGRect(
                margin.Left,
                margin.Top,
                NavigationBar.Frame.Width - margin.Left - margin.Right,
                NavigationBar.Frame.Height - margin.Bottom - margin.Top
                );
            Layout.LayoutChildIntoBoundingRegion(_navRenderer.Element, new Rectangle(0, 0, NavigationBar.Frame.Width, NavigationBar.Frame.Height));
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

