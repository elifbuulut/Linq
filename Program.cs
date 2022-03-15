using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>()
            { new Category {CategoryID=1, CategoryName="Bilgisayar"},
              new Category {CategoryID=2, CategoryName="Telefon"}
            };
            //------------------------------------------------------------------
            //Product product = new Product();    
            //product.CategoryID = 1;
            //product.ProductName = "dsfsdsd0";
            //Product product2 = new Product();   
            //product2.CategoryID = 2;
            //product2.ProductName = "vdfvfv";
            //BU ŞEKİLDE YAPMAK YERİNE LİST'TEN YARARLANIYORUM!
            //------------------------------------------------------------------ 

            List<Product> products = new List<Product>()
            {
                new Product { ProductID=1,CategoryID=1,ProductName="Acer laptop",QuantityPerUnit="32GB RAM",UnitPrice=100000,UnitsInStok=5},
                new Product { ProductID=2,CategoryID=1,ProductName="Asus laptop",QuantityPerUnit="16GB RAM",UnitPrice=8000,UnitsInStok=3},
                new Product { ProductID=3,CategoryID=1,ProductName="HP laptop",QuantityPerUnit="8GB RAM",UnitPrice=6000,UnitsInStok=2},
                new Product { ProductID=4,CategoryID=2,ProductName="Samsung Telephone",QuantityPerUnit="4GB RAM",UnitPrice=000,UnitsInStok=15},
                new Product { ProductID=5,CategoryID=2,ProductName="Apple Telephone",QuantityPerUnit="4GB RAM",UnitPrice=000,UnitsInStok=0},
                //Bu veri kaynakları veri tabanından gelecek !Şimdilik boyle oldugunu varsayıyoruz 
            };

            //---------------ÜRÜNLERİ EKRANA YAZDIRMAK İSTEDİĞİMDE LINQ KULLANMADAN VS--- LINQ KULLANARAK                                     
            Console.WriteLine("Lınq Olmadan Algoritmik Yapı Ile Ekrana Yazdırma ");
            // product=> döngü gezerken alias(takma isim)
            foreach (var product in products)
            {
                // FİLTRELEME ŞARTIM; BİRİM FİYATI 5000 DEN  FAZLA STOK ADEDİ 3 DEN BÜYÜK OLAN ÜRÜNLERİ LİSTELE 
                if (product.UnitPrice > 5000 && product.UnitsInStok > 3)
                {
                    Console.WriteLine($"{product.ProductName}\n");

                }

            }

            Console.WriteLine("Lınq  Ile Ekrana Yazdırma ");
            GetProducts(products); 

        }

         static void GetProducts(List<Product> products)
        {
            // var result ==>>>List<Product> result   ;        tip=> var yerine List<Product> 
            //arka tarafta bir iterasyonm yani dongü çalışıyor. Burada ki p tıpkı foreachde ki gibi  product mantığında 
            //yani var product in products dediğimizde burda ki product döngü gezerken kullanması için alias tı. yani burda ki (p=>) p takma isim 
            // p => (lambda işareti) p için   ,   //KOŞULUM() => WHERE  , Enumerable oldugu için ToList(); convertini unutma!
            List<Product> result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStok > 3).ToList();
            //bu şartlara bir e ticaret uygulamasında onlarca şart getirilebilir örn kategori ismine de şart koy
            //işte bu yüzden bu yapıyı korumak adına linq kurtarıcı 

            foreach (var product2 in result)
            {
                Console.WriteLine(product2.ProductName);

            }
            Console.ReadLine();
        }

        class Product
        {
            public int ProductID { get; set; }
            public int CategoryID { get; set; }
            public string ProductName { get; set; }
            public string QuantityPerUnit { get; set; } //Ürün açıklaması
            public decimal UnitPrice { get; set; } // birim fiyatı
            public int UnitsInStok { get; set; } // ürünün stok adedi

        }
        class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }


    }
}
