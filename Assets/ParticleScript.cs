using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem part_system;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        var em = part_system.emission;
        var main = part_system.main;
        em.enabled = false;

        if (Input.GetKey(KeyCode.W))
        {
            em.enabled = true;
            em.rateOverTime = 12f;
            main.startLifetime = 0.4f;
            main.startSpeed = 8f;
            main.startSize = 4f;

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            em.enabled = true;
            em.rateOverTime = 12f;
            main.startSpeed = 20f;
            main.startLifetime = 0.5f;
            main.startSize = 7f;
        }

        
    }
}
