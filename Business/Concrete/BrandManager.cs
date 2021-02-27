using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;
		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Message.AddedItem);
		}
		
		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Message.DeletedItem);
		}
		
		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
		}
		
		[ValidationAspect(typeof(BrandValidator))]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Message.UpdatedItem);
		}
	}
}