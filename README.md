# GSFS Developer Evaluation
This is my submission for the GSFS developer evaluation.

### Challenge One
I found that this challenge has a few "code smell" issues.

1. `CalculateOhmValue` returns an `int`, so neither the tolerance nor a fractional component values can be returned. Therefore:
    * There are valid inputs for the first 3 bands which which will produce invalid output.
    * `bandDColor` argument will not be used in the method body. 
2. By all appearances, `CalculateOhmValue` should be a static, pure function. But, static classes can't implement interfaces and interfaces can't define static methods.
3. The existance of `ICalculateOhmValues` is suspect. 
    * I would not expect multiple implementations of the interface. There is only a single way to calculate the color codes. Multiple implementations would only increase the chance of errors.
    * I can't see building a service that satified the interface (ala Dependency Injection). That service would not have a need for state. A simple utlity library would be much better.

So for this challenge, I created a utility library for calculating resistor value (ohms) from the color bands. I included a class that implements `ICalculateOhmValues` using the library.

#### Building & Running
1. Open ElectronicColorCode\ElectronicColorCode.sln in VS2019
2. Build and Run either ElectronicColorCode.Sample or ElectronicColorCode.Test

### Challenge Two
This is included in the solution with Challenge One.

#### Building & Running
1. Open ElectronicColorCode\ElectronicColorCode.sln in VS2019
2. Build and Run ElectronicColorCode.Test

### Challenge Three
I found that this challenge also has several "code smell" issues. Those issue plus a lack of context made it difficult to understand how this method might fit in a larger application or even be certain what it's supposed to return.

1. `GetSubItemSummary` doesn't do what it says it does. It returns multiple *summaries*. In fact, there could be multiple `SubItemSummary` objects returned for each sub-item. 
2. `TransformSubItems` uses the level three items (sub-items of the sub-items) to produce the `SubItemSummary`. So the `SubItemSummary` contains information from the next level down. Does `TransformSubItems` call itself recursively?
3. There are two methods named `GetSubItems`. One on this class and another on the Item class. These almost certainly do the same thing.
4. `TransformSubItems` is not a good name. How does it transfor the SubItems? A more descriptive name would be better.
5. What's the purpose of the second argument on `TransformSubItems`? Would it not be better to call `GetSubItems` inside `TransformSubItem`?
6. The parameter `itemNumber` is a string. Since it is not a number, a better name may be `key` or `id`.
7. `GetSubItemSummary` method could be a static, pure function. Or it could be a method on the `Item` object.

So, I guess that that `GetItemSummary` returns a flattened array of `SubItemSummary` objects from a hiearchy of `Item` objects. The name `SubItemSummary` implies that `TransformSubItems` returns a summary the item passed.

Based on this interpretation, my aternative implemenation attempts to be more clear and self-documenting.

#### Building & Running
1. Open SubItemSummary\SubItemSummary.sln in VS2019
2. Build and Run SubItemSummary

### Challenge Four

#### Building & Running
1. Ensure Node.JS 14 or later is installed
2. Open a console to SimpleParser\
3. Execute either `npm test` or `yarn test`

### Challenge Five
My best work is proprietary.  I can demostration some of it confidentially over Zoom. Here are a few of my most notable public items.

#### hash-anything
`hash-anything` is an npm library for object caching and comparisons.

https://github.com/ben-page/hash-anything

#### Stack Overflow
And here are two of my most notable Stack Overflow answers:

https://stackoverflow.com/questions/3919291/when-to-use-setattribute-vs-attribute-in-javascript/36581696#36581696

https://stackoverflow.com/questions/4924312/how-do-i-specify-the-object-to-return-from-an-expression-tree-method/13036885#13036885
