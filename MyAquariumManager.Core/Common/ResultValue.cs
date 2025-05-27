using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Common
{
    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        public TValue Value 
        { 
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException("Não é possível acessar o valor de um resultado de falha.");
                
                return _value;
            }
        }

        protected Result(TValue value, bool isSuccess, HttpCode httpCode, List<string> errors) : base(isSuccess, httpCode, errors)
        {
            _value = value;
        }

        public static Result<TValue> Success(TValue value) => new Result<TValue>(value, true, HttpCode.OK, []);

        public static Result<TValue> Success(TValue value, HttpCode httpCode) => new Result<TValue>(value, true, httpCode, []);

        public new static Result<TValue> Failure (List<string> errors) => new Result<TValue>(default, false, HttpCode.BadRequest, errors);

        public new static Result<TValue> Failure(HttpCode httpCode, List<string> errors) => new Result<TValue>(default, false, httpCode, errors);

        public new static Result<TValue> Failure(HttpCode httpCode, string error) => new Result<TValue>(default, false, httpCode, [error]);
    }
}
