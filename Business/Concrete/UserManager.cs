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
	public class UserManager : IUserService
	{
		IUserDal _userDal;
		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}
		
		[ValidationAspect(typeof(UserValidator))]
		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Message.AddedItem);
		}
		
		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Message.DeletedItem);
		}
		
		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll(), Message.DataListed);
		}
		
		public IDataResult<User> GetById(int id)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id);
		}
		
		[ValidationAspect(typeof(UserValidator))]
		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(Message.UpdatedItem);
		}
	}
}