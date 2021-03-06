﻿using System;
using System.Web.Http;
using DryIocSampleWebApi.Domain;

namespace DryIocSampleWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger logger, IProductRepository productRepository)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            if (productRepository == null)
            {
                throw new ArgumentNullException("productRepository");
            }

            _logger = logger;
            _productRepository = productRepository;
        }

        public IHttpActionResult Get()
        {
            _logger.Debug("Get() called");

            var products = _productRepository.GetAll();

            return Ok(products);
        }

        public IHttpActionResult Get(int id)
        {
            _logger.Debug("Get(int id) called");

            var found = _productRepository.GetById(id);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }
    }
}