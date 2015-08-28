using UnityEngine;
using System.Collections;
using Truant.Plus.Devices;

public class SpeedCadenceScript : MonoBehaviour {
	private static SpeedCadenceScript _instance;

	private BikeSpeedCadenceSensor Device;
	private bool Initialized;

	void Awake()
	{
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
		Device = new BikeSpeedCadenceSensor(2096);
		ANTScript.AddDevice(Device);
		
		Initialized = true;
	}

	public static double? GetSpeed()
	{
		if(_instance.Initialized)
		{
			return _instance.Device.Speed;
		}
		else
		{
			return null;
		}
	}

	public static double? GetCadence()
	{
		if(_instance.Initialized)
		{
			return _instance.Device.Cadence;
		}
		else
		{
			return null;
		}
	}
}
