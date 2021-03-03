﻿using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static IResult WriteFile(IFormFile formFile, string path)
        {
            var result = FileNameCreator(formFile, path);
            var fullPath = Path.Combine(path, result.fileName);

            try
            {
                var sourcePath = Path.GetTempFileName();
                if (formFile.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        formFile.CopyTo(stream);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.Move(sourcePath, fullPath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult(result.pathToSave);
        }

        public static string UpdateFile(string sourcePath, IFormFile formFile, string path)
        {
            var result = FileNameCreator(formFile, path);

            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.pathToSave, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result.pathToSave;
        }

        public static IResult DeleteFile(string path)
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

        static string GetFileExtension(IFormFile formFile)
        {
            return new FileInfo(formFile.FileName).Extension;
        }

        static (string fileName, string pathToSave) FileNameCreator(IFormFile formFile, string path)
        {
            var fileName = Guid.NewGuid().ToString() + GetFileExtension(formFile);
            var pathToSave = Path.Combine(Path.DirectorySeparatorChar.ToString(),
                path.Split(Path.DirectorySeparatorChar).Last(), fileName);
            return (fileName, pathToSave);
        }
    }
}
