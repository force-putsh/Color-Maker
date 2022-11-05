using CommunityToolkit.Maui.Alerts;
namespace Color_Maker;

public partial class MainPage : ContentPage
{
	bool isRandom;
	public MainPage()
	{
		InitializeComponent();
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRandom = true;
		var rand = new Random();
		var color = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
		//Debug.WriteLine(color);
		SetColor(color);
		sldBlue.Value = color.Blue;
		sldGreen.Value = color.Green;
		sldRed.Value = color.Red;
		isRandom = false;



	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(lblHex.Text);
		var toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
		await toast.Show();
	}

	private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandom)
		{
			var red = sldRed.Value;
			var green = sldGreen.Value;
			var blue = sldBlue.Value;

			Color color = Color.FromRgb(red, green, blue);

			SetColor(color);
		}
	}

	private void SetColor(Color color)
	{
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		lblHex.Text = color.ToHex();
	}
}

