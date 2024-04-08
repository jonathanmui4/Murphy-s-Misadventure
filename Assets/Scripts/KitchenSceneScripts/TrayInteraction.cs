using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayInteraction : MonoBehaviour
{
    [SerializeField] private GameObject Pan;
    [SerializeField] private ParticleSystem oilFireParticles;

    public float durationThreshold; // Duration threshold for triggering the effect

    private float timer = 0f;
    private bool isTrayOverPan = false;
    private bool wasTrayOverPan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        timer = 0f;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Oil_Fire"))
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer >= durationThreshold)
            {
                StopFireParticles();
                Debug.Log("Done tray");
                KitchenSceneState.SetPanCovered(true);
            }
        }
    }

    private void StopFireParticles()
    {
        GameObject parentOfOilFire = oilFireParticles.transform.parent.gameObject;
        
        isTrayOverPan = false;
        oilFireParticles.Stop();
        parentOfOilFire.SetActive(false);
    }
}