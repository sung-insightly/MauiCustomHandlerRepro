using System;
using Foundation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace CustomHandlerRepro.Platforms.iOS
{
    public class MyViewHandler : ViewHandler<MyView, UITableView>
    {
        static IPropertyMapper<MyView, MyViewHandler> Mapper = new PropertyMapper<MyView, MyViewHandler>();

        public MyViewHandler() : base(Mapper)
        {
        }

        protected override UITableView CreatePlatformView()
        {
            return new UITableView
            {
                Source = new MySource(MauiContext),
            };
        }

        private class MySource : UITableViewSource
        {
            private IMauiContext mauiContext;

            public MySource(IMauiContext mauiContext)
            {
                this.mauiContext = mauiContext;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    mauiContext = null;
                }
                base.Dispose(disposing);
            }

            public override nint RowsInSection(UITableView tableView, nint section) => 10;

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var platformCell = (UITableViewCell)new MyCell().ToPlatform(mauiContext);
                return platformCell;
            }
        }
    }
}

