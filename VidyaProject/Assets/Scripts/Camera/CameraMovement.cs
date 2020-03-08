using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform target; // What we want the camera to follow (position)
	public float smoothing; // How quickly the camera moves towards the target
	public Vector2 maxPosition; // Limits for the camera
	public Vector2 minPosition; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate() // Updates last so the camera always goes after the player
    {
		if(transform.position != target.position) 
        {
			// Lerp(a, b, c) does linear interpolation between the first two 
			// arguments (a, b) by the interpolant (c = [0,1]).
			Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

			// Clamp takes a value (the position of the camera) and adds limits so the camera stays on the map limits.
			targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
			targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
        
    }
}
