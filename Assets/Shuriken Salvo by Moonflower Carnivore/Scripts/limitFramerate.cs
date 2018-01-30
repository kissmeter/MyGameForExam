using UnityEngine;
using System.Collections;

public class limitFramerate : MonoBehaviour {
    void Awake() {
        Application.targetFrameRate = 60;
    }
}