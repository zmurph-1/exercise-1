using UnityEngine;

public class deplacementObstacle : MonoBehaviour
{
    public float vitesse = 2f;
    public float limiteHaut = 11f;
    public float limiteBas = -11f;
    private float direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Random.Range(0, 2) == 0 ? 1f : -1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, vitesse * direction * Time.deltaTime, 0);
        if (direction == 1f && transform.position.y > limiteHaut)
        {
            transform.position = new Vector2(transform.position.x, limiteBas);
        }
        if (direction == -1f && transform.position.y < limiteBas)
        {
            transform.position = new Vector2(transform.position.x, limiteHaut);
        }
    }
}
