using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float xMin,xMax;
    private Transform tf;
    public float deltaMouseX;
    private float lastX;

    void Start()
    {
        tf = GetComponent<Transform>();
        deltaMouseX = 0;
        lastX = 0;
    }
	// Update is called once per frame
	void FixedUpdate () {
        float mouseX = Input.mousePosition.x;
        deltaMouseX = mouseX - lastX;
        lastX = mouseX;
        float gap = tf.localScale.x / 4;
        Vector3 v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        Vector3 newPosition = new Vector3(Mathf.Clamp(v3.x, xMin + gap, xMax - gap), tf.position.y, tf.position.z);
        tf.position = newPosition;
        
        
	}
}
