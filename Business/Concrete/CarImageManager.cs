using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}

		[SecuredOperation("carImage.add,admin")]
		[ValidationAspect(typeof(CarImageValidator))]
		[CacheRemoveAspect("ICarImageService.Get")]
		[TransactionScopeAspect]
		public IResult Add(CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
			if (result != null)
			{
				return result;
			}	
			_carImageDal.Add(carImage);
			return new SuccessResult(Messages.AddedItem);
		}
		
		[SecuredOperation("carImage.delete,admin")]
		[CacheRemoveAspect("ICarImageService.Get")]
		[TransactionScopeAspect]
		public IResult Delete(CarImage carImage)
		{
			_carImageDal.Delete(carImage);
			return new SuccessResult(Messages.DeletedItem);
		}
		
		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll);
		}
		
		public IDataResult<CarImage> GetById(int id)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
		}
		
		[SecuredOperation("carImage.update,admin")]
		[ValidationAspect(typeof(CarImageValidator))]
		[CacheRemoveAspect("ICarImageService.Get")]
		[TransactionScopeAspect]
		public IResult Update(CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			_carImageDal.Update(carImage);
			return new SuccessResult(Messages.UpdatedItem);
		}
		
		public IDataResult<List<CarImage>> GetImageByCarId(int id)
		{
			return new SuccessDataResult<List<CarImage>>(CheckIfCarImageExists(id));
		}
		
		private IResult CheckIfCarImageLimitExceded(int id)
		{
			var result = _carImageDal.GetAll(c => c.CarId == id).Count;
			if (result > 5)
			{
				return new ErrorResult(Messages.CarImageLimitExcededError);
			}
			return new SuccessResult();
		}
		
		private List<CarImage> CheckIfCarImageExists(int id)
		{
			string path = @"\images\logo.png";
			var result = _carImageDal.GetAll(c => c.CarId == id).Any();
			if (!result)
			{
				return new List<CarImage>{new CarImage{CarId = id, ImagePath:path, Date:DateTime.Now}};				
			}
			return _carImageDal.GetAll(c => c.CarId = id);			
		}
	}
}