using Android.Content;
using Android.Graphics;
using OBDoctor.Controls;
using OBDoctor.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CirclePathView), typeof(CirclePathRenderer))]
namespace OBDoctor.Droid {
    public class CirclePathRenderer : ViewRenderer {
        public CirclePathRenderer(Context context) : base(context) {
            SetWillNotDraw(false);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                ((CirclePathView)e.NewElement).CurrentValueChanged = OnCurrentValueChanged;

            if (e.OldElement != null)
                ((CirclePathView)e.OldElement).CurrentValueChanged = null;
        }


        private void OnCurrentValueChanged() {
            Invalidate();
        }

        public override void Draw(Canvas canvas) {
            base.Draw(canvas);
            var paint = new Paint();
            paint.SetStyle(Paint.Style.Stroke);
            var pathWidth = Context.ToPixels(10);
            paint.StrokeWidth = pathWidth;
            var view = Element as CirclePathView;
            paint.Color = view.LineColor.ToAndroid();
            var span = view.MaxValue - view.MinValue;
            var currentPercent = view.CurrentValue / span;
            canvas.DrawArc(pathWidth, pathWidth, canvas.Width - pathWidth, canvas.Height - pathWidth, 140, (float)(260f * currentPercent), false, paint);
        }
    }
}