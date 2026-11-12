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

        // Skybox-like scene background and a perspective ground plane.
        _paint.SetStyle(Paint.Style.Fill);
        using var skyGradient = new LinearGradient(0, 0, 0, h * .68f,
            Color.Rgb(91, 139, 174), Color.Rgb(91, 99, 101), Shader.TileMode.Clamp);
        _paint.SetShader(skyGradient);
        canvas.DrawRect(0, 0, w, h, _paint);
        _paint.SetShader(null);
        var horizon = h * .61f;
        _paint.Color = Color.Rgb(89, 91, 86);
        canvas.DrawRect(0, horizon, w, h, _paint);

        // Perspective floor grid converging at the horizon.
        _paint.Color = Color.Rgb(139, 145, 136);
        _paint.StrokeWidth = 1;
        _paint.SetStyle(Paint.Style.Stroke);
        var vanX = w * .52f;
        for (var i = -12; i <= 12; i++)
        {
            var bottomX = vanX + i * w * .095f;
            canvas.DrawLine(vanX, horizon, bottomX, h, _paint);
        }
        for (var i = 1; i <= 9; i++)
        {
            var t = i / 9f;
            var y = horizon + (h - horizon) * t * t;
            canvas.DrawLine(0, y, w, y, _paint);
        }

        // Ground plane axis lines.
        _paint.StrokeWidth = 2;
        _paint.Color = Color.Rgb(190, 74, 65);
        canvas.DrawLine(0, horizon + 5, w, horizon + 5, _paint);
        _paint.Color = Color.Rgb(80, 145, 220);
        canvas.DrawLine(vanX, horizon, vanX, h, _paint);

        // Selected shaded cube, with visible top and side faces.
        var size = Math.Min(w, h) * .20f;
        var cx = w * .51f;
        var cy = h * .48f;
        var dx = size * .48f;
        var dy = size * .30f;
        var p0 = new PointF(cx - size, cy - size * .68f);
        var p1 = new PointF(cx + size, cy - size * .68f);
        var p2 = new PointF(cx + size, cy + size * 1.05f);
        var p3 = new PointF(cx - size, cy + size * 1.05f);
        var q0 = new PointF(p0.X + dx, p0.Y - dy);
        var q1 = new PointF(p1.X + dx, p1.Y - dy);
        var q2 = new PointF(p2.X + dx, p2.Y - dy);

        var leftFace = new Android.Graphics.Path();
        leftFace.MoveTo(p0.X, p0.Y); leftFace.LineTo(p3.X, p3.Y);
        leftFace.LineTo(p2.X, p2.Y); leftFace.LineTo(q2.X, q2.Y);
        leftFace.LineTo(q0.X, q0.Y); leftFace.Close();
        _paint.SetStyle(Paint.Style.Fill);
        _paint.Color = Color.Rgb(95, 105, 116);
        canvas.DrawPath(leftFace, _paint);

        var rightFace = new Android.Graphics.Path();
        rightFace.MoveTo(p0.X, p0.Y); rightFace.LineTo(p1.X, p1.Y);
        rightFace.LineTo(p2.X, p2.Y); rightFace.LineTo(q2.X, q2.Y);
        rightFace.LineTo(q0.X, q0.Y); rightFace.Close();
        _paint.Color = Color.Rgb(46, 54, 64);
        canvas.DrawPath(rightFace, _paint);

        var topFace = new Android.Graphics.Path();
        topFace.MoveTo(p0.X, p0.Y); topFace.LineTo(p1.X, p1.Y);
        topFace.LineTo(q1.X, q1.Y); topFace.LineTo(q0.X, q0.Y);
        topFace.Close();
        _paint.Color = Color.Rgb(165, 174, 181);
        canvas.DrawPath(topFace, _paint);

        _paint.SetStyle(Paint.Style.Stroke);
        _paint.Color = Color.Rgb(255, 160, 65);
        _paint.StrokeWidth = 2.5f;
        canvas.DrawPath(leftFace, _paint);
        canvas.DrawPath(rightFace, _paint);
        canvas.DrawPath(topFace, _paint);

        // Move gizmo at the object pivot.
        var gx = cx + dx * .35f;
        var gy = cy + size * .25f;
        _paint.StrokeWidth = 3;
        _paint.Color = Color.Rgb(70, 175, 95);
        canvas.DrawLine(gx, gy, gx, gy - size * .82f, _paint);
        _paint.Color = Color.Rgb(70, 135, 245);
        canvas.DrawLine(gx, gy, gx + size * .92f, gy + size * .30f, _paint);
        _paint.Color = Color.Rgb(220, 75, 65);
        canvas.DrawLine(gx, gy, gx - size * .82f, gy + size * .36f, _paint);
        _paint.SetStyle(Paint.Style.Fill);
        _paint.Color = Color.Rgb(235, 239, 244);
        canvas.DrawCircle(gx, gy, 4, _paint);

        // Scene view overlays and axis gizmo.
        _paint.Color = Color.Rgb(31, 38, 47);
        _paint.TextSize = 12;
        canvas.DrawText("Scene", 12, 19, _paint);
        _paint.Color = Color.Rgb(240, 243, 246);
        _paint.TextSize = 10;
        canvas.DrawText("Shaded  ▾", 12, 35, _paint);
        canvas.DrawText("Selected: " + SelectedName, 12, h - 12, _paint);
        var ax = w - 36f; var ay = 36f;
        _paint.StrokeWidth = 2.5f;
        _paint.Color = Color.Rgb(220, 80, 72); canvas.DrawLine(ax, ay, ax + 17, ay + 4, _paint);
        _paint.Color = Color.Rgb(90, 190, 110); canvas.DrawLine(ax, ay, ax, ay - 18, _paint);
        _paint.Color = Color.Rgb(80, 145, 235); canvas.DrawLine(ax, ay, ax - 13, ay + 12, _paint);
        _paint.SetStyle(Paint.Style.Fill);
        _paint.TextSize = 9;
        _paint.Color = Color.White;
        canvas.DrawText("X", ax + 18, ay + 7, _paint);
        canvas.DrawText("Y", ax - 3, ay - 21, _paint);
        canvas.DrawText("Z", ax - 23, ay + 19, _paint);
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
