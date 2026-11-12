using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using ForgeMobile.Editor;
using ForgeMobile.Engine;
using ForgeMobile.Services;

namespace ForgeMobile;

[Activity(Label = "Forge Mobile", MainLauncher = true, Theme = "@android:style/Theme.Material.NoActionBar",
    ScreenOrientation = ScreenOrientation.Landscape,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.KeyboardHidden)]
public sealed class MainActivity : Activity
{
    private readonly Color _bg = Color.Rgb(16, 20, 28);
    private readonly Color _panel = Color.Rgb(27, 33, 44);
    private readonly Color _panel2 = Color.Rgb(35, 43, 56);
    private readonly Color _text = Color.Rgb(232, 238, 247);
    private readonly Color _muted = Color.Rgb(150, 164, 184);
    private ProjectStore _store = null!;
    private SceneDocument _scene = null!;
    private SceneDocument? _playSnapshot;
    private string _selectedId = "";
    private string _mode = "EDIT";
    private string _activeDock = "PROJECT";
    private LinearLayout _hierarchyList = null!;
    private LinearLayout _inspector = null!;
    private LinearLayout _dockContent = null!;
    private TextView _playButton = null!;
    private SceneViewport _viewport = null!;
    private EditText _scriptEditor = null!;
    private EditText _scriptName = null!;
    private readonly List<string> _logs = new();

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Window?.SetStatusBarColor(Color.Rgb(12, 15, 21));
        Window?.SetNavigationBarColor(Color.Rgb(12, 15, 21));
        _store = new ProjectStore(FilesDir!.AbsolutePath);
        _store.EnsureProject();
        _scene = _store.LoadScene();
        _selectedId = _scene.Objects.LastOrDefault()?.Id ?? "";
        BuildEditor();
        Log("Forge Mobile editor initialized.");
        Log("Project: MyFirstGame");
    }

    private void BuildEditor()
    {
        var root = new LinearLayout(this) { Orientation = Orientation.Vertical };
        root.SetBackgroundColor(_bg);
        SetContentView(root);

        var header = new LinearLayout(this) { Orientation = Orientation.Horizontal };\n        header.SetGravity(GravityFlags.CenterVertical);
        header.SetPadding(Dp(12), Dp(5), Dp(8), Dp(5));
        header.SetBackgroundColor(Color.Rgb(12, 16, 23));
        header.AddView(Label("FORGE", 19, _text, true), new LinearLayout.LayoutParams(Dp(75), Dp(42)));
        header.AddView(Label("MOBILE / MyFirstGame", 11, _muted), new LinearLayout.LayoutParams(0, Dp(42), 1));
        header.AddView(Button("＋ CUBE", () => AddObject("Cube", "Mesh")), Wrap());
        header.AddView(Button("＋ EMPTY", () => AddObject("GameObject", "Empty")), Wrap());
        _playButton = Label("▶ PLAY", 11, _text, true);
        StyleButton(_playButton);
        _playButton.Click += (_, _) => TogglePlay();
        header.AddView(_playButton, Wrap());
        header.AddView(Button("Ⅱ PAUSE", TogglePause), Wrap());
        header.AddView(Button("▸ STEP", Step), Wrap());
        header.AddView(Button("SAVE", Save), Wrap());
        root.AddView(header, new LinearLayout.LayoutParams(-1, Dp(52)));

        var tools = new LinearLayout(this) { Orientation = Orientation.Horizontal };\n        tools.SetGravity(GravityFlags.CenterVertical);
        tools.SetPadding(Dp(8), Dp(3), Dp(8), Dp(3));
        tools.SetBackgroundColor(_panel);
        tools.AddView(Label("TOOLS", 10, _muted, true), Wrap());
        foreach (var tool in new[] { "SELECT", "MOVE", "ROTATE", "SCALE" })
            tools.AddView(Button(tool, () => Log(tool + " tool selected")), Wrap());
        tools.AddView(Button("DUPLICATE", DuplicateSelected), Wrap());
        tools.AddView(Button("DELETE", DeleteSelected), Wrap());
        root.AddView(tools, new LinearLayout.LayoutParams(-1, Dp(40)));

        var workspace = new LinearLayout(this) { Orientation = Orientation.Horizontal };
        root.AddView(workspace, new LinearLayout.LayoutParams(-1, 0, 1));

        var hierarchyPanel = Panel("HIERARCHY");
        _hierarchyList = new LinearLayout(this) { Orientation = Orientation.Vertical };
        var hierarchyScroll = new ScrollView(this);
        hierarchyScroll.AddView(_hierarchyList);
        hierarchyPanel.AddView(hierarchyScroll, new LinearLayout.LayoutParams(-1, 0, 1));
        workspace.AddView(hierarchyPanel, new LinearLayout.LayoutParams(Dp(160), -1));

        var center = new LinearLayout(this) { Orientation = Orientation.Vertical };
        var tabs = new LinearLayout(this) { Orientation = Orientation.Horizontal };
        tabs.SetBackgroundColor(Color.Rgb(21, 26, 35));
        tabs.AddView(Label("SCENE", 11, _text, true), new LinearLayout.LayoutParams(Dp(75), Dp(32)));
        tabs.AddView(Label("GAME", 11, _muted), new LinearLayout.LayoutParams(Dp(75), Dp(32)));
        center.AddView(tabs, new LinearLayout.LayoutParams(-1, Dp(32)));
        _viewport = new SceneViewport(this);
        _viewport.OnViewportTap = () => Log("Scene viewport focused");
        center.AddView(_viewport, new LinearLayout.LayoutParams(-1, 0, 1));
        workspace.AddView(center, new LinearLayout.LayoutParams(0, -1, 1));

        var inspectorPanel = Panel("INSPECTOR");
        _inspector = new LinearLayout(this) { Orientation = Orientation.Vertical };
        var inspectorScroll = new ScrollView(this);
        inspectorScroll.AddView(_inspector);
        inspectorPanel.AddView(inspectorScroll, new LinearLayout.LayoutParams(-1, 0, 1));
        workspace.AddView(inspectorPanel, new LinearLayout.LayoutParams(Dp(218), -1));

        var dock = new LinearLayout(this) { Orientation = Orientation.Vertical };
        dock.SetBackgroundColor(_panel);
        var dockTabs = new LinearLayout(this) { Orientation = Orientation.Horizontal };
        dockTabs.AddView(Button("PROJECT", () => ShowDock("PROJECT")), Wrap());
        dockTabs.AddView(Button("C# SCRIPTS", () => ShowDock("SCRIPTS")), Wrap());
        dockTabs.AddView(Button("CONSOLE", () => ShowDock("CONSOLE")), Wrap());
        dock.AddView(dockTabs, new LinearLayout.LayoutParams(-1, Dp(34)));
        _dockContent = new LinearLayout(this) { Orientation = Orientation.Vertical };
        dock.AddView(_dockContent, new LinearLayout.LayoutParams(-1, Dp(126)));
        root.AddView(dock, new LinearLayout.LayoutParams(-1, Dp(160)));

        RefreshHierarchy();
        RefreshInspector();
        ShowDock("PROJECT");
    }

    private LinearLayout Panel(string title)
    {
        var panel = new LinearLayout(this) { Orientation = Orientation.Vertical };
        panel.SetBackgroundColor(_panel);
        panel.AddView(Label(title, 10, _muted, true), new LinearLayout.LayoutParams(-1, Dp(32)));
        var line = new View(this);
        line.SetBackgroundColor(Color.Rgb(54, 64, 80));
        panel.AddView(line, new LinearLayout.LayoutParams(-1, Dp(1)));
        return panel;
    }

    private void RefreshHierarchy()
    {
        _hierarchyList.RemoveAllViews();
        foreach (var item in _scene.Objects)
        {
            var row = new LinearLayout(this) { Orientation = Orientation.Horizontal };\n            row.SetGravity(GravityFlags.CenterVertical);
            row.SetPadding(Dp(7), 0, Dp(3), 0);
            row.SetBackgroundColor(item.Id == _selectedId ? Color.Rgb(43, 68, 103) : _panel);
            row.AddView(Label(item.Type switch { "Camera" => "◉", "Light" => "☼", "Mesh" => "◇", _ => "□" }, 14, Color.Rgb(90, 165, 255)), new LinearLayout.LayoutParams(Dp(23), Dp(34)));
            row.AddView(Label(item.Name, 11, _text), new LinearLayout.LayoutParams(0, Dp(34), 1));
            row.Click += (_, _) => { _selectedId = item.Id; RefreshHierarchy(); RefreshInspector(); };
            _hierarchyList.AddView(row, new LinearLayout.LayoutParams(-1, Dp(34)));
        }
    }

    private void RefreshInspector()
    {
        _inspector.RemoveAllViews();
        var item = _scene.Find(_selectedId);
        if (item is null) { _inspector.AddView(Label("Select an object", 12, _muted)); return; }
        InspectorHeading("OBJECT");
        var name = new EditText(this) { Text = item.Name, TextSize = 12 };\n        name.SetSingleLine(true);
        name.SetTextColor(_text);
        name.SetPadding(Dp(7), 0, Dp(7), 0);
        name.SetBackgroundColor(_panel2);
        _inspector.AddView(name, new LinearLayout.LayoutParams(-1, Dp(39)));
        InspectorHeading("TRANSFORM / POSITION");
        var x = NumberField(item.Transform.X);
        var y = NumberField(item.Transform.Y);
        var z = NumberField(item.Transform.Z);
        AxisRow("X", x); AxisRow("Y", y); AxisRow("Z", z);
        _inspector.AddView(Button("APPLY CHANGES", () =>
        {
            item.Name = string.IsNullOrWhiteSpace(name.Text) ? "GameObject" : name.Text.Trim();
            item.Transform.X = Parse(x.Text, item.Transform.X);
            item.Transform.Y = Parse(y.Text, item.Transform.Y);
            item.Transform.Z = Parse(z.Text, item.Transform.Z);
            _viewport.SelectedName = item.Name;
            _viewport.Invalidate();
            RefreshHierarchy();
            Log("Inspector updated: " + item.Name);
        }), new LinearLayout.LayoutParams(-1, Dp(39)));
        InspectorHeading("COMPONENTS");
        foreach (var component in item.Components)
            _inspector.AddView(Label("  ◈  " + component, 11, _muted), new LinearLayout.LayoutParams(-1, Dp(27)));
        _inspector.AddView(Button("+ ADD COMPONENT", () =>
        {
            if (!item.Components.Contains("Behaviour")) item.Components.Add("Behaviour");
            RefreshInspector();
            Log("Added Behaviour component");
        }), new LinearLayout.LayoutParams(-1, Dp(37)));
    }

    private void InspectorHeading(string value)
    {
        var label = Label(value, 9, _muted, true);
        label.SetPadding(Dp(6), Dp(5), 0, 0);
        _inspector.AddView(label, new LinearLayout.LayoutParams(-1, Dp(27)));
    }

    private EditText NumberField(float value)
    {
        var field = new EditText(this) { Text = value.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.NumberFlagSigned, TextSize = 11 };
        field.SetSingleLine(true);\n        field.SetTextColor(_text);
        field.SetBackgroundColor(_panel2);
        field.SetPadding(Dp(5), 0, Dp(3), 0);
        return field;
    }

    private void AxisRow(string axis, EditText field)
    {
        var row = new LinearLayout(this) { Orientation = Orientation.Horizontal, Gravity = GravityFlags.CenterVertical };
        row.AddView(Label(axis, 11, _muted, true), new LinearLayout.LayoutParams(Dp(22), Dp(34)));
        row.AddView(field, new LinearLayout.LayoutParams(0, Dp(34), 1));
        _inspector.AddView(row, new LinearLayout.LayoutParams(-1, Dp(37)));
    }

    private void ShowDock(string tab)
    {
        _activeDock = tab;
        _dockContent.RemoveAllViews();
        if (tab == "PROJECT")
        {
            var folders = new LinearLayout(this) { Orientation = Orientation.Horizontal };
            foreach (var folder in new[] { "Scenes", "Scripts", "Assets", "Native" })
                folders.AddView(Label("▣ " + folder, 11, _text), new LinearLayout.LayoutParams(0, Dp(40), 1));
            _dockContent.AddView(folders);
            _dockContent.AddView(Label("MyFirstGame  /  " + string.Join("   ", _store.ListScripts()), 10, _muted));
        }
        else if (tab == "SCRIPTS")
        {
            var top = new LinearLayout(this) { Orientation = Orientation.Horizontal };
            _scriptName = new EditText(this) { Text = "SpinBehaviour", TextSize = 11 };\n            _scriptName.SetSingleLine(true);
            _scriptName.SetTextColor(_text);
            top.AddView(_scriptName, new LinearLayout.LayoutParams(Dp(155), Dp(36)));
            top.AddView(Button("SAVE .CS", SaveScript), Wrap());
            _dockContent.AddView(top);
            _scriptEditor = new EditText(this) { Text = ProjectStore.StarterScript, Gravity = GravityFlags.Top | GravityFlags.Left, TextSize = 10, Typeface = Typeface.Monospace };
            _scriptEditor.SetTextColor(_text);
            _scriptEditor.SetBackgroundColor(Color.Rgb(18, 23, 31));
            _scriptEditor.SetPadding(Dp(7), Dp(4), Dp(7), Dp(4));
            _dockContent.AddView(_scriptEditor, new LinearLayout.LayoutParams(-1, 0, 1));
        }
        else
        {
            var scroll = new ScrollView(this);
            var log = Label(string.Join("\n", _logs.TakeLast(25)), 10, _muted);
            log.SetTypeface(Typeface.Monospace, TypefaceStyle.Normal);
            log.SetPadding(Dp(7), Dp(2), 0, Dp(2));
            scroll.AddView(log);
            _dockContent.AddView(scroll, new LinearLayout.LayoutParams(-1, -1));
        }
    }

    private void AddObject(string name, string type)
    {
        if (_mode == "PLAY") { Log("Stop Play Mode before editing"); return; }
        var item = _scene.Add(name, type);
        _selectedId = item.Id;
        _viewport.SelectedName = item.Name;
        _viewport.Invalidate();
        RefreshHierarchy(); RefreshInspector();
        Log("Created " + name);
    }

    private void DuplicateSelected()
    {
        if (_mode == "PLAY") return;
        var item = _scene.Find(_selectedId);
        if (item is null) return;
        var copy = item.Clone();
        _scene.Objects.Add(copy);
        _selectedId = copy.Id;
        RefreshHierarchy(); RefreshInspector();
        Log("Duplicated " + item.Name);
    }

    private void DeleteSelected()
    {
        if (_mode == "PLAY") return;
        var item = _scene.Find(_selectedId);
        if (item is null) return;
        _scene.Remove(_selectedId);
        _selectedId = _scene.Objects.LastOrDefault()?.Id ?? "";
        RefreshHierarchy(); RefreshInspector();
        Log("Deleted " + item.Name);
    }

    private void TogglePlay()
    {
        if (_mode == "PLAY" || _mode == "PAUSED")
        {
            if (_playSnapshot is not null) _scene = _playSnapshot;
            _playSnapshot = null;
            _mode = "EDIT";
            _playButton.Text = "▶ PLAY";
            Log("Play Mode stopped; edit scene restored.");
        }
        else
        {
            _playSnapshot = System.Text.Json.JsonSerializer.Deserialize<SceneDocument>(System.Text.Json.JsonSerializer.Serialize(_scene));
            _mode = "PLAY";
            _playButton.Text = "■ STOP";
            Log("Play Mode started (runtime loop is a future milestone).");
        }
        RefreshHierarchy(); RefreshInspector();
    }

    private void TogglePause()
    {
        if (_mode == "EDIT") { Log("Start Play Mode first"); return; }
        _mode = _mode == "PAUSED" ? "PLAY" : "PAUSED";
        Log(_mode == "PAUSED" ? "Play Mode paused." : "Play Mode resumed.");
    }

    private void Step() => Log(_mode == "EDIT" ? "Start Play Mode before stepping" : "Simulation step requested.");

    private void Save()
    {
        _store.SaveScene(_scene);
        Log("Scene saved to local project storage.");
    }

    private void SaveScript()
    {
        var path = _store.SaveScript(_scriptName?.Text ?? "NewScript", _scriptEditor?.Text ?? ProjectStore.StarterScript);
        Log("Saved C# source: " + System.IO.Path.GetFileName(path));
    }

    private void Log(string message)
    {
        _logs.Add(DateTime.Now.ToString("HH:mm:ss") + "  " + message);
        if (_logs.Count > 200) _logs.RemoveAt(0);
        if (_activeDock == "CONSOLE") ShowDock("CONSOLE");
    }

    private TextView Label(string value, float size, int color, bool bold = false)
    {
        var view = new TextView(this) { Text = value, TextSize = size, Gravity = GravityFlags.CenterVertical };
        view.SetTextColor(color);
        if (bold) view.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
        return view;
    }

    private TextView Button(string title, Action action)
    {
        var button = Label(title, 9, _text, true);
        StyleButton(button);
        button.Click += (_, _) => action();
        return button;
    }

    private void StyleButton(TextView button)
    {
        var shape = new GradientDrawable();
        shape.SetColor(Color.Transparent);
        shape.SetCornerRadius(Dp(7));
        shape.SetStroke(Dp(1), Color.Rgb(78, 105, 143));
        button.Background = shape;
        button.SetPadding(Dp(8), 0, Dp(8), 0);
        button.Gravity = GravityFlags.Center;
        button.Clickable = true;
        button.Focusable = true;
        button.Elevation = Dp(1);
    }

    private LinearLayout.LayoutParams Wrap() => new(ViewGroup.LayoutParams.WrapContent, Dp(34)) { RightMargin = Dp(4) };
    private int Dp(float value) => (int)(value * Resources!.DisplayMetrics!.Density + .5f);
    private static float Parse(string? value, float fallback) =>
        float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var parsed) ? parsed : fallback;

    public override void OnBackPressed()
    {
        if (_mode != "EDIT") TogglePlay();
        else { Save(); base.OnBackPressed(); }
    }
}
