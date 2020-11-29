using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAlzaRestApi.Models
{
    public interface IProductContext : IDisposable
    {
        DbSet<Product> Products { get; }
        Task<int> SaveChangesAsync();
        void MarkAsModified(Product item);
    }
}
