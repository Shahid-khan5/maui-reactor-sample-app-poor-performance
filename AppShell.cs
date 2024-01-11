using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using maui_reactor_sample_app.Pages;
using MauiReactor;

namespace maui_reactor_sample_app;

class AppShell : Component
{
    public override VisualNode Render()
        => new Shell
        {
            new FlyoutItem("MainPage")
            {
                new ShellContent()
                    .Title("MainPage")
                    .RenderContent(()=>new MainPage())
            },
            new FlyoutItem("OtherPage")
            {
                new ShellContent()
                    .Title("OtherPage")
                .Icon("ico.")
                    .RenderContent(()=>new OtherPage())
            }
        }
        .FlyoutBehavior(FlyoutBehavior.Locked)
        .ItemTemplate(RenderItemTemplate);

    static VisualNode RenderItemTemplate(MauiControls.BaseShellItem item)
        => new Grid("68", "*")
        {
            new Label(item.Title)
                .VCenter()
                .Margin(10,0)
        };
}

