# Collection Types

> A Hashtable object consists of buckets that contain the elements of the collection. 
> A bucket is a virtual subgroup of elements within the Hashtable, which makes searching and retrieving easier and faster than in most collections. 
> Each bucket is associated with a hash code, which is generated using a hash function and is based on the key of the element. 

- ConcurrentDictionary<TKey,TValue> Class
	- https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2?view=netcore-2.1
	- Represents a thread-safe collection of key/value pairs that can be accessed by multiple threads concurrently.
	- Namespace: System.Collections.Concurrent 
	- Assemblies: System.Collections.Concurrent.dll, mscorlib.dll, netstandard.dll
- Dictionary<TKey,TValue> Class 
	- Represents a collection of keys and values.
	- Namespace: System.Collections.Generic
	- Assemblies: System.Collections.dll, mscorlib.dll, netstandard.dll
	- use the TryGetValue method as a more efficient way to retrieve values
	- use the ContainsKey method to test whether a key exists before calling the Add method.
- Hashtable Class 
	- https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netcore-2.1
	- Represents a collection of key/value pairs that are organized based on the hash code of the key.
	- Namespace: System.Collections 
	- Assemblies: System.Collections.NonGeneric.dll, mscorlib.dll, netstandard.dll, System.Runtime.Extensions.dll
	- Implements: IDictionary ICloneable IDeserializationCallback ISerializable


