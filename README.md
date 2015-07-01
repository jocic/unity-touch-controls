# Unity Touch Input

Touch controls made easy for Unity3D Game Engine.

# Example

After adding the script "TouchInput.cs" to your project you can start using it immediately.

```C#
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;

    public class BasicController : MonoBehaviour
    {	
	    void Start()
	    {
	
	    }

	    void Update()
	    {
		    TouchInput.ProcessTouches();

		    if (TouchInput.Tap())
		    {
			    // TAP DETECTED
		    }
		    else if (TouchInput.SwipeUp())
		    {
			    // SWIPE UP DETECTED
		    }
		    else if (TouchInput.SwipeDown())
		    {
			    // SWIPE DOWN DETECTED
		    }
		    else if (TouchInput.SwipeLeft())
		    {
			    // SWIPE LEFT DETECTED
		    }
		    else if (TouchInput.SwipeRight())
		    {
			    // SWIPE RIGHT DETECTED
		    }
	    }
    }
```
