using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightGuyGate8.FileSystem
{
    public class Folder
    {
        #region Private fields
        private string _folderName;
        private List<File> _files;
        private List<Folder> _folders;
        private Folder _parentFolder;
        private DateTime _lastModified;
        #endregion

        #region Properties
        public string FolderName { get { return _folderName; } }
        public Folder ParentFolder
        {
            get { return _parentFolder; }
            set { _parentFolder = value; }
        }
        public string FullPath
        {
            get { return GetFullPath(null, this); }
        }
        public DateTime LastModified { get { return _lastModified; } }
        public int FolderSize
        {
            get { return GetFolderSize(); }
        }
        #endregion

        #region Methods
        public void AddFolder(Folder folder)
        {
            if (_folders == null)
            {
                _folders = new List<Folder>();
            }
            folder.ParentFolder = this;
            _folders.Add(folder);
            _lastModified = DateTime.Now;
        }
        public void AddFile(File file)
        {
            if (_files == null)
            {
                _files = new List<File>();
            }
            file.ParentFolder = this;
            _files.Add(file);
            _lastModified = DateTime.Now;
        }
        public void RemoveFolder(string folderName)
        {
            for (int i = 0; i < _folders.Count; i++)
            {
                if (_folders[i].FolderName == folderName)
                {
                    _folders.Remove(_folders[i]);
                    break;
                }
            }
            _lastModified = DateTime.Now;
        }
        public void RemoveFile(string fileName)
        {
            for (int i = 0; i < _folders.Count; i++)
            {
                if (_files[i].FileName == fileName)
                {
                    _files.Remove(_files[i]);
                    break;
                }
            }
            _lastModified = DateTime.Now;
        }
        public void MoveFolder(Folder folder)
        {
            _parentFolder = folder;
            _lastModified = DateTime.Now;
        }
        private string GetFullPath(Stack<string> pathCombiner, Folder folder)
        {
            if (pathCombiner == null)
            {
                pathCombiner = new Stack<string>();
            }
            string item = folder._folderName + @"/";
            pathCombiner.Push(item);

            if (folder._parentFolder == null)
            {
                StringBuilder sb = new StringBuilder();
                while (pathCombiner.Count != 0)
                {
                    sb.Append(pathCombiner.Pop());
                }
                return sb.ToString();
            }
            else return GetFullPath(pathCombiner, folder.ParentFolder);
        }
        
        //private int GetFolderSize(Folder folder, int startSize = 0)
        //{
        //    startSize = folder._files.Sum(p => p.FileSize);

        //    if (folder._folders != null)
        //    {
        //        foreach (var item in folder._folders)
        //        {
        //            return GetFolderSize(item, startSize);
        //        }
        //    }
        //    return startSize;
        //}

        private int GetFolderSize()
        {
            int size = 0;
            if (this._folders != null)
            {
                for (int i = 0; i < _folders.Count; i++)
                {
                    size += _folders[i].GetFolderSize();
                }
            }
            if (this._files != null)
            {
                for (int i = 0; i < _files.Count; i++)
                {
                    size += _files[i].FileSize;
                }
            }
            return size;
        }
        #endregion

        #region Constructors
        public Folder(string folderName)
        {
            _folderName = folderName;
        }
        public Folder()
        {

        }
        #endregion
    }
}
