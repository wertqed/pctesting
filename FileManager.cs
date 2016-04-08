using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.IO;

namespace pctetsting
{
    class FileManager
    {
        //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void initWatcher(FileSystemWatcher watcher)
        {
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.InternalBufferSize = 10000;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        public void watch(System.ComponentModel.ISynchronizeInvoke x)
        {
            string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string[] drives = Directory.GetLogicalDrives();
            string sysRoot = Path.GetPathRoot(system);
            FileSystemWatcher watcher;
            bool t = false;
            foreach (string driveStr in drives)
            {
                DriveInfo drive = new DriveInfo(driveStr);
                if (!drive.Name.Equals(sysRoot) && drive.DriveType == DriveType.Fixed && drive.IsReady)
                {
                    watcher = new FileSystemWatcher(@drive.Name, "*.*");
                    initWatcher(watcher);
                    t = true;
                }
            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            watcher = new FileSystemWatcher(@desktopPath, "*.*");
            initWatcher(watcher);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!e.Name.Contains("qwerty.txt"))
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter("qwerty.txt"))
                {
                    file.WriteLine(e.FullPath);
                    file.WriteLine(e.Name);
                    file.WriteLine(e.ChangeType);
                    file.WriteLine(DateTime.Now.ToString());
                }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"qwerty.txt"))
            {
                file.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            }
        }
    }
}
