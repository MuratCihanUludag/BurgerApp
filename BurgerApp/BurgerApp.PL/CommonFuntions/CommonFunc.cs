using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BurgerApp.PL.CommonFunctions
{
    public static class CommonFunc
    {
        public static async Task<byte[]> ImageToArray(IFormFile file)
        {
            if (file is not null)
            {
                using (var sm = new MemoryStream())
                {
                    await file.CopyToAsync(sm);
                    return sm.ToArray();
                }
            }
            throw new Exception("Dosya bos gonderildi");
        }
        public static async Task<IFormFile> ArrayToImage(byte[] file)
        {
            var stream = new MemoryStream(file);
            var FormFile = new FormFile(stream, 0, file.Length, "image", "image.jpg");

            return FormFile;
        }

    }
}
