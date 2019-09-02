# NOption
NOption is a concise and fluent implementation of the Option pattern for the .NET platform.

## Usage
### Add the library namespace
Simply import the NOption namespace:

```csharp
import NOption;
```

### Use Option<> as the return type
To start using NOption:
  * Change your function return type to Option<>;
  * The return value will implicitely be wrapped in an Option<>;
  * To specify that there is no return value, use Option.None.

```csharp
static Option<Color> GetFavoriteColor(string username)
{
	if ("Emma".Equals(username))
	{
		return Color.Blue;
	}
	return Option.None;
}
```

### Working with the result
To work with result, you can use Match (with named arguments to improve readability):

```csharp
var result = GetFavoriteColor("Emma");
result.Match(
	Some: (favoriteColor) => Console.WriteLine($"Emma likes the color {favoriteColor}."),
	None: () => Console.WriteLine("Emma does not have a favorite color.")
);
// Print "Emma likes the color Blue"
```

You can also unwrap the content with a default value:

```csharp
var result = GetFavoriteColor("Mark");
var favoriteColor = result.UnwrapOr(Color.Purple); // Returns Color.Purple
```

Or you can extract the value:

```csharp
var result = GetFavoriteColor("Emma");
if (result.HasSome(out var favoriteColor))
{
 Console.WriteLine($"Emma likes the color {favoriteColor}.")
}
```

### Bonus
To rewrite GetFavoriteColor as a one line function, we could have use:

```csharp
static Option<Color> GetFavoriteColor(string username)
{
  return "Emma".Equals(username) ? Option.Some(Color.Blue) : Option.None;
}
```
