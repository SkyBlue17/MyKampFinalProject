﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitsInStock=15,UnitPrice=15},
                new Product{CategoryId=1,ProductId=2,ProductName="Kamera",UnitsInStock=500,UnitPrice=3},
                new Product{CategoryId=2,ProductId=3,ProductName="Telefon",UnitsInStock=1500,UnitPrice=2},
                new Product{CategoryId=2,ProductId=4,ProductName="Klavye",UnitsInStock=150,UnitPrice=65},
                new Product{CategoryId=2,ProductId=5,ProductName="Fare",UnitsInStock=85,UnitPrice=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
             
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
