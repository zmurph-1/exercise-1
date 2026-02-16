using UnityEngine;

public class deplacementObstacle2 : MonoBehaviour
{
    public float vitesse = 2f;
    public float limiteHaut = 11f;
    public float limiteBas = -11f;

    public float rotationSpeed = 100f;
    public float scaleSpeed = 1f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    private float direction;
    private float scaleDirection = 1f;

    void Start()
    {
        direction = Random.Range(0, 2) == 0 ? 1f : -1f;
        rotationSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
    }

    void Update()
    {
        Vector3 movement = Vector3.up * vitesse * direction * Time.deltaTime;
        transform.position += movement;

        //warp
        if (direction == 1f && transform.position.y > limiteHaut)
        {
            transform.position = new Vector2(transform.position.x, limiteBas);
        }

        if (direction == -1f && transform.position.y < limiteBas)
        {
            transform.position = new Vector2(transform.position.x, limiteHaut);
        }

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        //grossi et raptissie
        transform.localScale += Vector3.one * scaleSpeed * scaleDirection * Time.deltaTime;

        if (transform.localScale.x >= maxScale)
            scaleDirection = -1f;

        if (transform.localScale.x <= minScale)
            scaleDirection = 1f;
    }
}
