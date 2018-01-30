using System.Collections;
using UnityEngine;
public class lookAtTarget : MonoBehaviour {
	public Transform attacker;
	void Update() {
		this.transform.LookAt(attacker);
	}
}