using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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

		[SecuredOperation("customer.add,admin")]
		[ValidationAspect(typeof(CustomerValidator))]
		[CacheRemoveAspect("ICustomerService.Get")]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Message.AddedItem);
		}
		
		[SecuredOperation("customer.delete,admin")]
		[CacheRemoveAspect("ICustomerService.Get")]
		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Message.DeletedItem);
		}
		
		[CacheAspect]
		[PerformanceAspect(5)]		
		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Customer> GetById(int id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id);
		}
		
		[SecuredOperation("customer.update,admin")]
		[ValidationAspect(typeof(CustomerValidator))]
		[CacheRemoveAspect("ICustomerService.Get")]
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult();
		}
	}
}