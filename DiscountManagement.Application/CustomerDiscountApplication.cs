using _01_framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount;


namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepositpry;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepositpry)
        {
            _customerDiscountRepositpry = customerDiscountRepositpry;
        }

        public OperationResult ActiveDiscount(long id)
        {
            var operation = new OperationResult();

            var customerDiscount = _customerDiscountRepositpry.GetBy(id);
            if (customerDiscount == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            customerDiscount.Active();
            _customerDiscountRepositpry.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult DeActiveDiscount(long id)
        {
            var operation = new OperationResult();

            var customerDiscount = _customerDiscountRepositpry.GetBy(id);
            if (customerDiscount == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            customerDiscount.Delete();
            _customerDiscountRepositpry.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult DefineCustomerDiscount(DefineDiscount command)
        {
            var operation = new OperationResult();

            foreach (var item in command.ProductsId)
            {
                if (_customerDiscountRepositpry.IsExist(p => p.ProductId == item && (p.DiscountRate == command.DiscountRate || p.DiscountPrice == command.DiscountPrice)))
                    return operation.Failed(ResultMessage.IsDoblicated);

                var customerDiscount = new CustomerDiscount(item, command.StartDate, command.EndDate, command.UsePercentDiscount, command.DiscountRate, command.DiscountPrice,command.Description);
                _customerDiscountRepositpry.Create(customerDiscount);
                _customerDiscountRepositpry.SaveChanges();

            }

            return operation.IsSucssed();


        }

        public OperationResult EditCustomerDiscount(EditDiscount command)
        {
            var operation = new OperationResult();

            var customerDiscount = _customerDiscountRepositpry.GetBy(command.Id);
            if (customerDiscount == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_customerDiscountRepositpry.IsExist(p => p.ProductId == command.ProductId &&
            (p.DiscountRate == command.DiscountRate || p.DiscountPrice == command.DiscountPrice) && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            if(!customerDiscount.UsePercentDiscount)
                command.DiscountRate=0;

            customerDiscount.Edit(command.ProductId, command.StartDate, command.EndDate, command.UsePercentDiscount, command.DiscountRate, command.DiscountPrice,command.Description);
            _customerDiscountRepositpry.SaveChanges();

            return operation.IsSucssed();
        }

        public List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepositpry.GetAll(searchModel);

        }

        public EditDiscount GetDetails(long id)
        {
            return _customerDiscountRepositpry.GetDetails(id);
        }
    }
}