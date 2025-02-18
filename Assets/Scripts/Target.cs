using UnityEngine;

public class Target : MonoBehaviour {
    public TargetSpawn spawner;
    
    public void Hit() {
        spawner.UpdateScore();
        Destroy(gameObject);
    }
}
