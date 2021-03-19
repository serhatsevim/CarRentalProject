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
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}
		
		[SecuredOperation("rental.add,admin")]
		[ValidationAspect(typeof(RentalValidator))]
		[CacheRemoveAspect("IRentalService.Get")]
		public IResult Add(Rental rental)
		{
			IResult result = BusinessRules.Run(CheckIfCarIsRental(rental.CarId);
			
			if (result != null)
			{
				return result;
			}
			
			_rentalDal.Add(rental);
			return new SuccessResult(Message.AddedItem);
		}
		
		[SecuredOperation("rental.delete,admin")]
		[CacheRemoveAspect("IRentalService.Get")]
		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(Message.DeletedItem);
		}
		
		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Rental> GetById(int id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id);
		}
		
		[SecuredOperation("rental.update,admin")]
		[ValidationAspect(typeof(RentalValidator))]
		[CacheRemoveAspect("IRentalService.Get")]
		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Message.UpdatedItem);
		}
		
		[CacheAspect]
		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
		}
		
		private IResult CheckIfCarIsRental(int carId)
		{
			var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate != null).Any();
			
			if(result)
			{
				return new ErrorResult(Message.CarIsRentalError);
			}
			return new SuccessResult();
		}				
		
	}
}