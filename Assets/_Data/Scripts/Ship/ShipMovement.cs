using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPositon;
    [SerializeField] protected float shipSpeed = 0.1f;

    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LootAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        targetPositon = InputManager.Instance.MouseWorldPos;
        targetPositon.z = 0;
    }

    protected virtual void LootAtTarget()
    {
        Vector3 diff = this.targetPositon - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPositon, shipSpeed);
        transform.parent.position = newPos;
    }
}
