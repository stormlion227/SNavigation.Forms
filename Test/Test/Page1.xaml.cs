using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        protected void OnClickedPage2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }

        protected void OnClickedBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}