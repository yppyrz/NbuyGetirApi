using NbuyGetir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public string ImageBase64 { get; private set; }
        public string ImageUrl { get; private set; }
        public decimal DiscountedListPrice { get; set; }
        public bool IsDiscounted { get {
                return DiscountedListPrice < ListPrice ? true : false;
            } }


        public Product(string name, decimal unitPrice, decimal listPrice, int stock, string description, string ımageBase64, string ımageUrl)
        {
            Name = name;
            UnitPrice = unitPrice;
            ListPrice = listPrice;
            Stock = stock;
            Description = description;
            ImageBase64 = ımageBase64;
            ImageUrl = ımageUrl;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("ürün ismi boş geçilemez");
            }
            Name = name.Trim();
        }

        private void SetPrice(decimal unitPrice, decimal listPrice, double discountAmount)
        {
            if (unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz");

            }
            if (unitPrice <= 0 || listPrice <= 0)
            {
                throw new Exception("Ürün birim fiyatı veya ürün satış fiyatı negatif veya 0 verilemez");
            }

            ListPrice = listPrice;
            UnitPrice = unitPrice;
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
        
    }
}
