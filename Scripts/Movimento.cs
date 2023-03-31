using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    enum TipoDeMovimento
    {
        Transform,
        MovePosition,
        Velocity,
        Force
    }
    Rigidbody2D rb;
    float inputHorizontal;
    [SerializeField] TipoDeMovimento tipoAtual;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
  
    }

    private void FixedUpdate()
    {
        switch (tipoAtual)
        {
            case TipoDeMovimento.Transform:
                transform.position += Vector3.right * inputHorizontal * Time.fixedDeltaTime;
                break;
            case TipoDeMovimento.MovePosition:
                rb.MovePosition(rb.position + Vector2.right * inputHorizontal * Time.fixedDeltaTime);
                break;
            case TipoDeMovimento.Velocity:
                rb.velocity = Vector2.right * inputHorizontal * 5;
                break;
            case TipoDeMovimento.Force:
                rb.AddForce(inputHorizontal * Vector3.right * 5);
                break;
            
        }
        
        
    }
}
