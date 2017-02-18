using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

    public float horizMove = 5f;
    public float vertMove = 5f;

	Vector3 offset;

	void Start()
	{
		offset = transform.position - target.position;
	}

	void Update()
	{
        if (Input.GetKey(KeyCode.A))
        {
            MoveHorizontal(true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveHorizontal(false);
        }

        Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		//transform.LookAt (target.position);
        
    }

    public void MoveHorizontal(bool left)
    {
        float dir = 1;
        if(!left)
        {
            dir *= -1;
        }
		transform.RotateAround(target.position, Vector3.up, horizMove * dir);
		//transform.LookAt (target.position);
    }

	/*void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}*/

}
