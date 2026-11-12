using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using ForgeMobile.ModelMaker;

namespace ForgeMobile;

[Activity(Label="Clear Game Engine Model Maker",Theme="@android:style/Theme.Material.NoActionBar",ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape)]
public sealed class ModelMakerActivity:Activity
{
    private readonly List<ModelMesh> _meshes=new();
    private int _selected=-1;
    private ModelPreview? _preview;
    private TextView? _status;
    private LinearLayout? _list;
    private int Dp(float n)=>(int)(n*Resources!.DisplayMetrics!.Density+.5f);

    protected override void OnCreate(Bundle? state)
    {
        base.OnCreate(state);
        Window?.SetStatusBarColor(Color.Rgb(13,17,24));
        Window?.SetNavigationBarColor(Color.Rgb(13,17,24));
        var root=new LinearLayout(this){Orientation=Orientation.Vertical};
        root.SetBackgroundColor(Color.Rgb(17,21,29));SetContentView(root);
        var bar=new LinearLayout(this){Orientation=Orientation.Horizontal};
        bar.SetPadding(Dp(10),Dp(5),Dp(10),Dp(5));bar.SetGravity(GravityFlags.CenterVertical);
        bar.SetBackgroundColor(Color.Rgb(24,30,40));
        bar.AddView(Label("◆  MODEL MAKER",16,Color.Rgb(130,185,255),true),new LinearLayout.LayoutParams(0,Dp(40),1));
        bar.AddView(Button("BACK",Finish),Wrap());root.AddView(bar,new LinearLayout.LayoutParams(-1,Dp(48)));
        var tools=new HorizontalScrollView(this){HorizontalScrollBarEnabled=false};
        var toolRow=new LinearLayout(this){Orientation=Orientation.Horizontal};
        toolRow.AddView(Button("+ CUBE",()=>Add(PrimitiveFactory.Cube())),Wrap());
        toolRow.AddView(Button("+ SPHERE",()=>Add(PrimitiveFactory.UvSphere())),Wrap());
        toolRow.AddView(Button("+ PLANE",()=>Add(PrimitiveFactory.Plane())),Wrap());
        toolRow.AddView(Button("ROTATE",Rotate),Wrap());
        toolRow.AddView(Button("SCALE +",()=>Scale(1.1f)),Wrap());
        toolRow.AddView(Button("SCALE -",()=>Scale(.9f)),Wrap());
        toolRow.AddView(Button("DELETE",Delete),Wrap());
        toolRow.AddView(Button("CODE → 3D",OpenCodeEditor),Wrap());
        toolRow.AddView(Button("LOCAL AI",OpenAssistant),Wrap());
        toolRow.AddView(Button("IMPORT OBJ",ImportObj),Wrap());
        tools.AddView(toolRow);root.AddView(tools,new LinearLayout.LayoutParams(-1,Dp(44)));
        var workspace=new LinearLayout(this){Orientation=Orientation.Horizontal};
        root.AddView(workspace,new LinearLayout.LayoutParams(-1,0,1));
        _preview=new ModelPreview(this,()=>Selected);
        workspace.AddView(_preview,new LinearLayout.LayoutParams(0,-1,1));
        var side=new LinearLayout(this){Orientation=Orientation.Vertical};
        side.SetPadding(Dp(8),Dp(6),Dp(8),Dp(6));side.SetBackgroundColor(Color.Rgb(26,33,44));
        workspace.AddView(side,new LinearLayout.LayoutParams(Dp(210),-1));
        side.AddView(Label("OBJECTS",11,Color.Rgb(160,190,225),true),new LinearLayout.LayoutParams(-1,Dp(28)));
        _list=new LinearLayout(this){Orientation=Orientation.Vertical};
        var scroll=new ScrollView(this);scroll.AddView(_list);side.AddView(scroll,new LinearLayout.LayoutParams(-1,0,1));
        side.AddView(Button("EXPORT .OBJ",()=>Export(true)),new LinearLayout.LayoutParams(-1,Dp(42)));
        side.AddView(Button("EXPORT .STL",()=>Export(false)),new LinearLayout.LayoutParams(-1,Dp(42)));
        _status=Label("Ready • OBJ / STL",9,Color.Rgb(155,170,190));
        root.AddView(_status,new LinearLayout.LayoutParams(-1,Dp(28)));
        Add(PrimitiveFactory.Cube());
    }

    private ModelMesh? Selected=>_selected>=0&&_selected<_meshes.Count?_meshes[_selected]:null;
    private void Add(ModelMesh mesh){_meshes.Add(mesh);_selected=_meshes.Count-1;Refresh();}
    private void Delete(){if(Selected is null)return;_meshes.RemoveAt(_selected);_selected=Math.Min(_selected,_meshes.Count-1);Refresh();}
    private void Rotate(){if(Selected is not{} m)return;m.Rotation=new(m.Rotation.X,m.Rotation.Y+15,m.Rotation.Z);_preview?.Invalidate();UpdateStatus(m.Name+" rotated 15 degrees");}
    private void Scale(float amount){if(Selected is not{} m)return;m.Scale*=amount;_preview?.Invalidate();UpdateStatus(m.Name+" scale updated");}
    private void Refresh()
    {
        if(_list is null)return;_list.RemoveAllViews();
        for(var i=0;i<_meshes.Count;i++){var index=i;var b=Button((_selected==i?"◆  ":"◇  ")+_meshes[i].Name,()=>{_selected=index;Refresh();});_list.AddView(b,new LinearLayout.LayoutParams(-1,Dp(38)){BottomMargin=Dp(3)});}
        _preview?.Invalidate();UpdateStatus(_meshes.Count+" mesh object(s) • drag to orbit");
    }

    private void OpenCodeEditor()
    {
        var input=new EditText(this){Text=ModelScriptInterpreter.StarterScript,TextSize=12,Gravity=GravityFlags.Top|GravityFlags.Start};
        input.SetSingleLine(false);input.SetMinHeight(Dp(220));
        new AlertDialog.Builder(this).SetTitle("Code to 3D • Modeling DSL")
            .SetMessage("Commands: cube NAME, sphere NAME, plane NAME, move/scale/rotate NAME X Y Z, delete NAME.")
            .SetView(input).SetNegativeButton("CANCEL",(s,e)=>{})
            .SetPositiveButton("RUN",(s,e)=>
            {
                try { new ModelScriptInterpreter().Execute(input.Text??"",_meshes); _selected=_meshes.Count-1; Refresh(); UpdateStatus("Model script executed"); }
                catch(Exception ex) { UpdateStatus("Script error: "+ex.Message); new AlertDialog.Builder(this).SetTitle("Script error").SetMessage(ex.Message).SetPositiveButton("OK",(s,e)=>{}).Show(); }
            }).Show();
    }

    private void OpenAssistant()
    {
        var input=new EditText(this){Hint="Ask about topology, UVs, robots, mobile optimization..."};
        new AlertDialog.Builder(this).SetTitle("Clear Modeling Guide • Offline")
            .SetMessage("Curated 3D modeling knowledge. No internet or API key required.")
            .SetView(input).SetNegativeButton("CLOSE",(s,e)=>{})
            .SetPositiveButton("ASK",(s,e)=>
            {
                var reply=new LocalModelingAssistant().Ask(input.Text??"");
                var message=reply.Text+(reply.Script is null?"":"\n\nSuggested modeling code:\n"+reply.Script);
                new AlertDialog.Builder(this).SetTitle("Modeling Guide • "+reply.Topic).SetMessage(message).SetPositiveButton("OK",(s,e)=>{}).Show();
            }).Show();
    }

    private void ImportObj()
    {
        var intent=new Android.Content.Intent(Android.Content.Intent.ActionOpenDocument);
        intent.AddCategory(Android.Content.Intent.CategoryOpenable); intent.SetType("*/*");
        StartActivityForResult(intent,701);
    }

    protected override void OnActivityResult(int requestCode,Android.App.Result resultCode,Android.Content.Intent? data)
    {
        base.OnActivityResult(requestCode,resultCode,data);
        if(requestCode!=701||resultCode!=Android.App.Result.Ok||data?.Data is null)return;
        try
        {
            using var input=ContentResolver!.OpenInputStream(data.Data);
            if(input is null)throw new IOException("Unable to open selected file.");
            var temp=System.IO.Path.Combine(CacheDir!.AbsolutePath,"import_"+Guid.NewGuid().ToString("N")+".obj");
            using(var output=File.Create(temp))input.CopyTo(output);
            Add(ObjImporter.Read(temp)); UpdateStatus("OBJ model imported");
        }
        catch(Exception ex) { UpdateStatus("Import failed: "+ex.Message); Toast.MakeText(this,"OBJ import failed: "+ex.Message,ToastLength.Long)?.Show(); }
    }

    private void Export(bool obj)
    {
        if(_meshes.Count==0){UpdateStatus("Add a mesh before exporting");return;}
        try
        {
            var dir=System.IO.Path.Combine(FilesDir!.AbsolutePath,"ClearGameEngine","Exports");Directory.CreateDirectory(dir);
            var ext=obj?"obj":"stl";var path=System.IO.Path.Combine(dir,"Model_"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+"."+ext);
            if(obj)ModelExporter.WriteObj(path,_meshes);else ModelExporter.WriteStl(path,_meshes);
            UpdateStatus("Exported "+System.IO.Path.GetFileName(path));Toast.MakeText(this,"Saved: "+path,ToastLength.Long)?.Show();
        }
        catch(Exception ex){UpdateStatus("Export failed: "+ex.Message);}
    }
    private void UpdateStatus(string s){if(_status is not null)_status.Text=s;}
    private TextView Label(string s,float size,Color c,bool bold=false){var t=new TextView(this){Text=s,TextSize=size,Gravity=GravityFlags.CenterVertical};t.SetTextColor(c);if(bold)t.SetTypeface(Typeface.Default,TypefaceStyle.Bold);return t;}
    private TextView Button(string s,Action a)
    {
        var b=Label(s,10,Color.Rgb(225,234,246),true);var bg=new Android.Graphics.Drawables.GradientDrawable();
        bg.SetColor(Color.Transparent);bg.SetCornerRadius(Dp(6));bg.SetStroke(Dp(1),Color.Rgb(73,111,159));
        b.Background=bg;b.Gravity=GravityFlags.Center;b.Clickable=true;b.SetPadding(Dp(9),0,Dp(9),0);b.Click+=(_,_)=>a();return b;
    }
    private LinearLayout.LayoutParams Wrap()=>new(ViewGroup.LayoutParams.WrapContent,Dp(36)){RightMargin=Dp(4)};
}

internal sealed class ModelPreview:View
{
    private readonly Paint _p=new(){AntiAlias=true,StrokeWidth=2};
    private readonly Func<ModelMesh?> _mesh;
    private float _yaw=35,_lastX;
    public ModelPreview(Android.Content.Context c,Func<ModelMesh?> mesh):base(c){_mesh=mesh;SetBackgroundColor(Color.Rgb(35,43,55));}
    protected override void OnDraw(Canvas c)
    {
        base.OnDraw(c);var m=_mesh();var cx=Width*.5f;var cy=Height*.52f;
        _p.Color=Color.Rgb(57,70,87);_p.StrokeWidth=1;
        for(int i=-8;i<=8;i++){c.DrawLine(cx+i*Dp(24),0,cx+i*Dp(24),Height,_p);c.DrawLine(0,cy+i*Dp(24),Width,cy+i*Dp(24),_p);}
        if(m is null){_p.Color=Color.White;c.DrawText("Add a primitive to begin",Dp(18),Dp(28),_p);return;}
        _p.Color=Color.Rgb(104,176,255);_p.StrokeWidth=2.5f;
        for(var i=0;i<m.Triangles.Count;i+=3)
        {
            var a=Project(m.Vertices[m.Triangles[i]],m,cx,cy);var b=Project(m.Vertices[m.Triangles[i+1]],m,cx,cy);var d=Project(m.Vertices[m.Triangles[i+2]],m,cx,cy);
            c.DrawLine(a.X,a.Y,b.X,b.Y,_p);c.DrawLine(b.X,b.Y,d.X,d.Y,_p);c.DrawLine(d.X,d.Y,a.X,a.Y,_p);
        }
        _p.Color=Color.White;_p.TextSize=Dp(13);c.DrawText(m.Name+" • "+m.Vertices.Count+" vertices",Dp(12),Dp(22),_p);
        _p.TextSize=Dp(10);c.DrawText("Drag horizontally to orbit preview",Dp(12),Height-Dp(14),_p);
    }
    private PointF Project(System.Numerics.Vector3 v,ModelMesh m,float cx,float cy)
    {
        var angle=(_yaw+m.Rotation.Y)*MathF.PI/180;var x=v.X*m.Scale.X;var z=v.Z*m.Scale.Z;var y=v.Y*m.Scale.Y;
        var rx=x*MathF.Cos(angle)-z*MathF.Sin(angle);var rz=x*MathF.Sin(angle)+z*MathF.Cos(angle);
        var scale=Math.Min(Width,Height)*.34f;return new PointF(cx+(rx-rz)*scale,cy-(y+(rx+rz)*.38f)*scale);
    }
    private int Dp(float n)=>(int)(n*Resources!.DisplayMetrics!.Density+.5f);
    public override bool OnTouchEvent(MotionEvent? e)
    {
        if(e is null)return false;
        if(e.Action==MotionEventActions.Down){_lastX=e.GetX();return true;}
        if(e.Action==MotionEventActions.Move){_yaw+=(e.GetX()-_lastX)*.5f;_lastX=e.GetX();Invalidate();return true;}
        return true;
    }
}
