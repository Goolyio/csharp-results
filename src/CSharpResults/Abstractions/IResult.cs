﻿namespace CSharpResults.Abstractions
{
    public interface IResult
    {
        bool IsSuccess { get; }
    }

    public interface IValue<out T>
    {
        T Value { get; }
    }

    public interface IError<out E>
    {
        E Error { get; }
    }

    public interface IResult<out T, out E> : IResult, IValue<T>, IError<E>
    {

    }
}
