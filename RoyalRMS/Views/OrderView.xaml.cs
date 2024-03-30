namespace RoyalRMS.Views;

public partial class OrderView : ContentPage
{
	public OrderView()
	{
		InitializeComponent();
	}
    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///home");
        return true;
    }
}