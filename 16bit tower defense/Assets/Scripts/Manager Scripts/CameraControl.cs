using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private bool movement = true;

    public float panSpeed = 0.5f;
    public float panBorderThickness = 1f;
    public float ScrollSpeed = 0.1f;
    public float minz = 1f;
    public float maxz = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            movement = !movement;
        }

        if(!movement)
        {
            return;
        }


        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.up.normalized * panSpeed * Time.deltaTime, Space.World);
        } else if (Input.GetKey("a") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right.normalized * panSpeed * Time.deltaTime, Space.World);
        } else if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.down.normalized * panSpeed * Time.deltaTime, Space.World);
        } else if (Input.GetKey("d") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left.normalized * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.z -= scroll * 1000 * ScrollSpeed * Time.deltaTime;
        //pos.z = Mathf.Clamp(pos.y, minz, maxz);
        transform.position = pos;

    }
}
