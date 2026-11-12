namespace ForgeMobile.Engine.Scene;

public sealed class SceneValidator
{

    public static ValidationResult Validate(SceneGraph graph) { var result = new ValidationResult(); var ids = new HashSet<string>(); foreach (var entity in graph.Entities) { if (!ids.Add(entity.Id)) result.Add($"Duplicate entity ID: {entity.Id}"); if (string.IsNullOrWhiteSpace(entity.Name)) result.Add($"Entity {entity.Id} has no name"); if (!string.IsNullOrEmpty(entity.ParentId) && graph.Find(entity.ParentId) is null) result.Add($"Missing parent {entity.ParentId}"); } return result; }
}
