using System.Collections;
using TMPro;
using UnityEngine;

public class TargetSpawn : MonoBehaviour {
    [SerializeField] private float spawnInterval;
    [SerializeField] private float targetLifeDuration;
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    [SerializeField] private int amountToSpawn;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject targetPrefab;

    private int spawnedTargets, score;

    private void Start() {
        scoreText.text = 0 + "/" + amountToSpawn;
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("start") && spawnedTargets == 0) {
            StartCoroutine(nameof(SpawnTargets));
        }

        if (Input.GetButtonDown("stop")) {
            ResetScore();
            StopCoroutine(nameof(SpawnTargets));
        }
    }

    private IEnumerator SpawnTargets() {
        float x = Random.Range(minPos.position.x, maxPos.position.x);
        float y = Random.Range(minPos.position.y, maxPos.position.y);

        Target t = Instantiate(targetPrefab, new Vector3(x, y, transform.position.z), Quaternion.identity).GetComponent<Target>();
        t.spawner = this;
        Destroy(t.gameObject, targetLifeDuration);
        spawnedTargets++;
        
        yield return new WaitForSeconds(spawnInterval);
        
        if (spawnedTargets == amountToSpawn) {
            ResetScore();
            yield break;
        }
        StartCoroutine(nameof(SpawnTargets));
    }

    private void ResetScore() {
        spawnedTargets = 0;
        score = 0;
        scoreText.text = score + "/" + amountToSpawn;
    }
    
    public void UpdateScore() {
        score++;
        scoreText.text = score + "/" + amountToSpawn;
    }
}
