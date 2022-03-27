# What is it?
This repository contains methods that allow us to dynamically access properties faster than reflection.

# How to Use
```C#
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using DelegeteToPropertyAccess;  // The namespace of the code in this repository.

//List the properties of TestClass and the corresponding accessors before the instantiation loop process.
var properties = typeof(TestClass).GetProperties();
var accessors = properties.Select(x => x.GetAccessor()).ToList();

//Generate a list of TestClass from a 2D list string2dList of String type that is the material loop
var testClassInstanses = new List<TestClass>();
for (int i = 0; i < string2dList.Count; i++) {
    var t = new TestClass();
    
    for (int j = 0; j < accessors.Length; j++) {
        accessors[j].SetValue(t, string2dList[i][j]);
    }
    
    testClassInstanses.Add(t);
}
```

# Learn More
Research on processing speed measurement results is published in following article. (written in Japanese)

https://docs.sakai-sc.co.jp/article/programing/csharp-reflection-performance.html

# License
Feel free to use this at your own risk.
