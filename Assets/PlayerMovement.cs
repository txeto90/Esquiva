using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        // target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        transform.position = new Vector2(target.x, target.y);

        /*
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("x:" + target.x + ", y:" + target.y);
            target.z = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Debug.DrawLine(transform.position, target, Color.green);
        */

    }
}
