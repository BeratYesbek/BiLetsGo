using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Storage
{
    public class StorageHelper : IFileHelper
    {
        private readonly string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private readonly string _folderName = "Files";

        public StorageHelper(string folderName)
        {
            _folderName = $"\\{folderName}\\"; ;

        }

        public IResult Upload(IFormFile file)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var randomName = Guid.NewGuid().ToString();
            var type = Path.GetExtension(file.FileName);
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Update(IFormFile file, string filePath, string publicId = default)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();

            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Delete(string filePath, string publicId = default)
        {
            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            return new SuccessResult();
        }

        public async Task<IResult> UploadAsync(IFormFile file)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var randomName = Guid.NewGuid().ToString();
            var type = Path.GetExtension(file.FileName);
            CheckDirectoryExists(_currentDirectory + _folderName);
            await CreateFileAsync(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public async Task<IResult> UpdateAsync(IFormFile file, string filePath, string publicId = default)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();

            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            await CreateFileAsync(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public Task<IResult> DeleteAsync(string filePath, string publicId = default)
        {
            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            return Task.FromResult<IResult>(new SuccessResult());
        }

        private static async Task CreateFileAsync(string directory, IFormFile file)
        {
            using FileStream fileStream = File.Create(directory);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
        }

        private static void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        private static void CreateFile(string directory, IFormFile file)
        {
            using FileStream fileStream = File.Create(directory);
            file.CopyTo(fileStream);
            fileStream.Flush();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists((directory)))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
