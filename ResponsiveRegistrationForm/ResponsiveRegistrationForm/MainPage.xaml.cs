


using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ResponsiveRegistrationForm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OrientationChanged(OrientationValue newOrientation)
        {
            base.OrientationChanged(newOrientation);

            if (newOrientation == OrientationValue.Landscape)
            {
                RelativeLayout.SetHeightConstraint(ImageSection, Constraint.RelativeToParent((parent) => { return parent.Height; }));
                RelativeLayout.SetWidthConstraint(ImageSection, Constraint.RelativeToParent((parent) => { return parent.Width * 0.4; }));

                RelativeLayout.SetXConstraint(FormSection, Constraint.RelativeToView(ImageSection, (parent, sibling) => { return sibling.Width; }));
                RelativeLayout.SetYConstraint(FormSection, Constraint.Constant(0));
                RelativeLayout.SetHeightConstraint(FormSection, Constraint.RelativeToParent((parent) => { return parent.Height; }));
                RelativeLayout.SetWidthConstraint(FormSection, Constraint.RelativeToParent((parent) => { return parent.Width*0.6; }));

                FormSection.Padding = new Thickness(50);
            }
            else
            {
                RelativeLayout.SetHeightConstraint(ImageSection, Constraint.RelativeToParent((Parent) => { return Parent.Height * 0.3; }));
                RelativeLayout.SetWidthConstraint(ImageSection, Constraint.RelativeToParent((Parent) => { return Parent.Width; }));

                RelativeLayout.SetXConstraint(FormSection, Constraint.Constant(0));
                RelativeLayout.SetYConstraint(FormSection, Constraint.RelativeToView(ImageSection, (parent, sibling) => { return sibling.Height; }));
                RelativeLayout.SetHeightConstraint(FormSection, Constraint.RelativeToParent((parent) => { return parent.Height * 0.7; }));
                RelativeLayout.SetWidthConstraint(FormSection, Constraint.RelativeToParent((parent) => { return parent.Width; }));
                FormSection.Padding = new Thickness(25,50);
            }
        }
    }
}
