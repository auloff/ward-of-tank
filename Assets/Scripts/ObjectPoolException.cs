using System;
using UnityEngine;

[Serializable]
public sealed class ObjectPoolException : UnityException
{
    public ObjectPoolException() : base ("Object pool exception, there is no object in the pool with this tag") {}
    public ObjectPoolException(string message) : base(message) {}
    public ObjectPoolException(string message, Exception innerException) : base(message, innerException) {}
    private ObjectPoolException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext) {}
}
