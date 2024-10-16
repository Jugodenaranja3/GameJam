using UnityEngine;

public class Globo : MonoBehaviour
{
    public float fallSpeed = 14f;  

    void Update()
    {
        
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            // Sumar puntos al recoger el globo
            Score.instance.AddScore(5);  // Agregar 5 puntos por cada globo

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // Destruye el globo al colisionar con el suelo
            Destroy(gameObject);
        }
    }
}
