using MyAquariumManager.Core.Enums;

namespace MyAquariumManager.Core.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public HttpCode HttpCode { get; }
        public List<string> Errors { get; }

        protected Result(bool isSuccess, HttpCode httpCode, List<string> errors)
        {
            IsSuccess = isSuccess;
            HttpCode = httpCode;
            Errors = errors;
        }

        public static Result Success(HttpCode httpCode) => new Result(true, httpCode, []);

        public static Result Success() => new Result(true, HttpCode.NoContent, []);

        public static Result Failure(List<string> errors) => new Result(false, HttpCode.InternalServerError, errors);

        public static Result Failure(HttpCode httpCode, List<string> errors) => new Result(false, httpCode, errors);

        public static Result Failure(HttpCode httpCode, string error) => new Result(false, httpCode, [error]);
    }
}
