using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public interface IProductRepository
    {
        List<Product> LatestProducts(int n);
        List<Product> LatestProducts();
        List<Product> RelatedProducts(Product product, int n);

        Product Find(int id);
    }
}
