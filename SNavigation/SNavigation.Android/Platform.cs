
using Android.Content;

namespace Stormlion.SNavigation.Droid
{
    public class Platform
    {
        internal static Context Context = null;

        public static void Init(Context context)
        {
            Context = context;
        }
    }
}