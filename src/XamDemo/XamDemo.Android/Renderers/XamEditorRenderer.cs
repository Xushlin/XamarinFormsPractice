using Android.Content;
using Android.Runtime;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamDemo.Droid.Renderers;

[assembly: ExportRenderer(typeof(Editor), typeof(XamEditorRenderer))]
namespace XamDemo.Droid.Renderers
{
    public class XamEditorRenderer : EditorRenderer {
        public XamEditorRenderer(Context context):base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            this.Control.Background = null;
            IntPtr intPtrTextViewClass = JNIEnv.FindClass(typeof(TextView));
            IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(intPtrTextViewClass, "mCursorDrawableRes", "I");
            JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.color_cursor);
            this.Control.Background = Context.GetDrawable(Resource.Drawable.editor_bg);
            this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            this.Control.SetCompoundDrawablesWithIntrinsicBounds(null, null, Context.GetDrawable(Resource.Drawable.abc_ic_arrow_drop_right_black_24dp), null);
            
        }
    }

}
