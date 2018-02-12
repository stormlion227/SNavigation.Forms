
using Android.Content;
using Stormlion.SNavigation.Droid;
using Stormlion.SNavigation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using AToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

[assembly: ExportRenderer(typeof(SNavigationPage), typeof(SNavigationPageRenderer))]
namespace Stormlion.SNavigation.Droid
{
    public class SNavigationPageRenderer : NavigationPageRenderer
    {
        IVisualElementRenderer _navRenderer = null;
        Xamarin.Forms.View _navView = null;

        protected AToolbar ToolBar
        {
            get
            {
                for (int i = 0; i < ChildCount; i++)
                {
                    if (GetChildAt(i) is AToolbar)
                    {
                        return GetChildAt(i) as AToolbar;
                    }
                }
                return null;
            }
        }

        public SNavigationPageRenderer(Context context) : base(context)
        {
            if(Platform.Context == null)
                Platform.Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                if (e.NewElement.CurrentPage != null)
                {
                    ResetNavView();
                }
            }
        }

        private void ResetNavView()
        {
            if (_navRenderer != null)
            {
                ToolBar.RemoveView(_navRenderer.View);
                _navRenderer = null;
            }

            _navView = SNavigationPage.GetNavContent(Element.CurrentPage);
            if (_navView == null)
                return;

            _navRenderer = Xamarin.Forms.Platform.Android.Platform.GetRenderer(_navView);
            if (_navRenderer == null)
            {
                _navRenderer = Xamarin.Forms.Platform.Android.Platform.CreateRendererWithContext(_navView, Context);
                Xamarin.Forms.Platform.Android.Platform.SetRenderer(_navView, _navRenderer);
            }

            ToolBar.AddView(_navRenderer.View);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (_navRenderer != null)
            {
                Xamarin.Forms.Layout.LayoutChildIntoBoundingRegion(_navRenderer.Element, new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(ToolBar.MeasuredHeight)));
                _navRenderer.UpdateLayout();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(NavigationPage.CurrentPage))
            {
                ResetNavView();
            }
        }
    }
}