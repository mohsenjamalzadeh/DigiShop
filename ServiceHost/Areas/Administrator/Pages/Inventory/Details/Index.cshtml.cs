using InventoryManagement.Application.Constract.Color;
using InventoryManagement.Application.Constract.Inventory;
using InventoryManagement.Application.Constract.Sizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace ServiceHost.Areas.Administrator.Pages.Inventory.Details
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryApplication _InventoryApplication;
        private readonly IColorApplication _ColorApplication;
        private readonly ISizeApplication _SizeApplication;

        public List<ProductVarientViewModel> ProductVarients { get; set; }
        public List<InventoryOperationsViewModel> OperationsLog { get; set; }
        public List<InventoryOperationsViewModel> ProductVarientOperations { get; set; }

        public InventoryViewModel Inventory { get; set; }
        public IndexModel(IInventoryApplication inventoryApplication,IColorApplication colorApplication,ISizeApplication sizeApplication)
        {
            _InventoryApplication = inventoryApplication;
            _ColorApplication = colorApplication;
            _SizeApplication=sizeApplication;
        }

        public void OnGet(long id)
        {
            Inventory = _InventoryApplication.GetInventoryBy(id);
            ProductVarients = _InventoryApplication.GetProductVarients(id);


        }

        public IActionResult OnGetAddProductVarient(long inventoryId)
        {
            var comand = new AddProductVarient
            {
                Colors=_ColorApplication.GetAll(),
                Sizes=_SizeApplication.GetAll(),  
                InventoryId=inventoryId,

            };

            return Partial("./AddProductVarient",comand);
        }

        public IActionResult OnPostAddProductVarient(AddProductVarient command)
        {
            var result=_InventoryApplication.AddProductVarient(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long inventoryId, long productVarientId)
        {
            var command=new Increase()
            {
                InventoryId=inventoryId,
                ProductVarientId=productVarientId
         
            };

            return Partial("./Increase",command);
        }
        
        public IActionResult OnPostIncrease(Increase command)
        {
            var result=_InventoryApplication.Increase(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetDecrease(long inventoryId, long productVarientId)
        {
            var command=new Reduce()
            {
                InventoryId=inventoryId,
                ProductVariant=productVarientId
         
            };

            return Partial("./Decrease",command);
        }
        
        public IActionResult OnPostDecrease(Reduce command)
        {
            var result=_InventoryApplication.Reduce(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetShowOperationslog(long inventoryId)
        {
            OperationsLog=_InventoryApplication.InventoryOperations(inventoryId);

            return Partial("./ShowOperationslog",OperationsLog);
        }

        public IActionResult OnGetProductVarientOperations(long inventoryId,long productVarientId)
        {
            ProductVarientOperations=_InventoryApplication.ProductVarientOperations(inventoryId,productVarientId);
            return Partial("./ProductVarientOperations",ProductVarientOperations);
        }



        public IActionResult OnGetChangePrice(long inventoryId, long productVarientId,double price)
        {
            var command=new changePrice()
            {
                InventoryId= inventoryId,
                ProductVarientId=productVarientId,
                UnitPrice=price
            };

            return Partial("./ChangePrice",command);

        }

        public IActionResult OnPostChangePrice(changePrice command)
        {
            var result=_InventoryApplication.ChangeProductVarientPrice(command);
            return new JsonResult(result);
        }
    }
}
