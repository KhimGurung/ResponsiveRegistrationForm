# XamarinFormResponsiveRegistrationForm

Making page responsive in xamarin form is not that difficult. Detecting device and its orientation is the inital part and applying the changes for responsiveness is done from the code behind. A simple registration form is given here and screenshot of both landscape and potrait is given here in both android phone and tablet.

For detecting device orientation, a seperate class is made with name <b>BaseOrientationPage</b> given below.

```c#

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

```
<hr>

 ### xaml for Responsive form
 Here, you can see <b>page:BaseOrientationPage</b> instead of <b>ContentPage</b> because of <b>partial</b> keyword in class which gives <b>partial declarations of 'mainpage' must not specify different base classes</b> otherwise.
 
```xaml
<?xml version="1.0" encoding="utf-8" ?>
<page:BaseOrientationPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="ResponsiveRegistrationForm.MainPage"
             xmlns:page="clr-namespace:ResponsiveRegistrationForm">
    <RelativeLayout x:Name="RegistrationForm">
        <StackLayout x:Name="ImageSection"
                     RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToParent, Property=X}"
                     RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToParent, Property=Y}"
                     RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width}"
                     RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0.3}"
                     IsClippedToBounds="True">
            <Image  VerticalOptions="FillAndExpand" 
                    Source="cake.png"
                    Aspect="AspectFill"/>
        </StackLayout>
        <StackLayout x:Name="FormSection"
                     RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToParent, Property=X}"
                     RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToView, ElementName=ImageSection, Property=Height}"
                     RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0.7}"
                     RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width}">
            <StackLayout Spacing="0">
                <StackLayout>
                    <Label Text="REGISTRATION INFO"
                           FontSize="22"
                           FontAttributes="Bold"
                           TextColor="#2b2b2b"/>
                    <Entry Placeholder="Name" />
                </StackLayout>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Entry Placeholder="Birthdate"
                           Grid.Column="0"/>
                    <Entry Placeholder="Gender"
                           Grid.Column="1"/>
                </Grid>
                <StackLayout>
                    <Entry Placeholder="Class" />
                    <Entry Placeholder="Registration Code"
                           HorizontalOptions="Start"/>
                    <Button Text="REGISTER"
                            BackgroundColor="#50b545"
                            CornerRadius="0"
                            HorizontalOptions="Start"
                            Margin="0,10,0,0"
                            TextColor="#ffffff"
                            Padding="20,0"/>
                </StackLayout>
            </StackLayout>
        </StackLayout>
    </RelativeLayout>
</page:BaseOrientationPage>
```

<hr>

## Code behind that gives responsive behaviour

<b>OrientationChanged()</b> method is from <b>BaseOrientationPage</b> class. We dont need to show the inheritance here because we have xaml page of <b>page:BaseOrientationPage</b>, so it is excessable here.

```c#
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
```

## Screenshot of output
<table>
  <tr>
    <td>
      <h3> Tablet Landscape view </h3>
      <img src="/ResponsiveRegistrationForm/ResponsiveRegistrationForm/Images/TabLandscape.PNG" width=500 />
    </td>
    <td>
      <h3> Tablet Potrait view </h3>
      <img src="/ResponsiveRegistrationForm/ResponsiveRegistrationForm/Images/TabPotrait.PNG" height=500 />
    </td>
  </tr>
  <tr>
    <td>
      <h3> Mobile Potrait view </h3>
      <img src="/ResponsiveRegistrationForm/ResponsiveRegistrationForm/Images/mobilePotrait.PNG" height=500 />
    </td>
    <td>
      <h3> Mobile Landscape view </h3>
      <img src="/ResponsiveRegistrationForm/ResponsiveRegistrationForm/Images/mobilelandscape.PNG" width=500 />
    </td>
  </tr>
</table>



