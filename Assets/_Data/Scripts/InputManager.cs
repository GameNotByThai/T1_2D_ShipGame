using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] private float isLeftMousePress;

    public float IsLefMousePress { get => isLeftMousePress; }


    private void Awake()
    {
        if (InputManager.Instance != null) Debug.LogError("Have more than 1 InputManger");
        instance = this;
    }

    private void Update()
    {
        this.GetLefMousePress();
    }

    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    private void GetLefMousePress()
    {
        this.isLeftMousePress = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


}
