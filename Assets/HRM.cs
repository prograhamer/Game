using UnityEngine;
using System.Collections;
using Truant;
using Truant.Plus;
using Truant.Plus.Devices;

public class HRM : MonoBehaviour {
	private static HRM _instance;

	private AntConnection Connection;
	private HeartRateMonitor Device;
	private bool Initialized;

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
		Connection = AntPlusConnection.GetConnection();
		Connection.Connect ();
		
		Device = new HeartRateMonitor();
		
		Connection.AddDevice (Device);

		Initialized = true;
	}

	public static int? GetHeartRate()
	{
		if(_instance.Initialized)
		{
			return _instance.Device.ComputedHeartRate;
		}
		else
		{
			return null;
		}
	}
}
