using Android.App;
using Delicioso.Droid.Interface;
using Delicioso.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(CloseApplication))]
namespace Delicioso.Droid.Interface
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}