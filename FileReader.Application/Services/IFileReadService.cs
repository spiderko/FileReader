namespace FileReader.Application.Services
{
    public interface IFileReadService
    {
        string[] ReadAllLines(string fileLocation);
    }
}