using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class Photo
    {
        public string FileName;
        public string URL;
        
        public Photo(string fileName, string URL)
        {
            this.FileName = fileName;
            this.URL = URL;
        }
    }
}