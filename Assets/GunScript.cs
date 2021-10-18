using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float range = Mathf.Infinity;
    public Camera shootCam;
    public ParticleSystem muzzleflash;
    public LineRenderer laser;
    [SerializeField] float laser_width = 0.2f;

    private void Start()
    {
        Vector3[] laser_positions = new Vector3[2] {Vector3.zero, Vector3.zero};
        laser.SetPositions(laser_positions);
        laser.startWidth = laser_width;
        laser.endWidth = laser_width;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Fire1 is default Unity button for LMB
        {
            Shoot();
            laser.enabled = true;
        }
        else
        {
            
            laser.enabled = false;
        }
        
    }

    private void Shoot()
    {
        muzzleflash.Play();

        RaycastHit hit;
        
        Vector3 endPosition = transform.position + (range * shootCam.transform.forward);

        if (Physics.Raycast(shootCam.transform.position, shootCam.transform.forward, out hit, range))
        {
            //Debug.DrawRay(shootCam.transform.position, shootCam.transform.forward, Color.yellow);
            print("Hit: " + hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            endPosition = hit.transform.position;

            switch (target.tag)
            {
                case "Enemy":
                    target.TakeDamage(10);
                    break;
                case "Coin":
                    target.TakeDamage(20);
                    break;
            }
            
        }

        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, endPosition);
    }
}
