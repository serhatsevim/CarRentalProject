using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
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

		[ValidationAspect(typeof(RentalValidator))]
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
		
		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(Message.DeletedItem);
		}
		
		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Rental> GetById(int id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id);
		}
		
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Message.UpdatedItem);
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