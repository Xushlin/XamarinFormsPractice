using Android.Content;
using Android.Runtime;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamDemo.Droid.Renderers;

[assembly: ExportRenderer(typeof(Entry), typeof(XamEntryRenderer))]
namespace XamDemo.Droid.Renderers
{
    public class XamEntryRenderer: EntryRenderer
    {
        public XamEntryRenderer(Context context):base(context)
        {           
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                this.Control.Background = null;
                IntPtr intPtrTextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(intPtrTextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty,Resource.Drawable.color_cursor);
                this.Control.Background = Context.GetDrawable(Resource.Drawable.editor_bg);
                this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            }
        }
    }

}
