namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptParser
{
    public static ScriptProgram Parse(string source)
    {
        var program = new ScriptProgram();
        var lines = source.Split(new[] { (char)10 }, StringSplitOptions.None);
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (line.Length == 0 || line.StartsWith("//", StringComparison.Ordinal)) continue;
            var open = line.IndexOf('(');
            var close = line.LastIndexOf(')');
            if (open < 1 || close < open) { program.Diagnostics.Add(new() { Line = i + 1, Message = "Expected command(argument);" }); continue; }
            var op = line[..open].Trim().ToLowerInvariant();
            var arg = line[(open + 1)..close].Trim().Trim('"');
            if (op == "log") program.Instructions.Add(new() { OpCode = "LOG", Operand = arg });
            else if (op == "set")
            {
                var parts = arg.Split(',');
                if (parts.Length == 2 && float.TryParse(parts[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var number))
                    program.Instructions.Add(new() { OpCode = "SET", Operand = parts[0].Trim(), Number = number });
                else program.Diagnostics.Add(new() { Line = i + 1, Message = "set expects set(name, number)" });
            }
            else if (op == "move")
            {
                if (float.TryParse(arg, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var amount))
                    program.Instructions.Add(new() { OpCode = "MOVE_Y", Number = amount });
                else program.Diagnostics.Add(new() { Line = i + 1, Message = "move expects a number" });
            }
            else program.Diagnostics.Add(new() { Line = i + 1, Message = $"Unsupported safe command '{op}'" });
        }
        return program;
    }
}
