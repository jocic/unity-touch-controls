using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = this.transform.position;

		TouchInput.ProcessTouches();

		if (TouchInput.Tap()) {
			// Does nothing...
		} else if (TouchInput.SwipeUp()) {
			pos.z += 100;
		} else if (TouchInput.SwipeDown()) {
			pos.z -= 100;
		} else if (TouchInput.SwipeLeft()) {
			pos.x -= 100;
		} else if (TouchInput.SwipeRight()) {
			pos.x += 100;
		}
		
		this.transform.position = pos;
	}
}
