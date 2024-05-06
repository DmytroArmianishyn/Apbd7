using System.Data.SqlClient;
using Apbd_task6.models.dto;
using Apbd_task6.repository;
using Apbd_task6.service;
using Microsoft.AspNetCore.Mvc;

namespace Apbd_task6.controllers;

[ApiController]

public class WarehouseController: ControllerBase
{
    private readonly IConfiguration _configuration;
    public WarehouseService _service = new WarehouseService();
    public WarehouseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("/api/product")]
    public IActionResult AddProduct(DtoProductWarehouse warehouse)
    {
        _service.Id(_configuration, warehouse);
        return Ok(1);
    }
}