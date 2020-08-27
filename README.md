# Rubyish
This library contains a bunch of things I wish were in .net from my rails days.  It is not necessarily following good .net conventions but it does make writing some kinds of code more fun.  If you choose to use .net in this fashion (lots of sending messages and dynamically calling methods) you are losing compiler protection.  **You have been warned**

[NuGet Package](https://www.nuget.org/packages/Rubyish/)

## Enumerable
```cs
var list = new List<string>();

// Returns True
list.Empty();

// Returns False
list.Add("IHAVEABIGSPOON");
list.Empty();
```

## Object Interrogation

```cs
var obj = new Duck();
// See if this object has a certain property.  Returns true / false
obj.HasProperty("BeakColor");

// See if this object has a certain property.  Returns true / false
obj.RespondsTo("Quack");

// Return all the properties on this object.  Returns PropertyInfo[]
obj.Properties();

// Return all the methods on this object.  Returns MethodInfo[]
obj.Methods();
```

## Json stuff

```cs
// Serialize this duck into a json string.  Returns JSON.
var obj = new Duck();
var json = Duck.ToJson();

// Deserialze this json string back into a duck.
var duckInJson = "{\"BeakColor\":\"Yellow\"}";
var duck = duckInJson.FromJson<Duck>();
```

## Sending messages to objects
```cs
var duck = new Duck();

// Call the Quack method if its on the duck.
duck.Send("Quack");

// Call the Quack method and pass parameters to it.
duck.Send("Quack", "arg1", "arg2");

// If Quack returns a value you can get that value as well
var response = duck.Send<string>("Quack", "arg1", "arg2");

// If Duck has a BeakColor property with a getter
var response = duck.Send<string>("BeakColor");

// If Duck has a BeakColor property with a setter
duck.Send<string>("BeakColor", "Yellow");

// If Duck cannot respond to your message, then this throws a MethodMissingException
duck.Send<string>("DriveCar");

// If you want Duck to handle missing methods itself.  Here is an example that allows Duck to respond to anything starting with Quack.
    public class Duck : IMethodMissing
    {
        public string BeakColor { get; set; }

        public string Quack(string arg1, string arg2)
        {
            return "quack!!";
        }
        
        public object MethodMissing(string methodName, params object[] args)
        {
            if (methodName.StartsWith("Quack"))
            {
                var returnValue = methodName.Replace("Quack", "I know how to quack ");
                return returnValue;
            }
            throw new MethodMissingException($"I don't know what you mean");
        }
    }

var obj = new Duck();
// Writes out "I know how to quack Loudly"
Console.WriteLine(obj.Send<string>("QuackLoudly"));
// Writes out "I know how to quack Softly"
Console.WriteLine(obj.Send<string>("QuackSoftly"));
```

## String methods

```cs
// Returns a boolean value true
string str = "True";
str.IsTrue();

// Returns a boolean value false
string str = "False";
str.IsTrue();

// Returns a boolean value false
string str = "false";
str.IsTrue();

// Returns a boolean value false
string str = "false";
str.IsTrue();

// Returns a boolean value false
string str = null;
str.IsTrue();

// Returns a boolean value false
string str = String.Empty;
str.IsTrue();

// Returns the boolean representation of this string
string str = "false";
str.ToBoolean();

// Returns a boolean value true if the string is anything other than empty or null
string str = "some value";
str.Present();

// Returns a boolean value true if the string is empty or null
string str = "some value";
str.Present();
```

## Time related methods

```cs
// All of the following return timespan objects of the given length

// It's been one week since you looked at me
1.Weeks();
//Five days since you laughed at me saying Get that together, come back and see me"
5.Days();
//Three days (72 hours) since the living room
72.Hours();
// But it'll still be two days (2,880 Minutes) till I say I'm sorry
2880.Minutes();
// Cocked your head to the side and said, "I'm angry" (takes about 3 seconds)
3.Seconds();
// How many years ago this song came out
22.Years();
// How long this was a billboard top 1 hit
1.Months();
// Get an integer representation of a timespan in seconds.  Will return 60
1.Minutes().ToInt();
```

## Times loops

```cs
// Will run your code x times.  In this instance value will be 10
var value = 0;
10.Times(() => { value += 1; });

// Collect results from a code run x.times.  Return and array that will look lke this [1,2,3,4,5,6,7,8,9,10]
int value = 0;
var returnValues = 10.Times<int>(() =>
{
    value += 1;
    return value;
});
```

## Type related methods

```cs
// Assuming we have a type like Namespace.Duck, this will return true
Types.Exists("Duck");

// This will return the first type named Duck that we can find
Types.First("Duck");

// Assuming we have two ducks Namespace1.Duck and Namespace2.Duck this will return both types
Types.Find("Duck");

```

## DateTime

```cs
var dt = new DateTime();

// Should return an int like 912312312 representing the time in seconds since the unix epoch
dt.ToTimeStamp(); 

// Converts this datetime object from EST to UTC
dt.EstToUtc(); 

// Converts this datetime object to EST
dt.ToEst(); 
``` 

## Unix timespan stuff

```cs
// Create a datetime object given a unix timestamp
long ts = 946684800;
var dt = ts.FromUnixTimeStamp();
```
