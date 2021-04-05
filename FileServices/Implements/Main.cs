using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace testC01.FileServices.Implements
{
    public class Main:IMain
    {
        private readonly IFileHandle _fileHandle;
        private readonly IUtilHandle _utilHandle;
        private readonly IConfiguration _config;
        private DateTime startTime;
        private DateTime stopTime;
        public Main(IFileHandle fileHandle , IUtilHandle utilHandle, IConfiguration config)
        {
            _fileHandle = fileHandle;
            _utilHandle = utilHandle;
            _config = config;
        }
        public void Run()
        {
            startTime = DateTime.Now;
            var allLines = _fileHandle.GetAllLineOfFIleInputFoder(_config["Folder"], _config["Filter"]);
            allLines = _utilHandle.Sort(allLines);
            _fileHandle.WriteToNewFile(_config["FileOutput"] ,allLines);
            stopTime = DateTime.Now;
            _fileHandle.WriteTimeToFile(startTime, stopTime, _config["FileLog"]);
        }
    }
}
