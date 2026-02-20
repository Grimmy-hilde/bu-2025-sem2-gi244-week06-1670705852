using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;
    // ...
    int bulletcur = 0;
    float rel = 5f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (bulletcur >= maxBulletCount)
        {
            if (Time.time > rel) 
            { 
                bulletcur = 0; 
            }
        }

        if (shootAction.triggered)
        {
            if (bulletcur <= maxBulletCount)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                bulletcur = bulletcur + 1;
            }
            else if (bulletcur >= maxBulletCount)
            {
                rel = Time.time + bulletRegenerateCooldown;
            }
        }
    }
}
