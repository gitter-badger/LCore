![](../Content/LCore-banner-small.png "")
[&lt;img align=&quot;right&quot; src=&quot;../Content/LCore-logo-small.png&quot; alt=&quot;Logo&quot; /&gt;](../../README.md)
[Up](ReflectionExt.md)

### ReflectionExt
[View Source](../Extensions/Reference%20Types/ReflectionExt.cs)

# FindMethod

#### Public Static Method

##### public static <a href="https://msdn.microsoft.com/en-us/library/system.reflection.methodinfo.aspx" alt="">MethodInfo</a> FindMethod(<a href="https://msdn.microsoft.com/en-us/library/system.type.aspx" alt="">Type</a> In, <a href="https://msdn.microsoft.com/en-us/library/system.string.aspx" alt="">String</a> Name);

![Type Public Static Method](http://b.repl.ca/v1/Type-Public%20Static%20Method-Blue.png "") [![Lines of Code 18](http://b.repl.ca/v1/Lines%20of%20Code-18-blue.png "")](../Extensions/Reference%20Types/ReflectionExt.cs#L88)    ![Documented Yes](http://b.repl.ca/v1/Documented-Yes-brightgreen.png "") [![Source Code Available](http://b.repl.ca/v1/Source%20Code-Available-brightgreen.png "")](../Extensions/Reference%20Types/ReflectionExt.cs#L88)

![Covered No](http://b.repl.ca/v1/Covered-No-red.png "") ![Unit Tested No](http://b.repl.ca/v1/Unit%20Tested-No-lightgrey.png "") ![Attribute Tests 0](http://b.repl.ca/v1/Attribute%20Tests-0-lightgrey.png "") [![Assertions 0](http://b.repl.ca/v1/Assertions-0-lightgrey.png "")](../Extensions/Reference%20Types/ReflectionExt.cs)

##### Summary

            Finds a method by name, searching the Type  as well as all
            base types.
            Supply Type parameters to locate a method by its parameter types.
            

###### Parameters

Parameter | Optional | Type | Description
:---  | :---  | :---  | :--- 
In | No | [Type](https://msdn.microsoft.com/en-us/library/system.type.aspx) | 
Name | No | [String](https://msdn.microsoft.com/en-us/library/system.string.aspx) | 


#### Returns

###### [MethodInfo](https://msdn.microsoft.com/en-us/library/system.reflection.methodinfo.aspx)

#### Method Exceptions
T:System.Reflection.AmbiguousMatchException More than one method is found with the specified name and specified parameters. 



---

Copyright 2016 &copy; [Home](../../README.md) [Table of Contents](../../TableOfContents.md)

This markdown was generated by [LDoc](https://github.com/CodeSingularity/LDoc), powered by [LUnit](https://github.com/CodeSingularity/LUnit), [LCore](https://github.com/CodeSingularity/LCore)