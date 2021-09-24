using FileReader.Core.Models;

namespace FileReader.Application.Common
{
    public interface IRainFallHeaderRepository
    {
        void Insert(RainFallHeader data);
    }
}