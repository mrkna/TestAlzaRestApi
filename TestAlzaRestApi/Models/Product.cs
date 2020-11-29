using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAlzaRestApi.Models
{
    public class Product
    {
        /// <summary>
        /// Id of this product
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Name of this product
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Url imageof this product
        /// </summary>
        [Required]
        public string ImgUrl { get; set; }

        /// <summary>
        /// Price of this product
        /// </summary>
        [Required]
        public decimal Price {get; set;}

        /// <summary>
        /// Description of this product
        /// </summary>
        public string Description { get; set; }
    }
}
