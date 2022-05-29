
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Utilities.IoC;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Cloud.Cloudinary
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;
        private IConfiguration Configuration { get; set; }
        public CloudinaryService()
        {
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            CloudinaryOptions options = Configuration.GetSection("CloudinaryOptions").Get<CloudinaryOptions>();
            var account = new Account(options.Cloud, options.ApiKey, options.ApiSecret);

            _cloudinary = new CloudinaryDotNet.Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public IResult Upload(IFormFile file)
        {
            ImageUploadResult imageUploadResult = null;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            imageUploadResult = _cloudinary.Upload(uploadParams);


            return new SuccessResult($"{imageUploadResult.SecureUrl}&&{imageUploadResult.PublicId}");
        }

        public IResult Delete(string filePath, string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            _cloudinary.Destroy(deletionParams);
            return new SuccessResult();
        }

        public async Task<IResult> UploadAsync(IFormFile file)
        {
            ImageUploadResult imageUploadResult = null;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            imageUploadResult = await _cloudinary.UploadAsync(uploadParams);


            return new SuccessResult($"{imageUploadResult.SecureUrl}&&{imageUploadResult.PublicId}");
        }

        public async Task<IResult> UpdateAsync(IFormFile file, string filePath, string publicId = default)
        {
            var result = Delete(null, publicId);
            if (result.Success)
            {
                var addedDelete = await UploadAsync(file);
                if (addedDelete.Success)
                {
                    return new SuccessResult(addedDelete.Message);
                }

                return new ErrorResult(addedDelete.Message);
            }
            return new ErrorResult(result.Message);
        }

        public async Task<IResult> DeleteAsync(string filePath, string publicId = default)
        {
            var deletionParams = new DeletionParams(publicId);
            await _cloudinary.DestroyAsync(deletionParams);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, string filePath, string publicId)
        {
            var result = Delete(null, publicId);
            if (result.Success)
            {
                var addedDelete = Upload(file);
                if (addedDelete.Success)
                {
                    return new SuccessResult(addedDelete.Message);
                }

                return new ErrorResult(addedDelete.Message);
            }

            return new ErrorResult(result.Message);
        }




    }

}