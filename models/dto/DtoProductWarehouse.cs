namespace Apbd_task6.models.dto;


public class DtoProductWarehouse
{
    public int idProduct { get; set;}
    public int idWharehouse {get; set;}
    public int Amount {get; set;}
    public DateTime CreateAt {get; set;}

    public DtoProductWarehouse(int idProduct, int idWharehouse, int amount, DateTime createAt)
    {
        this.idProduct = idProduct;
        this.idWharehouse = idWharehouse;
        Amount = amount;
        CreateAt = createAt;
    }
}