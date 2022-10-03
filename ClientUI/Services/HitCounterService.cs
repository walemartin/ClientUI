using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientUI.Services
{
    public class HitCounterService : IHitCounterService
    {
        private string _rootPath;
        public HitCounterService(string rootPath)
        {
            _rootPath = rootPath;
        }
        public int UpdateCount()
        {
            var hitCountFilePath = "\\Services\\hitcount.txt";
            var fullPath = string.Concat(_rootPath, hitCountFilePath);
            var count = int.Parse(File.ReadAllText(fullPath));
            count++;
            File.WriteAllText(fullPath, count.ToString());
            return count;
        }
    }
    public interface IHitCounterService
    {
        int UpdateCount();
    }
}
