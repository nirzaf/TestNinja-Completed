﻿using System.Net;

namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            WebClient client = new WebClient();
            client.DownloadFile(url, path);            
        }
    }
}