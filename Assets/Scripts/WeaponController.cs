using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private float force = 5.0f;

    [SerializeField]
    private ForceMode bulletForceMode = ForceMode.Force;

    [SerializeField]
    private Vector3  bulletInitialPosition = new Vector3(0, 0.1544f, 0.5648003f);

    [SerializeField]
    private float bulletAliveFor = 20.0f;

    [SerializeField]
    private float bulletFrequency = 0.5f;

    private float bulletTimer = 0;

    [SerializeField]
    private AudioSource bulletSound;

    void FixedUpdate()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || 
           OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.Z))
        {
            bulletSound.Play();
            while(true)
            {
                Shoot();
                bulletTimer += Time.deltaTime * 1.0f;
                if(bulletTimer >= bulletFrequency)
                {
                    bulletTimer = 0;
                    break;
                }
            }   
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletInitialPosition, Quaternion.identity);
        bullet.transform.parent = weapon.transform;
        bullet.transform.localPosition = bulletInitialPosition;
        bullet.transform.parent = transform.parent.parent;
        Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
        bulletRigidBody.AddForceAtPosition(weapon.transform.forward * force, bullet.transform.position, bulletForceMode);
        Destroy(bullet, bulletAliveFor);
    }
}
