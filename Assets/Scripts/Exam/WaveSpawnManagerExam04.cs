using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
    }

    void Update()
    {
        if (currentWave >= waveConfigurations.Length)
        {
            return;
        }

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            Debug.Log("Waves" + currentWave);
            
            if (enableWaveCycling == false)
            {
                if (currentWave >= waveConfigurations.Length)
                {
                    Debug.Log("All waves completed!");
                }
                else
                {
                    waveController.StartWave(waveConfigurations[currentWave]);
                    waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
                }
            }
            else if (enableWaveCycling == true)
            {
                if (currentWave >= waveConfigurations.Length)
                {
                    Debug.Log("All waves completed!");
                    Debug.Log("Star Again");
                    currentWave = 0;
                    waveController.StartWave(waveConfigurations[currentWave]);
                    waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
                }
                else
                {
                    waveController.StartWave(waveConfigurations[currentWave]);
                    waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
                }

            }
        }
    }
}