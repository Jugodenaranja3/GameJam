using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject globoPrefab;  // Asegúrate de que esto sea público o serializado
    public Transform leftPoint;     // Punto izquierdo del spawn
    public Transform rightPoint;    // Punto derecho del spawn
    public float spawnRate = 2f;    // Tiempo entre spawns
    public float fallSpeed = 2f;    // Velocidad de caída de los globos

    void Start()
    {
        StartCoroutine(SpawnBalloons());
    }

    IEnumerator SpawnBalloons()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            float x = Random.Range(leftPoint.position.x, rightPoint.position.x);
            Vector3 spawnPosition = new Vector3(x, transform.position.y, 0);

            // Instanciar el globo
            GameObject newGlobo = Instantiate(globoPrefab, spawnPosition, Quaternion.identity);

            // Si el prefab del globo tiene un script, se le asigna la velocidad de caída
            Globo globoScript = newGlobo.GetComponent<Globo>();
            if (globoScript != null)
            {
                globoScript.fallSpeed = fallSpeed;  // Asignar la velocidad de caída
            }
        }
    }
}
