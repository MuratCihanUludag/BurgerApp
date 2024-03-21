namespace BurgerApp.PL.Areas.Admin.Models.MenuViewModel
{
    public class ExtraMaterialViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
    }
}
