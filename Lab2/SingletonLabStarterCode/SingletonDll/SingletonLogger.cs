using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace SingletonDll
{
    public class SingletonLogger
    {
        private static SingletonLogger instance;
        private static readonly object instanceLock = new object();
        private StreamWriter streamWriter;
        private object streamSync = new object();

        private SingletonLogger(string logFile)
        {
            streamWriter = new StreamWriter(File.Create(logFile));
        }
        public static SingletonLogger GetInstance(string logFile)
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new SingletonLogger(logFile);
                }
            }
            return instance;
        }

        public void LogMsg(string msg)
        {
            lock (streamSync)
            {
                streamWriter.WriteLine("{0}  {1}", DateTime.Now, msg);
                streamWriter.Flush();
                Thread.Sleep(10);
            }
        }

        public void Close()
        {
            streamWriter.Close();
        }

    }
}
