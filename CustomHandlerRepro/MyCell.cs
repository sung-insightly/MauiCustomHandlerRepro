using System;
namespace CustomHandlerRepro
{
    public class MyCell : ViewCell
    {
        public MyCell()
        {
            View = new Grid
            {
                Children =
                {
                    new Label
                    {
                        Text = "My Cell",
                        TextColor = Colors.Black,
                        HeightRequest = 100,
                    }
                }
            };
        }
    }
}

