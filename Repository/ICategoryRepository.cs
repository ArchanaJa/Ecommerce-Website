using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public interface ICategoryRepository
    {
        List<Category> findAll();
        Category find(int id);
    }
}
