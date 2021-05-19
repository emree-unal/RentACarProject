using Microsoft.AspNetCore.Http;
using ReCapProject.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReCapProject.Core.Utilities.Helpers
{
    public class FileHelper
    {

        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, result.newPath);
            return result.Path2;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file).ToString();
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return (result, @"\\Images\\" + newPath);
        }

        //public static string Add(IFormFile file)
        //{
        //    string extension = Path.GetExtension(file.FileName).ToUpper();
        //    string newGuıd = CreateGuid() + extension;
        //    var directory = Directory.GetCurrentDirectory() + "\\wwwroot";
        //    var path = directory + @"\Images";
        //    var webpath = "/Images/" + newGuıd;
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    string imagePath;
        //    using (FileStream fileStream = File.Create(path + "\\" + newGuıd))
        //    {
        //        file.CopyTo(fileStream);
        //        imagePath = path + "\\" + newGuıd;
        //        fileStream.Flush();
        //    }
        //    return webpath;
        //}
        //public static void Update(IFormFile file, string OldPath)
        //{
        //    string extension = Path.GetExtension(file.FileName).ToUpper();
        //    using (FileStream fileStream = File.Open(OldPath.Replace("/", "\\"), FileMode.Open))
        //    {
        //        file.CopyToAsync(fileStream);
        //        fileStream.Flush();
        //    }
        //}
        //public static void Delete(string ImagePath)
        //{
        //    if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "EmptyImage.jpg")
        //    {
        //        File.Delete(ImagePath.Replace("/", "\\"));
        //    }
        //}

        //private static string CreateGuid()
        //{
        //    return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        //}
    }

}


