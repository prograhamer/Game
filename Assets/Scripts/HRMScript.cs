using UnityEngine;
using System.Collections;
using Truant.Devices;

public class HRMScript : MonoBehaviour {
	private static HRMScript _instance;
	
	private HeartRateMonitor Device;
	private bool Initialized;

	void Awake() {
		if(_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void Start()
	{
		Device = new HeartRateMonitor();
		ANTScript.AddDevice(Device);

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
