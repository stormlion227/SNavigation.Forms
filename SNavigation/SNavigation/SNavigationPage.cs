using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Stormlion.SNavigation
{
    public class SNavigationPage : NavigationPage
    {
        public static readonly BindableProperty NavContentProperty = BindableProperty.CreateAttached(
            "NavContent",
            typeof(View),
            typeof(Page),
            null,
            propertyChanged: (b, n, o) =>
            {

            });

        public static View GetNavContent(BindableObject page) => (View)page.GetValue(NavContentProperty);

        public static void SetNavContent(BindableObject page, View view) => page.SetValue(NavContentProperty, view);

        public SNavigationPage() : base()
        {
        }

        public SNavigationPage(Page root) : base(root)
        {
        }
    }
}
