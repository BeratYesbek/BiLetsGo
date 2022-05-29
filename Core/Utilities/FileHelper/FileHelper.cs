using Core.Utilities.Cloud.Cloudinary;
using Core.Utilities.Result;
using Core.Utilities.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public enum FileExtension
    {
        ImageExtension = 0,
        DocumentExtension = 1
    }

    public enum RecordType
    {
        Cloud = 0,
        Storage = 1
    }

    public enum FolderName
    {
        Files = 0,
        Images = 1,
        Documents = 2
    }

    public class FileHelper
    {
        private readonly IFileHelper _fileHelper;
        private string[] FileType { get; }

        public FileHelper(RecordType recordType, FileExtension fileExtension, FolderName folderName = default)
        {
            FileType = GetExtensions(fileExtension);

            if (recordType == RecordType.Cloud)
            {
                _fileHelper = new CloudinaryService();
            }
            else
            {
                _fileHelper = new StorageHelper(folderName.ToString());
            }
        }


        private static string[] GetExtensions(FileExtension fileExtension)
        {
            return fileExtension switch
            {
                FileExtension.DocumentExtension => FileExtensions.DocumentExtensions,
                FileExtension.ImageExtension => FileExtensions.ImageExtensions,
                _ => null
            };
        }

        public IResult CheckFileTypeValid(string type)
        {
            foreach (var extension in FileType)
            {
                if (extension == type)
                {
                    return new SuccessResult();
                }
            }

            return new ErrorResult("File type is not suitable");
        }



        /// <summary>
        ///    if this method success, message will return which contains file path
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns> error message or file path   </returns>
        public IResult Update(IFormFile file, string filePath, string publicId = null)
        {
            var result = CheckFileTypeValid(Path.GetExtension(file.FileName));
            if (result.Success)
            {
                return _fileHelper.Update(file, filePath, publicId);
            }

            return result;
        }

        public IResult Delete(string filePath, string publicId = null)
        {
            return _fileHelper.Delete(filePath, publicId);
        }

        /// <summary>
        /// 
        ///     if this method success, message will return which contains file path
        /// 
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns> error message or file path </returns>
        public IResult Upload(IFormFile file)
        {
            var result = CheckFileTypeValid(Path.GetExtension(file.FileName));
            if (result.Success)
            {
                return _fileHelper.Upload(file);
            }

            return result;
        }


        public async Task<IResult> DeleteAsync(string filePath, string publicId = null)
        {
            return await _fileHelper.DeleteAsync(filePath, publicId);
        }

        public async Task<IResult> UpdateAsync(IFormFile file, string filePath, string publicId = null)
        {
            var result = CheckFileTypeValid(Path.GetExtension(file.FileName));
            if (result.Success)
            {
                return await _fileHelper.UpdateAsync(file, filePath, publicId);
            }

            return result;
        }

        public async Task<IResult> UploadAsync(IFormFile file)
        {
            var result = CheckFileTypeValid(Path.GetExtension(file.FileName));
            if (result.Success)
            {
                return await _fileHelper.UploadAsync(file);
            }
            return result;
        }
    }
}
