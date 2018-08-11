using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightGuyGate8.FileSystem
{
    public class LogicalDisk
    {
        #region Private fields
        private char _diskLabel;
        private int _diskTotalSize;
        private List<Folder> _folders;
        private DateTime _lastModified;
        #endregion

        #region Properties
        public char DiskLabel { get { return _diskLabel; } }
        public int DiskTotalSize { get { return _diskTotalSize; } }
        public DateTime LastModified { get { return _lastModified; } }
        public int FreeSpace { get { return CalculateFreeSpace(); } }
        #endregion


        #region Methods
        private int CalculateFreeSpace()
        {
            int AllFoldersSize = 0;
            foreach (var item in _folders)
            {
                AllFoldersSize += item.FolderSize;
            }
            return DiskTotalSize - AllFoldersSize;
        }

        public void AddFolder(Folder folder)
        {
            folder.ParentFolder = null;
            _folders.Add(folder);
        }
        #endregion

        #region Constructors
        public LogicalDisk(char disklabel, int diskTotalSize)
        {
            _diskLabel = disklabel;
            _diskTotalSize = diskTotalSize;
        }
        #endregion
    }
}
