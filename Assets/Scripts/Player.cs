using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float jumpSpeed;
    [SerializeField] private float walkSpeed;

    private Rigidbody2D m_body;

    void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_body.velocity = Vector2.up * jumpSpeed;
            m_body.angularVelocity += 420f;
        }

        float h = (Input.GetKey(KeyCode.D)?1:0) - (Input.GetKey(KeyCode.A)?1:0);

        m_body.velocity += Vector2.right * h * walkSpeed;
    }
}
