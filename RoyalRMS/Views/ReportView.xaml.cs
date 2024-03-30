namespace RoyalRMS.Views;

public partial class ReportView : ContentPage
{
	public ReportView()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///home");
        return true;
    }
}