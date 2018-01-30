using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moveButton : MonoBehaviour {
	public Transform objectTransform;
	public Vector3 translate;
	public void onButton () {
		objectTransform.localPosition += translate;
	}
}