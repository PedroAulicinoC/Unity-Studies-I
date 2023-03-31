using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisao : MonoBehaviour
{
    [SerializeField] AudioClip soundClick;
    [SerializeField] Vector3 verificationPoint;
    [SerializeField] float verificationRadius = 1;
    [SerializeField] LayerMask layerSapo;
    Collider2D[] collidersFound;

    //Overlap com filtragem de Layer:
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collidersFound = Physics2D.OverlapCircleAll(transform.position, verificationRadius, layerSapo);
            for (int i = 0; i < collidersFound.Length; i++)
            {
                if (collidersFound[i].CompareTag("Sapo"))
                {
                    collidersFound[i].GetComponent<ExplodirSapo>().Explode();
                    Debug.Log("The frog is here!!!");
                }
            }
        }
    }

    //Checagem visível:
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, verificationRadius);
    }

    //Usando OnTrigger*:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Executar uma função se a tag do objeto for a correta:
        if (collision.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(soundClick, transform.position, 1f);
        }
    }

    #region OnCollision

    private void OnCollisionEnter2D(Collision2D whoEntered)
    {
        Debug.Log($"{whoEntered.gameObject.name} entered");
    }

    private void OnCollisionExit2D(Collision2D whoExited)
    {
        Debug.Log($"{whoExited.gameObject.name} exited");
    }

    private void OnCollisionStay2D(Collision2D whoIsThere)
    {
        Debug.Log($"{whoIsThere.gameObject.name} is there");
    }

    #endregion

}
