using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;

namespace ControllRR.Application.Interfaces;



public interface IPurchaseOrderService
{
    Task<PurchaseOrderDto> GetOrdersById(int id);
    Task<List<PurchaseOrderDto>> GetBySupplierAsync(int supplierId);
    Task<OperationResultDto> CreateNewSupplierOrder(PurchaseOrderDto purchaseOrderDto);
    Task<List<PurchaseOrderDto>> Search(string term);
    Task<List<PurchaseOrderDto>> SearchInvoiceNumber(string termo);
}