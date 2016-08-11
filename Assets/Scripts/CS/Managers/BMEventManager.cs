using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

internal sealed class BMEventManager : IBMManager,IBMEventManager
{

	private Dictionary<BMEvent, Delegate> eventTable = new Dictionary<BMEvent, Delegate> ();

	private static BMEventManager instance;

	private BMEventManager ()
	{
	}


	internal static BMEventManager GetInstance ()
	{
		if (instance == null)
			instance = new BMEventManager ();
		return instance;
	}

	//AddListener is used to add listener.
	internal  void AddListener (BMEvent eventType, BMEventCallback handler)
	{
		onListenerAdding (eventType, handler);
		eventTable [eventType] = (BMEventCallback)eventTable [eventType] + handler;
	}

	internal void AddListener<T> (BMEvent eventType, BMEventCallback<T> handler)
	{
		onListenerAdding (eventType, handler);
		eventTable [eventType] = (BMEventCallback<T>)eventTable [eventType] + handler;
	}

	//RemoveListener is used to remove listener.
	internal void RemoveListener (BMEvent eventType, BMEventCallback handler)
	{
		onListenerRemoving (eventType, handler);   
		eventTable [eventType] = (BMEventCallback)eventTable [eventType] - handler;
		onListenerRemoved (eventType);
	}

	internal void RemoveListener<T> (BMEvent eventType, BMEventCallback<T> handler)
	{
		onListenerRemoving (eventType, handler);
		eventTable [eventType] = (BMEventCallback<T>)eventTable [eventType] - handler;
		onListenerRemoved (eventType);
	}
	internal void RemoveAllListeners ()
	{
		eventTable.Clear ();
	}

	internal void DispatchEvent (BMEvent eventType)
	{

		Delegate d;
		if (eventTable.TryGetValue (eventType, out d)) {
			BMEventCallback callback = d as BMEventCallback;

			if (callback != null) {
				callback ();
			} else {
				throw createDispatchException (eventType);
			}
		}
	}

	internal void DispatchEvent<T> (BMEvent eventType, T arg1)
	{
		Delegate d;
		if (eventTable.TryGetValue (eventType, out d)) {
			BMEventCallback<T> callback = d as BMEventCallback<T>;

			if (callback != null) {
				callback (arg1);
			} else {
				throw createDispatchException (eventType);
			}
		}
	}



	private void printEventTable ()
	{
		Debug.Log ("=== BMEventManager PrintEventTable ===");

		foreach (KeyValuePair<BMEvent, Delegate> pair in eventTable) {
			Debug.Log ("\t\t\t" + pair.Key + "\t\t" + pair.Value);
		}

		Debug.Log ("\n");
	}

	//Check before add listener.
	//Because one event for one handler type.
	private void onListenerAdding (BMEvent eventType, Delegate listenerBeingAdded)
	{
		if (!eventTable.ContainsKey (eventType)) {
			eventTable.Add (eventType, null);
		}

		//Handler for this event is already added and new handler is different type. That's not permitted.
		Delegate d = eventTable [eventType];
		if (d != null && d.GetType () != listenerBeingAdded.GetType ()) {
			throw new ListenerException (string.Format ("Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}", eventType, d.GetType ().Name, listenerBeingAdded.GetType ().Name));
		}
	}

	private void onListenerRemoving (BMEvent eventType, Delegate listenerBeingRemoved)
	{
		if (eventTable.ContainsKey (eventType)) {
			Delegate d = eventTable [eventType];

			if (d == null) {
				throw new ListenerException (string.Format ("Attempting to remove listener with for event type \"{0}\" but current listener is null.", eventType));
			} else if (d.GetType () != listenerBeingRemoved.GetType ()) {
				throw new ListenerException (string.Format ("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, d.GetType ().Name, listenerBeingRemoved.GetType ().Name));
			}
		} else {
			throw new ListenerException (string.Format ("Attempting to remove listener for type \"{0}\" but Messenger doesn't know about this event type.", eventType));
		}
	}

	private void onListenerRemoved (BMEvent eventType)
	{
		if (eventTable [eventType] == null) {
			eventTable.Remove (eventType);
		}
	}

	private DispatchException createDispatchException (BMEvent eventType)
	{
		return new DispatchException (string.Format ("Dispatching message \"{0}\" but listeners have a different signature than the broadcaster.", eventType.ToString ()));
	}














}

