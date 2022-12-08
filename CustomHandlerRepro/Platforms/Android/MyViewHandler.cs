using System;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using AListView = Android.Widget.ListView;

namespace CustomHandlerRepro.Platforms.Android
{
    public class MyViewHandler : ViewHandler<MyView, AListView>
    {
        static IPropertyMapper<MyView, MyViewHandler> Mapper = new PropertyMapper<MyView, MyViewHandler>();

        public MyViewHandler() : base(Mapper)
        {
        }

        protected override AListView CreatePlatformView()
        {
            return new AListView(Context)
            {
                Adapter = new MyAdapter(MauiContext),
            };
        }

        private class MyAdapter : BaseAdapter<object>
        {
            private IMauiContext mauiContext;

            public MyAdapter(IMauiContext mauiContext)
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

            public override object this[int position] => null;

            public override int Count => 10;

            public override long GetItemId(int position) => position;

            public override global::Android.Views.View GetView(int position, global::Android.Views.View convertView, ViewGroup parent)
            {
                return (global::Android.Views.View)new MyCell().ToPlatform(mauiContext);
            }
        }
    }
}

