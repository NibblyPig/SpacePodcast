using System.Text.Json;
using System.Text.Json.Serialization;
using PodcastUniverseEditor.Models;

namespace PodcastUniverseEditor.Services.Persistence;

/// <summary>
/// Handles loading, saving, and creating PodcastProject instances as
/// *.podcastworld.json files using System.Text.Json.
/// </summary>
public class ProjectFileService
{
    public const string FileExtension = ".podcastworld.json";
    public const string FileFilter = "Podcast World files (*.podcastworld.json)|*.podcastworld.json|All files (*.*)|*.*";

    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>
    /// Serialises the project to a JSON file at the given path.
    /// Updates ModifiedUtc before writing.
    /// </summary>
    public void Save(string filePath, PodcastProject project)
    {
        project.ModifiedUtc = DateTime.UtcNow;
        string json = JsonSerializer.Serialize(project, _serializerOptions);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Deserialises a project from a JSON file. Throws if the file cannot be parsed.
    /// Callers should handle IOException and JsonException.
    /// </summary>
    public PodcastProject Load(string filePath)
    {
        string json = File.ReadAllText(filePath);
        PodcastProject? project = JsonSerializer.Deserialize<PodcastProject>(json, _serializerOptions);
        return project ?? throw new InvalidDataException($"Failed to deserialise project from {filePath}");
    }

    /// <summary>
    /// Creates a blank, unsaved project with default metadata.
    /// </summary>
    public PodcastProject CreateNewProject()
    {
        return new PodcastProject
        {
            ProjectName = "New Podcast World",
            Description = string.Empty,
            CreatedUtc = DateTime.UtcNow,
            ModifiedUtc = DateTime.UtcNow,
            SchemaVersion = 1
        };
    }
}
