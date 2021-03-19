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
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;
		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[SecuredOperation("brand.add,admin")]
		[ValidationAspect(typeof(BrandValidator))]
		[CacheRemoveAspect("IBrandService.Get")]
		public IResult Add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Message.AddedItem);
		}
		
		[SecuredOperation("brand.delete,admin")]
		[CacheRemoveAspect("IBrandService.Get")]
		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Message.DeletedItem);
		}
		
		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
		}
		
		[SecuredOperation("brand.update,admin")]
		[ValidationAspect(typeof(BrandValidator))]
		[CacheRemoveAspect("IBrandService.Get")]
		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Message.UpdatedItem);
		}
	}
}