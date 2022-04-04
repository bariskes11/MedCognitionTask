using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;


/// <summary>
/// A system for dispatching code to execute on the main thread.
/// Dispacher is important for Reaching GameObjects viaSubThreads and accessing the main thread.
/// </summary>
public class Dispatcher : MonoBehaviour
{
    #region Fields
    private static Dispatcher instance;
    private static bool instanceExists;
    private static Thread mainThread;
    private static object lockObject = new object();
    private static readonly Queue<Action> actions = new Queue<Action>();
    #endregion


    /// <summary>
    /// Gets a value indicating whether or not the current thread is the game's main thread.
    /// </summary>
    public static bool isMainThread
    {
        get
        {
            return Thread.CurrentThread == mainThread;
        }
    }

    /// <summary>
    /// Queues an action to be invoked on the main game thread.
    /// </summary>
    /// <param name="action">The action to be queued.</param>
    public static void InvokeAsync(Action action)
    {
        if (!instanceExists)
        {
            Debug.LogError("No Dispatcher exists in the scene. Actions will not be invoked!");
            return;
        }

        if (isMainThread)
        {
            // Don't bother queuing work on the main thread; just execute it.
            action();
        }
        else
        {
            lock (lockObject)
            {
                actions.Enqueue(action);
            }
        }
    }



    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            instanceExists = true;
            mainThread = Thread.CurrentThread;
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            instanceExists = false;
        }
    }
    void Update()
    {
        lock (lockObject)
        {
            while (actions.Count > 0)
            {
                actions.Dequeue()();
            }
        }
    }
}
