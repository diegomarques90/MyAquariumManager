using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Common
{
    public class ResultValue<TValue> : Result
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

        protected ResultValue(TValue value, bool isSuccess, HttpCode httpCode, List<string> errors) : base(isSuccess, httpCode, errors)
        {
            _value = value;
        }

        public static ResultValue<TValue> Success(TValue value, HttpCode httpCode) => new ResultValue<TValue>(value, true, httpCode, []);

        public new static ResultValue<TValue> Failure(HttpCode httpCode, List<string> errors) => new ResultValue<TValue>(default, false, httpCode, errors);

        public new static ResultValue<TValue> Failure(HttpCode httpCode, string error) => new ResultValue<TValue>(default, false, httpCode, [error]);
    }
}
