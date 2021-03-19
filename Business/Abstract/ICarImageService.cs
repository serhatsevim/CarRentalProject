using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IDataResult<CarImage> GetById(int id);
		IDataResult<List<CarImage>> GetAll();
		IResult Add(CarImage carImage);
		IResult Delete(CarImage carImage);
		IResult Update(CarImage carImage);
		IDataResult<List<CarImage>> GetImageByCarId(int carId);		
	}
}