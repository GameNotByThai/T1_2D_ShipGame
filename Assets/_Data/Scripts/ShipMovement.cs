using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPos;
    [SerializeField] protected float shipSpeed = 0.1f;

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        //Get mouse pos
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        //Set new ship pos
        Vector3 newPos = Vector3.Lerp(transform.position, worldPos, shipSpeed);
        transform.position = newPos;
    }
}
