using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager:ICreditCardService
    {
        ICreditCardDal _creditCart;

        public CreditCardManager(ICreditCardDal creditCart)
        {
            _creditCart = creditCart;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCart.Add(creditCard);
            return new Result(true, Messages.CreditCardAdded);
        }

        public IResult CardControl(CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCart.Delete(creditCard);
            return new Result(true, Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCart.GetAll(), Messages.CreditCardListed);
        }

        public IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCart.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<List<CreditCard>> GetByCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public IResult IsCardExist(CreditCard creditCard)
        {
            var result = _creditCart.Get(c => c.NameSurname == creditCard.NameSurname && c.CardNumber == creditCard.CardNumber && c.Cvc == creditCard.Cvc);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCart.Update(creditCard);
            return new Result(true, Messages.CreditCardListed);

        }
    }
}
