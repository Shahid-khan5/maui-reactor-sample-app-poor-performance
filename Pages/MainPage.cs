using MauiReactor;
using System.Linq;


namespace maui_reactor_sample_app.Pages;

class MainPageState
{
    public int Counter { get; set; }
}

class MainPage : Component<MainPageState>
{
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new ScrollView
            {
                new VerticalStackLayout
                {
                    new Image("dotnet_bot.png")
                        .HeightRequest(200)
                        .HCenter()
                        .Set(Microsoft.Maui.Controls.SemanticProperties.DescriptionProperty, "Cute dot net bot waving hi to you!"),
                    new HandyTextBox()
                    .Label("FooBar")
                    ,
                    new Label("Hello, World!")
                        .FontSize(32)
                        .HCenter(),

                    new Label("Welcome to MauiReactor: MAUI with superpowers!")
                        .FontSize(18)
                        .HCenter(),

                    new Button(State.Counter == 0 ? "Click me" : $"Clicked {State.Counter} times!")
                        .OnClicked(()=>SetState(s => s.Counter ++))
                        .HCenter(),
                         new CollectionView()
                        .ItemsSource(Enumerable.Range(0,500).ToList(),o=>new Label().Text(o.ToString()))
                        .Background(Microsoft.Maui.Controls.Brush.Red)
                        .HeightRequest(500)
                        .WidthRequest(500)
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        }
        .Background(Microsoft.Maui.Controls.Brush.White);
    }
}