using NbuyGetir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Domain.Models
{
    public class Category:Entity
    {
        public string Name { get; set; }

        /// <summary>
        /// Ekranda ilk açılışta en üst seviye olan kategoriler listelenecek. Ürünleri ise bu üst seviye kategorinin alt kategorilerine bağlayacağız.
        /// </summary>
        public bool IsTopLevel { get; private set; } // en üst seviye kategori.

        private List<Product> _products = new List<Product>();
        public IReadOnlyList<Product> Products => _products;
        
        private List<Category> _subCategories = new List<Category>();
        public IReadOnlyList<Category> SubCategories => _subCategories;

        public Category(string name, bool isTopLevel)
        {
            IsTopLevel = isTopLevel;
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Kategori ismi boş geçilemez.");
            }
        }

        public void AddSubCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("Category ismi boş geçilemez.");
            }
            // Top level olan kategori, alt kategori olarak eklenemez.
            if (category.IsTopLevel)
            {
                throw new Exception("Top level bir kategori alt kategori olarak atanamaz");
            }
            _subCategories.Add(category);
        }
    
        public void AddProduct(Product product)
        {
            if (!IsTopLevel && _subCategories.Count() == 0)
            {
                _products.Add(product);
            }
        }
    }
}
