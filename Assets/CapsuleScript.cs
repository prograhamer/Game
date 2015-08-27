using UnityEngine;
using System.Collections;

public class CapsuleScript : MonoBehaviour {
	public Transform Capsule;

	// Update is called once per frame
	void Update () {
		int? hr = HRM.GetHeartRate();

		if(hr != null)
		{
			Vector3 p = Capsule.position;
			p.y = 1.09f + (int)hr / 200f;
			Capsule.position = p;
		}
	}
}
