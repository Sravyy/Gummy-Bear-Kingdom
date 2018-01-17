using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GummyBearKingdom.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Product(int id, string name, int cost, string description)
        {
            ProductId = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
        public Product()
        {

        }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                bool EqualId = this.ProductId.Equals(newProduct.ProductId);
                bool EqualName = this.Name.Equals(newProduct.Name);

                return (EqualId && EqualName);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        public double GetAvgRating()
        {
            double Counter = 0;
            double rating = 0;

            foreach (var productReview in Reviews)
            {
                rating = rating + productReview.Rating;
                Counter++;
            }

            double result = rating / Counter;

            return Math.Ceiling(result);

            //if(ratingNum > 0)
            //{
            //    for(double i=0, i < ratingNum; i++)
            //    {
            //        rating = rating + Rating[i].rating;
            //    }
            //    rating = Math.Ceiling(double)(rating / ratingNum);
            //}

            //return rating;
        }
    }
}
