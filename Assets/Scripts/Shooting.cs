using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField] private float fireRate;
    [SerializeField] private LayerMask whatIsTarget;
    
    
    private float lastShoot;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (Time.time - lastShoot >= fireRate) {
                Shoot();
            } else {
                print("Too fast");
            }
        }
    }

    private void Shoot() {
        lastShoot = Time.time;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit ray, 100, whatIsTarget)) {
            ray.collider.GetComponent<Target>().Hit();

        }
    }
}
