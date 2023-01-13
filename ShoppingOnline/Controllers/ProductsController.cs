using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_online.Models;
using Shopping_online.Servies;
using ShoppingOnline.Dtos;
using ShoppingOnline.Interface;
using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_online.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IGenericRepository<Product> _ProductsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _Mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> ProductBrandsRepo,
             IGenericRepository<ProductType> ProductTypeRepo, IMapper mapper)
        {
            _ProductsRepo = productsRepo;
            _productBrandsRepo = ProductBrandsRepo;
            _productTypeRepo = ProductTypeRepo;
            _Mapper = mapper;
        }



        [HttpGet]
        public async Task <IReadOnlyList<ProductDto>> GetProducts(string sort, int? BrandId, int? TypeId)
        {
            try
            {
                var spec = new ProductsWithTypesAndBrandsSpecification(sort, BrandId, TypeId);
                var Product = await _ProductsRepo.ListAsync(spec);
                var ProductDto = _Mapper.Map<IReadOnlyList<ProductDto>>(Product);
                return ProductDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
 
        [HttpGet("{id}")]  
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {

            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var Products= await _ProductsRepo.GetEntityWithSpes(spec);

            if (Products == null)
               return NotFound($"No Product was found with ID{id} ");


            return _Mapper.Map<Product, ProductDto>(Products);

        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandsRepo.ListAllAsync());
        }

        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }


        

    }

   
}
