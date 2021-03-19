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
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;
		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		[SecuredOperation("color.add,admin")]
		[ValidationAspect(typeof(ColorValidator))]
		[CacheRemoveAspect("IColorService.Get")]
		public IResult Add(Color color)
		{
			_colorDal.Add(color);
			return new SuccessResult(Message.AddedItem);
		}
		
		[SecuredOperation("color.delete,admin")]
		[CacheRemoveAspect("IColorService.Get")]
		public IResult Delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult(Message.DeletedItem);
		}
		
		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<Color>> GetAll()
		{
			return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<Color> GetById(int id)
		{
			return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
		}
		
		[SecuredOperation("color.update,admin")]
		[ValidationAspect(typeof(ColorValidator))]
		[CacheRemoveAspect("IColorService.Get")]
		public IResult Update(Color color)
		{
			_colorDal.Update(color);
			return new SuccessResult(Message.UpdatedItem);
		}
	}
}