using NbuyGetir.Common.Url;
using NbuyGetir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NbuyGetir.Domain.Models
{
    public class Product : AuditableEntity
    {

        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; } // alış fiyatı
        public decimal ListPrice { get; private set; } // satış fiyatı
        public int Stock { get; private set; } // current stock
        public string Description { get; private set; } // 10x2, 1lt, 2kg vb.
        public string ImageUrl { get; private set; }
        public decimal DiscountedListPrice { get; set; }
        public bool IsDiscounted { get {
                return DiscountedListPrice < ListPrice ? true : false;
        } }
        public bool IsStockInCriticalLevel { get {
                return Stock < 10 ? true : false;
            } }

        public Product(string name, decimal unitPrice, decimal listPrice, int stock,decimal discountedListPrice, string description, string ımageBase64, string ımageUrl)
        {
            SetName(name);
            SetPrice(unitPrice, listPrice, discountedListPrice);
            SetDescription(description);
            SetStock(stock);
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("Ürün açıklama alanını doldurunuz");
            }
            if (description.Length > 50)
            {
                throw new Exception("Maksimum 50 karakter girebilirsiniz");
            }
            Description = description.Trim();
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("ürün ismi boş geçilemez");
            }
            Name = name.Trim();
        }

        public void SetPrice(decimal unitPrice, decimal listPrice, decimal discountedListPrice)
        {
            if (unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz");
            }
            
            if (unitPrice <= 0 || listPrice <= 0 || discountedListPrice <= 0)
            {
                throw new Exception("Ürün birim fiyatı veya ürün satış fiyatı negatif veya 0 verilemez, indirimli satış fiyatı 0 veya daha küçük olamaz.");
            }
            
            if (discountedListPrice > listPrice)
            {
                throw new Exception("İndirimli satış fiyatı satış fiyatından büyük olamaz.");
            }
            
            if (discountedListPrice < unitPrice)
            {
                throw new Exception("İndirimli satış fiyatı birim fiyattan küçük olamaz");
            }

            ListPrice = listPrice;
            UnitPrice = unitPrice;
            DiscountedListPrice = discountedListPrice;
        }


        public void DecreasePrice(decimal newPrice)
        {
            if (newPrice > ListPrice)
            {
                throw new Exception("İndirimli fiyat liste fiyatından büyük olamaz");
            }
            if (newPrice <= UnitPrice)
            {
                throw new Exception("İndirimli fiyat birim fiyatından küçük olamaz");
            }
            
            DiscountedListPrice = newPrice;
        }

        public void IncreasePrice(decimal newListPrice,decimal newDiscountedListPrice)
        {
            if (newListPrice < ListPrice)
            {
                throw new Exception("Ürünün liste fiyatı yeni fiyattan büyük olamaz.");
            }
            if (newDiscountedListPrice > newListPrice)
            {
                throw new Exception("indirimli fiyat, zamlı fiyattan büyük olamaz.");
            }
            ListPrice = newListPrice;
            DiscountedListPrice = newDiscountedListPrice;
        }
        
        private void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new Exception("Stok değeri 0'dan daha küçük olamaz");
            }
            if (stock < 10)
            {
                // Kritik stok seviyesinin altındadır. Ürün işaretlenecektir.
            }
            else
            {

            }
        }

        public void StockIn(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("stoğa eklenecek miktar adedi 0 ya da daha düşük olamaz.");
            }
            Stock += quantity;
        }
        public void StockOut(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("stoktan düşülecek ürün adedi 0 ya da daha düşük olamaz.");
            }
            if (IsStockInCriticalLevel)
            {
                // event fırlat
            }
            if (quantity > Stock)
            {
                // hatalı işlem
                throw new Exception("stoktan düşülen miktar stok değerinden büyük olamaz");
            }

            Stock -= quantity;
        }
        public void SetImageUrl(string imageUrl)
        {
            if (!UrlHelper.IsUrl(imageUrl))
            {
                throw new Exception("resim yolu url formatında değildir.");
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                ImageUrl = "default-product.jpeg";
            }
            else
            {
                ImageUrl = imageUrl.Trim();
            }
        }
    }
}
