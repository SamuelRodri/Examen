using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float timeBetweenShoot;

    private float lastTimeShoot = 0;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lastTimeShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (lastTimeShoot >= timeBetweenShoot)
            {
                Instantiate(bulletPrefab, spawnPoint.transform.position, transform.rotation);
                lastTimeShoot = 0;
            }
        }
    }

}
