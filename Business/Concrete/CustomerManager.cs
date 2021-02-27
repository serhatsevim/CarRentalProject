using Core.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;
		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Message.AddedItem);
		}
		
		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Message.DeletedItem);
		}
		
		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Customer> GetById(int id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id);
		}
		
		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult();
		}
	}
}