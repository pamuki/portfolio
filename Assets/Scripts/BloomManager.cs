using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomManager : MonoBehaviour
{
    [SerializeField] Volume volume; 
    private Bloom bloomEffect; 

    [SerializeField] float minBloomIntensity = 0.0f;  
    [SerializeField] float maxBloomIntensity = 10.0f; 
    [SerializeField] float flickerSpeed = 1.0f;  

    private float timeElapsed = 0.0f;  
    private float targetBloomIntensity = 0.0f;  
    private float currentBloomIntensity = 0.0f;  

    void Start()
    {
        
        if (volume == null)
        {
            volume = GetComponent<Volume>();
        }

        
        if (!volume.profile.TryGet<Bloom>(out bloomEffect))
        {
            Debug.LogError("Bloom effect not found in the volume profile.");
        }
    }

    void Update()
    {
        
        timeElapsed += Time.deltaTime * flickerSpeed;

        
        targetBloomIntensity = Mathf.Sin(timeElapsed) * (maxBloomIntensity - minBloomIntensity) / 2 + (maxBloomIntensity + minBloomIntensity) / 2;

        
        targetBloomIntensity += Random.Range(-0.1f, 0.1f);

        
        currentBloomIntensity = Mathf.Lerp(currentBloomIntensity, targetBloomIntensity, Time.deltaTime * 2);

        
        if (bloomEffect != null)
        {
            bloomEffect.intensity.Override(Mathf.Clamp(currentBloomIntensity, minBloomIntensity, maxBloomIntensity));
        }
    }
}