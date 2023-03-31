using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplodirSapo : MonoBehaviour
{
    [SerializeField] GameObject prefabExplosion;
    public void Explode() 
    {
        GameObject explosao = Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(explosao, 3);
        Destroy(gameObject);
    }
}
