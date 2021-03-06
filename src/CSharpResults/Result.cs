using CSharpResults.Abstractions;
using System;

namespace CSharpResults
{
    /// <summary>
    /// A generic wrapper around a successful response type <typeparamref name="T"/> and an error response type <typeparamref name="E"/>
    /// </summary>
    /// <typeparam name="T">Successful response type</typeparam>
    /// <typeparam name="E">Error response type</typeparam>
    public struct Result<T, E> : IResult<T, E>
    {
        private readonly E _error;
        private readonly T _value;

        /// <summary>
        /// Indicates whether or not the result is successful
        /// </summary>
        public bool IsSuccess { get; }
        /// <summary>
        /// The successful value of type <typeparamref name="T"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">If <see cref="IsSuccess"/> is false, attempting to access this property will result in a InvalidOperationException</exception>
        public T Value => IsSuccess ? _value : throw new InvalidOperationException("Cannot get the value as the result is unsucessful");
        /// <summary>
        /// The error value of type <typeparamref name="E"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">If <see cref="IsSuccess"/> is true, attempting to access this property will result in a InvalidOperationException</exception>
        public E Error => !IsSuccess ? _error : throw new InvalidOperationException("Cannot get the error as the result is successful");

        internal Result(bool isSuccess, E error, T value)
        {
            if (isSuccess)
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
            else
            {
                if (error == null) throw new ArgumentNullException(nameof(error));
            }

            IsSuccess = isSuccess;
            _value = value;
            _error = error;
        }

        public static Result<T, E> Success(T value) => new Result<T, E>(true, default, value);
        public static Result<T, E> Failure(E error) => new Result<T, E>(false, error, default);

        public static implicit operator Result<T, E>(T value) => Success(value);
        public static implicit operator Result<T, E>(E error) => Failure(error);
    }
}
