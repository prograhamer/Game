using UnityEngine;
using System.Collections;

public class CapsuleScript : MonoBehaviour {
	public Transform Capsule;

	// Update is called once per frame
	void Update () {
		int? hr = HRMScript.GetHeartRate ();
		double? speed = SpeedCadenceScript.GetSpeed ();

		if(hr != null)
		{
			Vector3 p = Capsule.position;
			p.y = 1.09f + (int)hr / 100f;
			Capsule.position = p;

			Capsule.Rotate(0, (float)speed * Time.deltaTime, 0);
		}
	}
}
