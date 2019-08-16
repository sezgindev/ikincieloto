﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikincieloto
{
    public class FileUpload
    {
        public static string FileName(HttpPostedFileBase file)
        {
            string dosyaAdi = "no_image";
            string uzanti = ".jpg";
            if (file != null)
            {
                dosyaAdi = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
                uzanti = System.IO.Path.GetExtension(file.FileName);

                int count = 0;
                string path = System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/UploadImages"), $"{dosyaAdi}{uzanti}");

                while (System.IO.File.Exists(path))
                {
                    count++;
                    dosyaAdi = $"{System.IO.Path.GetFileNameWithoutExtension(file.FileName)}({count.ToString()})";
                    path = System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/UploadImages"), $"{dosyaAdi}{uzanti}");
                }

                file.SaveAs(path);
            }
            return $"{dosyaAdi}{uzanti}";
        }
    }
}