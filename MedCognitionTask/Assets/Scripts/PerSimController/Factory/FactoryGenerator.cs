using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static PublicEnums;

public static class FactoryGenerator<T> where T : class
{

    // Name of prefab or game object
    private const string NAME = "Name";
    // dictionary for keeping created factories and find by name when its needed
    private static Dictionary<string, T> factoryTypesByName;
    // check if system started by a simple null check
    private static bool isinitialized = factoryTypesByName != null;
    public static void InitializeFactoryGenerator()
    {
        // if started no need to work code again
        if (isinitialized) { return; }
        // create instance of dictionary to add
        factoryTypesByName = new Dictionary<string, T>();
        // get all the factories which arent abstract and child of our main class provided with (T)  
        // this line uses System.Linq
        var factoryTypes = Assembly.GetAssembly(typeof(T)).GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf((typeof(T))));

        foreach (var type in factoryTypes)
        {
            //Creates instance of subclass
            var factory = Activator.CreateInstance(type) as T;
            // get Name property of class as string 
            var rslt = factory.GetType().GetProperty(NAME).GetValue(factory) as string;
            // add to Dictionary
            factoryTypesByName.Add(rslt, factory);
        }
    }
    /// 
    /// calls from factory by PrefabName
    ///
    public static T CreateObject(ResourceItem resourceitem)
    {
        // get first macth of class and return as class
        return factoryTypesByName.Where(v => v.Key == resourceitem.ToString()).Select(x => x.Value).FirstOrDefault();
    }
}
