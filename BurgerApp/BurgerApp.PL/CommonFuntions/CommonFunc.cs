using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BurgerApp.PL.CommonFunctions
{
    public static class CommonFunc
    {
        public static byte[] ImageToArray(IFormFile file)
        {
            if (file is not null)
            {
                using (var sm = new MemoryStream())
                {
                    file.CopyTo(sm);
                    return sm.ToArray();
                }
            }
            throw new Exception("Dosya bos gonderildi");
        }
        public static IFormFile ArrayToImage(byte[] file)
        {
            var stream = new MemoryStream(file);
            var FormFile = new FormFile(stream, 0, file.Length, "image", "image.jpg");

            return FormFile;
        }
        public static Dictionary<string, List<string>> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
            );
        }
    }
}
