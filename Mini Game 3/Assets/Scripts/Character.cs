using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody body;
    PlayerController controls;
    Animator animator;
    public GameObject Bullet;
    public GameObject shootPoint1;
    public GameObject shootPoint2;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        controls = new PlayerController();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Shoot.performed += _ => Shoot();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, 7, 0);

    }
    bool isFirstPoint;
    public void Shoot()
    {
        if (isFirstPoint)
        {
            CreateBullet(shootPoint1.transform.position);
        }
        else
        {
            CreateBullet(shootPoint2.transform.position);
        }
        isFirstPoint = !isFirstPoint;
    }
    void CreateBullet(Vector3 position)
    {
        var bullet = Instantiate(Bullet, position, Quaternion.identity);
        var bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(transform.forward * 80, ForceMode.Impulse);
        Destroy(bullet, 2f);
    }
    public void Jump()
    {
        body.AddForce(new Vector3(0, 7, 0), ForceMode.VelocityChange);
    }
    private void FixedUpdate()
    {
        var moveDirection = controls.Player.Move.ReadValue<Vector2>();
        body.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y) * 20);
        animator.SetFloat("Speed", body.velocity.magnitude * 2);
        if (controls.Player.RotateLeft.ReadValue<float>() > 0.5f)
        {
            transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime);
        }
        else if (controls.Player.RotateRight.ReadValue<float>() > 0.5f)
        {
            transform.Rotate(Vector3.up, -90 * Time.fixedDeltaTime);
        }
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

}
