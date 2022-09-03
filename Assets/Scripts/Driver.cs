using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float boostSpeed;

    [SerializeField] private float slowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
        }

    }

    public void PickUpBoost()
    {
        moveSpeed = boostSpeed;
    }

    public void SlowDown()
    {
        moveSpeed = slowSpeed;
    }
}
