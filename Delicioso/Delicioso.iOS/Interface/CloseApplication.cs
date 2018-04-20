using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Delicioso.Interface;
using FastFoodApp.iOS.Interface;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CloseApplication))]

namespace FastFoodApp.iOS.Interface
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}