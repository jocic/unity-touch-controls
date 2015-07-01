/**************************************************\
|* Script Author: Djordje Jocic                   *|
|* Script Year: 2015                              *|
|* Script Version: 1.0.0                          *|
|* Script License: MIT License (MIT)              *|
|* ============================================== *|
|* Official Website: http://www.djordjejocic.com/ *|
|* ============================================== *|
|* Permission is hereby granted, free of charge,  *|
|* to any person obtaining a copy of this         *|
|* software and associated documentation files    *|
|* (the "Software"), to deal in the Software      *|
|* without restriction, including without         *|
|* limitation the rights to use, copy, modify,    *|
|* merge, publish, distribute, sublicense, and/or *|
|* sell copies of the Software, and to permit     *|
|* persons to whom the Software is furnished to   *|
|* do so, subject to the following conditions:    *|
|* ---------------------------------------------- *|
|* The above copyright notice and this permission *|
|* notice shall be included in all copies or      *|
|* substantial portions of the Software.          *|
|* ---------------------------------------------- *|
|* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT      *|
|* WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,      *|
|* INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF *|
|* MERCHANTABILITY, FITNESS FOR A PARTICULAR      *|
|* PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL *|
|* THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR *|
|* ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER *|
|* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,   *|
|* RISING FROM, OUT OF OR IN CONNECTION WITH THE  *|
|* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE   *|
|* SOFTWARE.                                      *|
\**************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchInput
{
	// "Core" Variables.
	
	private static Vector2[] tapPositions    = new Vector2[2];
	private static Vector2[] swipePositions  = new Vector2[2];
	
	// "Offset" Variables.

	private static float     offsetTap       = 15.0F;
	private static float     offsetSwipe     = 40.0F;

	// "Flag" Variables.
	
	private static bool      fTapAllowed     = false;
	private static bool      fSwipeAllowed   = false;

	// "Other" Variables.

	private static float     tempX           = 0.0F;
	private static float     tempY           = 0.0F;

	// "Core" Methods.
	
	public static void ProcessTouches()
	{
		if (Input.touchCount > 0) // Check If User Is Touching The Screen.
		{
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began) // Begin Phase.
			{
				TouchInput.tapPositions[0]   = touch.position;
				TouchInput.swipePositions[0] = touch.position;
			}
			else if (touch.phase == TouchPhase.Canceled) // Canceled Phase.
			{
				TouchInput.ResetPositions();
			}
			else if (touch.phase == TouchPhase.Ended) // Ended Phase.
			{
				TouchInput.tapPositions[1]   = touch.position;
				TouchInput.swipePositions[1] = touch.position;

				TouchInput.fTapAllowed   = true;
				TouchInput.fSwipeAllowed = true;
			}
			else if (touch.phase == TouchPhase.Moved) // Moved Phase.
			{
				// NO CODE ATM FOR MOVED
			}
			else if (touch.phase == TouchPhase.Stationary) // Stationary Phase.
			{
				// NO CODE ATM FOR STATIONARY
			}
		}

	}

	private static void ResetPositions()
	{
		TouchInput.tapPositions  = new Vector2[2];

		TouchInput.fTapAllowed   = false;
		TouchInput.fSwipeAllowed = false;
	}

	// "Controls" Methods.
	
	public static bool Tap()
	{
		bool result = false;

		if (TouchInput.fTapAllowed)
		{
			TouchInput.tempX = Mathf.Abs(TouchInput.tapPositions[0].x - TouchInput.tapPositions[1].x);
			TouchInput.tempY = Mathf.Abs(TouchInput.tapPositions[0].y - TouchInput.tapPositions[1].y);

			if (tempX <= TouchInput.offsetTap && tempY <= TouchInput.offsetTap)
			{
				result = true;
			}

			TouchInput.tapPositions = new Vector2[2];
			TouchInput.fTapAllowed  = false;
		}

		return result;
	}

	public static bool SwipeLeft()
	{
		bool result = false;

		if (TouchInput.fSwipeAllowed)
		{
			TouchInput.tempX = TouchInput.swipePositions[0].x - TouchInput.swipePositions[1].x;
			
			if (tempX >= TouchInput.offsetSwipe)
			{
				TouchInput.swipePositions = new Vector2[2];
				TouchInput.fSwipeAllowed  = false;
				result                    = true;
			}
		}

		return result;
	}

	public static bool SwipeRight()
	{
		bool result = false;
		
		if (TouchInput.fSwipeAllowed)
		{
			TouchInput.tempX = TouchInput.swipePositions[1].x - TouchInput.swipePositions[0].x;
			
			if (tempX >= TouchInput.offsetSwipe)
			{
				TouchInput.swipePositions = new Vector2[2];
				TouchInput.fSwipeAllowed  = false;
				result                    = true;
			}
		}
		
		return result;
	}

	public static bool SwipeUp()
	{
		bool result = false;
		
		if (TouchInput.fSwipeAllowed)
		{
			TouchInput.tempY = TouchInput.swipePositions[1].y - TouchInput.swipePositions[0].y;
			
			if (tempY >= TouchInput.offsetSwipe)
			{
				TouchInput.swipePositions = new Vector2[2];
				TouchInput.fSwipeAllowed  = false;
				result                    = true;
			}
		}
		
		return result;
	}

	public static bool SwipeDown()
	{
		bool result = false;
		
		if (TouchInput.fSwipeAllowed)
		{
			TouchInput.tempY = TouchInput.swipePositions[0].y - TouchInput.swipePositions[1].y;
			
			if (tempY >= TouchInput.offsetSwipe)
			{
				TouchInput.swipePositions = new Vector2[2];
				TouchInput.fSwipeAllowed  = false;
				result                    = true;
			}
		}
		
		return result;
	}
}
