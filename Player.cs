using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    bool click = false;
    Camera MainCamera;

    void Start()
    {
        MainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            if (GetComponent<Rigidbody>().velocity.y == 0)
            {
                if (Global.ScrollSpeed < 20f)
                {
                    Global.ScrollSpeed += 10f * Time.deltaTime;
                }
                click = true;
            }
        }
        else
        {
            if (click)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * Global.ScrollSpeed * 50f);
            }

            if (Global.ScrollSpeed > 10f)
            {
                Global.ScrollSpeed -= 10f * Time.deltaTime;
            }
            click = false;
        }
        MainCamera.fieldOfView = 80f + ((Global.ScrollSpeed - 10f) * 4f);
	}
}
