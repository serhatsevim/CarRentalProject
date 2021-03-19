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
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}
		
		[SecuredOperation("car.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.AddedItem);			
		}
		
		[SecuredOperation("car.delete,admin")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.DeletedItem);
		}
		
		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<Car>> GetAll()
		{
			if(DateTime.Now.Hour == 22)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
			}	
			
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.DataListed);
		}
		
		public IDataResult<Car> GetById(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
		}
		
		[SecuredOperation("car.update,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.UpdatedItem);
		}
		
		[CacheAspect]
		public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.DataListed);
		}
		
		[CacheAspect]
		public IDataResult<List<Car>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
		}
		
		[CacheAspect]
		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{			
			return new SuccessDataResult<List<Car>>(_carDal.GetCarDetails());
		}
	}
}