using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Common.Models
{
    public class FileData
    {
        public String name;
        public String contents;
        public String sha;
    }
    public class Directory
    {
        public String name;
        public List<Directory> subDirs;
        public List<FileData> files;
    }
}
