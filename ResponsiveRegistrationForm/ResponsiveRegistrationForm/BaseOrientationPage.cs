

using Xamarin.Forms;

namespace ResponsiveRegistrationForm
{
    public class BaseOrientationPage : ContentPage
    {
        protected enum OrientationValue
        {
            Portrait,
            Landscape
        }

        private double _oldWidth, _oldHeight;

        protected virtual void OrientationChanged(OrientationValue newOrientation) { }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if(width != _oldWidth || height != _oldHeight)
            {
                _oldHeight = height;
                _oldWidth = width;

                OrientationChanged(width > height ? OrientationValue.Landscape : OrientationValue.Portrait);
            }
        }
    }
}
