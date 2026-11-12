using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
namespace ForgeMobile.Services;

// Reusable branded startup screen. Call Show(activity, projectName) before editor setup.
public static class EngineSplashScreen
{
 public static void Show(Activity activity,string projectName)
 {
  var root=new LinearLayout(activity){Orientation=Orientation.Vertical};
  root.SetGravity(GravityFlags.Center);root.SetPadding(32,24,32,24);root.SetBackgroundColor(Color.Rgb(13,17,25));
  var mark=new TextView(activity){Text="◆",TextSize=58,Gravity=GravityFlags.Center};
  mark.SetTextColor(Color.Rgb(89,161,255));root.AddView(mark,new LinearLayout.LayoutParams(-1,-2));
  var title=new TextView(activity){Text="CLEAR GAME ENGINE",TextSize=20,Gravity=GravityFlags.Center};
  title.SetTextColor(Color.Rgb(235,242,252));title.SetTypeface(Typeface.Default,TypefaceStyle.Bold);root.AddView(title);
  var sub=new TextView(activity){Text=projectName+"  •  Initializing workspace",TextSize=11,Gravity=GravityFlags.Center};
  sub.SetTextColor(Color.Rgb(142,160,184));root.AddView(sub);
  var progress=new ProgressBar(activity,null,Android.Resource.Attribute.ProgressBarStyleHorizontal){Indeterminate=true};
  var lp=new LinearLayout.LayoutParams(Math.Min(activity.Resources!.DisplayMetrics!.WidthPixels-96,420),12);lp.TopMargin=28;root.AddView(progress,lp);
  activity.SetContentView(root);
 }
}