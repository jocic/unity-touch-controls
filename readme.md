# Touch Input

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/db5c8a095b2b482ca3af06d3e2540099)](https://www.codacy.com/app/jocic/Unity.TouchInput?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=jocic/Unity.TouchInput&amp;utm_campaign=Badge_Grade) [![License](https://poser.pugx.org/jocic/google-authenticator/license)](https://packagist.org/packages/jocic/google-authenticator)

Touch gestures made easy for Unity3D Game Engine.

# Example

After adding the script "TouchInput.cs" to your project you can start using it immediately.

```C#
    using UnityEngine;
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
