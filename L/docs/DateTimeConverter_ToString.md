![](../Content/LCore-banner-small.png "")
[&lt;img align=&quot;right&quot; src=&quot;../Content/LCore-logo-small.png&quot;&gt;](../../README.md)
[Up](DateTimeConverter.md)

### DateTimeConverter
[View Source](../Tools/DateTimeConverter.cs)

# ToString

#### Static Method

###### public static [String](https://msdn.microsoft.com/en-us/library/system.string.aspx) ToString([DateTime](https://msdn.microsoft.com/en-us/library/system.datetime.aspx) UtcDateTime);

![Type Public Static Override Method](http://b.repl.ca/v1/Type-Public%20Static%20Override%20Method-blue.png "") ![Lines of Code 0](http://b.repl.ca/v1/Lines%20of%20Code-0-blue.png "") ![TODOs 0](http://b.repl.ca/v1/TODOs-0-green.png "") ![Bugs 0](http://b.repl.ca/v1/Bugs-0-green.png "") ![Not Implemented 0](http://b.repl.ca/v1/Not%20Implemented-0-green.png "") ![Documented Yes](http://b.repl.ca/v1/Documented-Yes-brightgreen.png "") [![SourceCode Available](http://b.repl.ca/v1/SourceCode-Available-brightgreen.png "")](../Tools/DateTimeConverter.cs#L)

![UnitTested No](http://b.repl.ca/v1/UnitTested-No-lightgrey.png "") ![AttributeTests 0](http://b.repl.ca/v1/AttributeTests-0-lightgrey.png "") [![Assertions 0](http://b.repl.ca/v1/Assertions-0-lightgrey.png "")](../Tools/DateTimeConverter.cs)

##### Summary

            Converts the value of the specified  object to its equivalent string representation.
            

###### Parameters

Parameter | Optional | Type | Description
:---  | :---  | :---  | :--- 
UtcDateTime | No | [DateTime](https://msdn.microsoft.com/en-us/library/system.datetime.aspx) | The Coordinated Universal Time (UTC)  to convert.


#### Returns

###### [String](https://msdn.microsoft.com/en-us/library/system.string.aspx)
A RFC 3339 string representation of the value of the .

#### Exceptions
T:System.ArgumentException The specified  object does not represent a Coordinated Universal Time (UTC) value.



---

Copyright 2016 &copy; [Home](../../README.md) [Table of Contents](../../TableOfContents.md)

This markdown was generated by [LDoc](https://github.com/CodeSingularity/LDoc), powered by [LUnit](https://github.com/CodeSingularity/LUnit), [LCore](https://github.com/CodeSingularity/LCore)
