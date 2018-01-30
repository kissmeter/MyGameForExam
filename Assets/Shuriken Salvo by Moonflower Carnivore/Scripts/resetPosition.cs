using System.Collections;
using UnityEngine;
public class resetPosition : MonoBehaviour {
	public Vector3 position;
	public void resetPos() {
		transform.position = position;
	}
}