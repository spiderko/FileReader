using System.Collections.Generic;
using System.Linq;

namespace FileReader.Core.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<string> RemoveEmpties(this string[] array)
        {
            return array.Where(a => !string.IsNullOrEmpty(a)).ToArray();
        }
    }
}
