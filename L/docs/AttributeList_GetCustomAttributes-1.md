![](Content/LCore-banner-small.png "")
[&lt;img align=&quot;right&quot; src=&quot;Content/LCore-logo-small.png&quot; alt=&quot;Logo&quot; /&gt;](../README.md)

###### namespace LCore.Dynamic

###### public class [AttributeList](docs/AttributeList.md)
[Up](docs/AttributeList.md)

### AttributeList
[View Source](Dynamic%20Code/Attributes/AttributeList.cs)

# GetCustomAttributes

##### Summary
Returns an array of custom attributes defined on this member, identified by type, or an empty array if there are no custom attributes of that type.

#### Public Virtual Method

##### public virtual <a href="https://msdn.microsoft.com/en-us/library/system.object.aspx" alt="">Object</a>[] GetCustomAttributes(<a href="https://msdn.microsoft.com/en-us/library/system.type.aspx" alt="">Type</a> AttributeType, <a href="https://msdn.microsoft.com/en-us/library/system.boolean.aspx" alt="">Boolean</a> Inherit);

![Type Public Virtual Method](http://b.repl.ca/v1/Type-Public%20Virtual%20Method-blue.png "")     ![Documented Yes](http://b.repl.ca/v1/Documented-Yes-brightgreen.png "") [![Source Code Available](http://b.repl.ca/v1/Source%20Code-Available-brightgreen.png "")](Dynamic%20Code/Attributes/AttributeList.cs#L)

![Covered No](http://b.repl.ca/v1/Covered-No-red.png "") ![Unit Tested No](http://b.repl.ca/v1/Unit%20Tested-No-lightgrey.png "") ![Attribute Tests 0](http://b.repl.ca/v1/Attribute%20Tests-0-lightgrey.png "") [![Assertions 0](http://b.repl.ca/v1/Assertions-0-lightgrey.png "")](Dynamic%20Code/Attributes/AttributeList.cs)

###### Parameters

Parameter | Optional | Type | Description
:---  | :---  | :---  | :--- 
AttributeType | No | [Type](https://msdn.microsoft.com/en-us/library/system.type.aspx) | The type of the custom attributes. 
Inherit | No | [Boolean](https://msdn.microsoft.com/en-us/library/system.boolean.aspx) | When true, look up the hierarchy chain for the inherited custom attribute. 


#### Returns

###### [Object](https://msdn.microsoft.com/en-us/library/system.object.aspx)[]
An array of Objects representing custom attributes, or an empty array.



---

Copyright 2016 &copy; [](../README.md) [](../TableOfContents.md)

This markdown was generated by [LDoc](https://github.com/CodeSingularity/LDoc), powered by [LUnit](https://github.com/CodeSingularity/LUnit), [LCore](https://github.com/CodeSingularity/LCore)
