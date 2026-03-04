using UnityEngine;

public class PlantController : MonoBehaviour
{
    [Header("Settings")]
    public float timePerStage = 5f; // time duration

    [Header("Visual Models")]
    public GameObject seedModel;     // fade 1
    public GameObject seedlingModel; // fade 2
    public GameObject matureModel;   // fade 3

    private int currentStage = 1;
    private float timer = 0;
    private bool isFullyGrown = false;

    void Start()
    {
        UpdateVisuals(); // show seed
    }

    void Update()
    {
        if (isFullyGrown) return;

        timer += Time.deltaTime;
        if (timer >= timePerStage)
        {
            Grow();
        }
    }

    void Grow()
    {
        currentStage++;
        timer = 0;
        UpdateVisuals();

        if (currentStage >= 3) isFullyGrown = true;
    }

    void UpdateVisuals()
    {
        if (seedModel) seedModel.SetActive(currentStage == 1);
        if (seedlingModel) seedlingModel.SetActive(currentStage == 2);
        if (matureModel) matureModel.SetActive(currentStage == 3);
    }
}