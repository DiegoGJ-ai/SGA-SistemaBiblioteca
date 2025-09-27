using SGA.Application.Interfaces;

namespace SGA.Infrastructure.Files;
public class LocalFileStorage : IFileStorage
{
    private readonly string _root;

    public LocalFileStorage(string root = "uploads")
    {
        _root = Path.GetFullPath(root);
        Directory.CreateDirectory(_root);
    }

    public async Task<string> SaveAsync(Stream content, string fileName, string contentType)
    {
        var safeName = $"{Guid.NewGuid():N}_{Path.GetFileName(fileName)}";
        var full = Path.Combine(_root, safeName);
        using var fs = File.Create(full);
        await content.CopyToAsync(fs);
        return full; // o ruta relativa
    }

    public Task<Stream?> GetAsync(string path)
    {
        if (!File.Exists(path)) return Task.FromResult<Stream?>(null);
        return Task.FromResult<Stream?>(File.OpenRead(path));
    }

    public Task DeleteAsync(string path)
    {
        if (File.Exists(path)) File.Delete(path);
        return Task.CompletedTask;
    }
}
