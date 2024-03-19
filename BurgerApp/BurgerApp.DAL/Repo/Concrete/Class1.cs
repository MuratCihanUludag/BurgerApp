using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DAL.Repo.Concrete
{
    internal class Class1
    {
    }
    public class Promosyon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fiyat {  get; set; } 
        public SiparisPromosyon siparis { get; set; }

    }

    public class Siparis
    {
        public int Id { get; set; }
        public SiparisPromosyon promosyonlars { get; set; }   
    }

    public class SiparisPromosyon
    {
        public int Id { get; set; }
        public List<Promosyon> promosyons { get; set;}
        public List<Siparis> sips { get; set;}
    }
}
