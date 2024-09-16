namespace Template.Core.Types;


//file readonly record struct Result<TError>
//    where TError : notnull
//{
//    private readonly TError? error;

//    private Result( TError? error ) => (this.error) = (error);

//    internal static Result<TError> Success() => new(default);
//    internal static Result<TError> Error( TError err ) => new(err);

//    public TResult Match<TResult>( Func<TResult> onSuccess, Func<TError, TResult> onError ) =>
//        this switch
//        {
//            { error: null } => onSuccess(),
//            { error: not null } => onError(error),
//        };

//    public static implicit operator Result<TError>( TError error ) => Error(error);
//}


public readonly record struct Result<TValue>
    where TValue : notnull
{
    private readonly TValue? value;
    private readonly Error? error;

    private Result( TValue? value, Error? error ) => (this.value, this.error) = (value, error);

    internal static Result<TValue> Success( TValue obj ) => new(obj, default);
    internal static Result<TValue> Failure( Error err ) => new(default, err);


    public static implicit operator Result<TValue>( Error error ) => Failure(error);
    public static implicit operator Result<TValue>( TValue value ) => Success(value);

    public static implicit operator Result<TValue>( Option<TValue> option ) =>
        option.Match(
            onSome: ( value ) => Success(value),
            onNone: () => Failure(Error.NotFound()));

    public TResult Match<TResult>( Func<TValue, TResult> onSuccess, Func<Error, TResult> onError ) =>
       this switch
       {
           { value: not null, error: null } => onSuccess(value),
           { value: null, error: not null } => onError(error),
           _ => throw new InvalidOperationException()
       };



    //public Result<TResult> Continue<TResult>( Func<TValue, Result<TResult>> onSuccess )
    //     where TResult : notnull =>
    //       Match
    //        (
    //         onSuccess: onSuccess,
    //         onError: ( error ) => error
    //        );

    //public Task<Result<TResult>> Continue<TResult>( Func<TValue, Task<Result<TResult>>> onSuccess )
    //     where TResult : notnull =>
    //       Match<Task<Result<TResult>>>
    //        (
    //         onSuccess: onSuccess,
    //         onError: ( error ) => Task.FromResult(Result<TResult>.Failure(error))
    //        );

    //public Result<TResult> Continue<TResult>( Func<TValue, Option<TResult>> onSuccess )
    //     where TResult : notnull =>
    //       Match<Result<TResult>>
    //        (
    //         onSuccess: ( value ) => onSuccess(value),
    //         onError: ( error ) => error
    //        );

    //public Task<Result<TResult>> Continue<TResult>( Func<TValue, Task<Option<TResult>>> onSuccess )
    //     where TResult : notnull =>
    //       Match<Task<Result<TResult>>>
    //    (
    //          onSuccess: onSuccess,
    //          onError: ( error ) => Task.FromResult(Result<TResult>.Failure(error))
    //        );

}

public static class Result
{
    public static Result<TValue> Success<TValue, TError>( TValue value )
        where TValue : notnull
        where TError : Error =>
               Result<TValue>.Success(value);

    public static Result<TValue> Failure<TValue>( Error error )
        where TValue : notnull =>
               Result<TValue>.Failure(error);



    public static Result<TResult> Continue<TValue, TResult>( this Result<TValue> result, Func<TValue, Result<TResult>> onSuccess )
         where TValue : notnull
         where TResult : notnull
    {
        return result.Match
         (
          onSuccess: onSuccess,
          onError: ( error ) => error
         );
    }

    public static async Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Result<TValue> result, Func<TValue, Task<Result<TResult>>> onSuccess )
         where TValue : notnull
         where TResult : notnull
    {
        return await result.Match
         (
          onSuccess: value => onSuccess(value),
          onError: ( error ) => Task.FromResult(Result<TResult>.Failure(error))
         );
    }

    public static async Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Task<Result<TResult>>> onSuccess )
         where TValue : notnull
         where TResult : notnull
    {
        var result = await resultTask;
        return await result.Match
          (
           onSuccess: value => onSuccess(value),
           onError: ( error ) => Task.FromResult(Result<TResult>.Failure(error))
          );
    }

    public static Result<TResult> Continue<TValue, TResult>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Result<TResult>> onSuccess )
            where TValue : notnull
         where TResult : notnull
    {
        var result = resultTask.GetAwaiter().GetResult();
        return result.Match(
            onSuccess: onSuccess,
            onError: Result<TResult>.Failure);
    }


    public static Result<TResult> Continue<TValue, TResult>( this Result<TValue> result, Func<TValue, Option<TResult>> onSuccess )
         where TValue : notnull
         where TResult : notnull
    {
        return result.Match
         (
          onSuccess: value => onSuccess(value),
          onError: ( error ) => Result<TResult>.Failure(error)
         );
    }

    public static async Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Result<TValue> result, Func<TValue, Task<Option<TResult>>> onSuccess )
         where TValue : notnull
         where TResult : notnull
    {
        return await result.Match<Task<Result<TResult>>>
         (
          onSuccess: async value => await onSuccess(value),
          onError: async ( error ) => await Task.FromResult(Result<TResult>.Failure(error))
         );
    }

    public static async Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Task<Option<TResult>>> onSuccess )
        where TValue : notnull
        where TResult : notnull
    {
        var result = await resultTask;
        return await result.Match<Task<Result<TResult>>>
         (
          onSuccess: async value => await onSuccess(value),
          onError: async ( error ) => await Task.FromResult(Result<TResult>.Failure(error))
         );
    }
}
