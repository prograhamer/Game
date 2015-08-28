using UnityEngine;
using System;
using System.Threading;
using System.Collections;
using Truant;

public class ANTScript : MonoBehaviour {
	private static ANTScript _instance;
	
	private AntConnection Connection;
	private bool Initialized;
	private Queue DevicesToAdd = new Queue();
	
	void Awake() {
		if(_instance == null)
		{
			_instance = this;
			_instance.Initialize();
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnDestroy()
	{
		Connection.Disconnect();
	}
	
	private void Initialize()
	{
		Action<Exception>ErrorHandler = (ex) => {
			Debug.LogError("Failed to initialize ANT connection: " + ex.Message);
		};

		try {
			Connection = AntPlusConnection.GetConnection();
			Connection.Connect ();
			Initialized = true;
		} catch(DuplicateConnectionException dce)
		{
			ErrorHandler(dce);
		} catch(InitializationException ie)
		{
			ErrorHandler(ie);
		}
	}

	void Update()
	{
		while(Initialized && _instance.DevicesToAdd.Count > 0)
		{
			Connection.AddDevice((Device) _instance.DevicesToAdd.Dequeue());
		}
	}

	public static void AddDevice(Device device)
	{
		_instance.DevicesToAdd.Enqueue(device);
	}
}
