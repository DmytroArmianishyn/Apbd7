using Apbd_task6.exceptions;
using Apbd_task6.models.dto;
using Apbd_task6.repository;

namespace Apbd_task6.service;

public class WarehouseService
{
    private readonly WarehouseRepository _repository = new WarehouseRepository();

    public WarehouseService(WarehouseRepository repository)
    {
        _repository = repository;
    }

    public WarehouseService()
    {
    }

    public int Id(IConfiguration _configuration,DtoProductWarehouse productWarehouse )
    {
       
        if (!_repository.cheakProduct(_configuration, productWarehouse.idProduct))
            throw new FakeProductException("Incorrectly entered id Product");

        if (!_repository.cheakWarehouse(_configuration, productWarehouse.idWharehouse))
            throw new FakeWarehouse("Incorrectly entered id Warehouse");

        if (productWarehouse.Amount < 1)
            throw new AmountException("Amount need be positive number");

        if (!_repository.cheackOrder(_configuration, productWarehouse.idProduct, productWarehouse.Amount))
            throw new OrderException("Bad Information about Order");

        if (!_repository.checkEndOrder(_configuration, productWarehouse.idProduct))
            throw new StatusOrderException("Order just made");
        
        _repository.updateFulfilledAt(_configuration,productWarehouse.idProduct);
        
        
        return 0;
    }
    
    
}