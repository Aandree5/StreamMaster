﻿using System.Text.Json;

namespace StreamMaster.Domain.Models;

public class M3UFile : AutoUpdateEntity
{
    public static string APIName => "M3UFiles";

    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public void WriteJSON()
    {
        string jsonPath = Path.Combine(FileDefinitions.M3U.DirectoryLocation, Source + ".json");
        string jsonString = JsonSerializer.Serialize(this, jsonSerializerOptions);
        File.WriteAllText(jsonPath, jsonString);
    }

    public M3UFile()
    {
        DirectoryLocation = FileDefinitions.M3U.DirectoryLocation;
        FileExtension = FileDefinitions.M3U.DefaultExtension;
        SMFileType = FileDefinitions.M3U.SMFileType;
    }

    public M3UKey M3UKey { get; set; } = M3UKey.URL;
    public M3UField M3UName { get; set; } = M3UField.Name;
    public List<string> VODTags { get; set; } = [];
    public string? M3U8OutPutProfile { get; set; }
    public int MaxStreamCount { get; set; }
    public int StreamCount { get; set; }
    public bool SyncChannels { get; set; }
    public int StartingChannelNumber { get; set; } = 1;
    public bool AutoSetChannelNumbers { get; set; } = true;

    //public string? DefaultGroup { get; set; }
    public string? DefaultStreamGroupName { get; set; }

    public M3UFile? ReadJSON()
    {
        string jsonPath = Path.Combine(FileDefinitions.M3U.DirectoryLocation, Source + ".json");

        if (!File.Exists(jsonPath))
        {
            return null;
        }
        string jsonString = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<M3UFile>(jsonString);
    }

    public static M3UFile? ReadJSON(FileInfo fileInfo)
    {
        if (fileInfo.DirectoryName == null)
        {
            return null;
        }
        string filePath = Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(fileInfo.FullName) + ".json");

        if (!File.Exists(filePath))
        {
            return null;
        }
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<M3UFile>(jsonString);
    }
}