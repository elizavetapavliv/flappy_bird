using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    private GameObject[] columns;
    public int columnPoolSize = 7;

    public GameObject columnPrefab;

    private Vector2 objectPoolPosition = new Vector2(-15, -25);

    private float timeSinceLastSpawned;

    public float spawnRate = 3f;

    public float columnMin = -1.5f;
    public float columnMax = 0f;
    public float spawnXPosition = 10f;

    private int currentColumn = 0;
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        { 
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn++].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn %= columnPoolSize;
        }
    }
}