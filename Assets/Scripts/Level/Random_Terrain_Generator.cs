using UnityEngine;

public class Random_Terrain_Generator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField]
    private Transform[] levelPartList;
    [SerializeField]
    private Transform levelPart_Start;
    [SerializeField]
    private GameObject player;

    [SerializeField, Range(0.0f, 5f)]
    private float minDistBetween = 3;

    [SerializeField, Range(0.0f, 20f)]
    private float maxDistBetween = 10;

    private Vector3 lastEndPosition;


    void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //Spawn another level part
            SpawnLevelPart();

            int startingSpawnLevelParts = 5;
            for(int i = 0; i < startingSpawnLevelParts; i++)
            {
                SpawnLevelPart();
            }
        }
    }

    void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Length)];
        Transform lastlevelPartTransform = SpawnLevelPart(chosenLevelPart,  lastEndPosition);
        lastEndPosition = lastlevelPartTransform.Find("EndPosition").position;
        lastEndPosition.z = -6;
        lastEndPosition.y = -4;
        lastEndPosition.x += Random.Range(minDistBetween, maxDistBetween);
        
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
