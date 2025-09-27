namespace SGA.Application.Interfaces;
public interface IFileStorage
{
    Task<string> SaveAsync(Stream content, string fileName, string contentType);
    Task<Stream?> GetAsync(string path);
    Task DeleteAsync(string path);
}
