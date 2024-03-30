namespace RoyalRMS.Views;

public partial class ProductView : ContentPage
{
	public ProductView()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///home");
        return true;
    }
}