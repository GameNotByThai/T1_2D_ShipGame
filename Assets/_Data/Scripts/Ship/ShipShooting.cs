using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform bulletPrefab;

    private void Update()
    {
        this.CheckShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void CheckShooting()
    {
        this.isShooting = InputManager.Instance.IsLefMousePress == 1;
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.rotation;
        Instantiate(this.bulletPrefab, spawnPos, rotation);
    }


}
