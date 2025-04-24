using System.Collections.Generic;
using System.IO;

namespace Tools.ProjectTreeGenerator.Editor
{
    public class Folder
    {
        public string DirPath { get; private set; }
        public string ParentPath { get; private set; }
        public string Name;
        public List<Folder> Subfolders;

        public Folder Add(string name)
        {
            Folder subfolder = null;
            if (ParentPath.Length > 0)
                subfolder = new Folder(name, ParentPath + Path.DirectorySeparatorChar + Name);
            else
                subfolder = new Folder(name, Name);

            Subfolders.Add(subfolder);
            return subfolder;
        }

        public Folder(string name, string dirPath)
        {
            Name = name;
            ParentPath = dirPath;
            DirPath = ParentPath + Path.DirectorySeparatorChar + Name;
            Subfolders = new List<Folder>();
        }
    }
}
