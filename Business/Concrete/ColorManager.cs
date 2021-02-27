using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;
		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}
			
		[ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Color color)
		{
			_colorDal.Add(color);
			return new SuccessResult(Message.AddedItem);
		}
		
		public IResult Delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult(Message.DeletedItem);
		}
		
		public IDataResult<List<Color>> GetAll()
		{
			return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Color> GetById(int id)
		{
			return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
		}
		
		[ValidationAspect(typeof(ColorValidator))]
		public IResult Update(Color color)
		{
			_colorDal.Update(color);
			return new SuccessResult(Message.UpdatedItem);
		}
	}
}