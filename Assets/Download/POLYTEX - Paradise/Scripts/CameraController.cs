using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; //Target that the camera will be pointing at.

    private Vector3 offset;

    public float rotateSpeed;

    public Transform pivot;

    // Start is called before the first frame update.
    void Start()
    {
        offset = target.position - transform.position; // Set the camera offset value.

        // Move pivot where player is and make the pivot child of the player.
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        //Cursor.lockState = CursorLockMode.Locked; // Hide cursor.
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position;

        // Get the x position of the mouse & rotate the target.
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        // Get the Y position of the mouse and rotate the pivot.
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        // Limit the camera rotation.
        if(pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f ,0 ,0 );
        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 315f )
        {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }

        // Move the camera based on the current rotation of the target & the original offset.
        float desiredYangle = pivot.eulerAngles.y;
        float desiredXangle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYangle, 0);
        transform.position = target.position - (rotation * offset);

        // Stop camera from going below the player.
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + 1f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
