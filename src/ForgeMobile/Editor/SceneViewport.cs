using Android.Content;
using Android.Graphics;
using Android.Views;

namespace ForgeMobile.Editor;

public sealed class SceneViewport : View
{
    private readonly Paint _paint = new() { AntiAlias = true, StrokeWidth = 1 };
    public string SelectedName { get; set; } = "Cube";
    public Action? OnViewportTap { get; set; }

    public SceneViewport(Context context) : base(context)
    {
        SetBackgroundColor(Color.Rgb(24, 29, 38));
        Clickable = true;
    }

    protected override void OnDraw(Canvas canvas)
    {
        base.OnDraw(canvas);
        var w = Width;
        var h = Height;
        if (w <= 0 || h <= 0) return;
        _paint.Color = Color.Rgb(24, 29, 38);
        _paint.Style = Paint.Style.Fill;
        canvas.DrawRect(0, 0, w, h, _paint);

        _paint.Color = Color.Rgb(43, 52, 66);
        var step = Math.Max(24, (int)(Math.Min(w, h) / 14f));
        for (var x = w / 2 % step; x < w; x += step) canvas.DrawLine(x, 0, x, h, _paint);
        for (var y = h / 2 % step; y < h; y += step) canvas.DrawLine(0, y, w, y, _paint);

        var cx = w * .52f;
        var cy = h * .48f;
        var size = Math.Min(w, h) * .19f;
        var offset = size * .42f;
        var front = new[] { new PointF(cx-size,cy-size), new PointF(cx+size,cy-size), new PointF(cx+size,cy+size), new PointF(cx-size,cy+size) };
        var back = front.Select(p => new PointF(p.X+offset,p.Y-offset)).ToArray();

        _paint.Color = Color.Rgb(75, 145, 235);
        _paint.StrokeWidth = 3;
        _paint.Style = Paint.Style.Stroke;
        DrawLoop(canvas, front);
        DrawLoop(canvas, back);
        for (var i = 0; i < 4; i++) canvas.DrawLine(front[i].X, front[i].Y, back[i].X, back[i].Y, _paint);

        _paint.Style = Paint.Style.Fill;
        _paint.Color = Color.Rgb(90, 165, 255);
        canvas.DrawCircle(cx, cy + size + 22, 5, _paint);
        _paint.Color = Color.Rgb(225, 232, 242);
        _paint.TextSize = 14;
        canvas.DrawText("SCENE VIEW / EDITOR PREVIEW", 18, 28, _paint);
        _paint.Color = Color.Rgb(160, 177, 198);
        _paint.TextSize = 12;
        canvas.DrawText("Selected: " + SelectedName, 18, 48, _paint);
        canvas.DrawText("Touch viewport to focus selection", 18, h - 18, _paint);
    }

    private void DrawLoop(Canvas canvas, PointF[] points)
    {
        for (var i = 0; i < points.Length; i++)
        {
            var a = points[i];
            var b = points[(i + 1) % points.Length];
            canvas.DrawLine(a.X, a.Y, b.X, b.Y, _paint);
        }
    }

    public override bool OnTouchEvent(MotionEvent? e)
    {
        if (e?.Action == MotionEventActions.Up)
        {
            OnViewportTap?.Invoke();
            PerformClick();
            return true;
        }
        return true;
    }

    public override bool PerformClick() { base.PerformClick(); return true; }
}
