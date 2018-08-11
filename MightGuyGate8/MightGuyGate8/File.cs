using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightGuyGate8.FileSystem
{
    public class File
    {
        #region Private fields
        private string _fileName;
        private int _fileSize;
        private DateTime _lastModified;
        private Folder _parentFolder;
        #endregion

        #region Properties
        public string FileName { get { return _fileName; } }
        public int FileSize { get { return _fileSize; } }
        public DateTime LastModified { get { return _lastModified; } }
        public Folder ParentFolder
        {
            get { return _parentFolder; }
            set { _parentFolder = value; }
        }
        public string Extension => _fileName.Split('.').Last();
        public string FullPath { get { return ""; } }
        #endregion

        #region Methods
        public void MoveToFolder(Folder folder)
        {
            _parentFolder = folder;
            _lastModified = DateTime.Now;
        }
        private string GetFullPath()
        {
            return _parentFolder.FullPath + "\\" + _fileName;
        }
        #endregion

        #region Constructors
        public File(string fileName, int fileSize)
        {
            _fileName = fileName;
            _fileSize = fileSize;
        }
        public File()
        {

        }
        #endregion

    }
}
