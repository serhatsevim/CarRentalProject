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
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}
		
		public IResult Add(Rental rental)
		{
			if(rental.ReturnDate==null)
			{
				return new ErrorResult(Message.AddedItemError);
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
		
		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Message.UpdatedItem);
		}
	}
}