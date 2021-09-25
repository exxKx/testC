using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public GameObject currentSection;
    public GameObject barrier;
    public float yOfBarrier;
    private GameObject prevSection;

    private float sectionWidth;
    private bool spawnSection = true;
    private int barriersSize = 3;
    private List<GameObject> currentBarriers = new List<GameObject>();
    private List<GameObject> prevBarriers = new List<GameObject>();

    void Start()
    {
        sectionWidth = currentSection.GetComponent<Renderer>().bounds.size.x;
    }


    void Update()
    {
        if (prevSection != null && transform.position.x > prevSection.transform.position.x + sectionWidth)
        {
            if (prevBarriers.Count > 0)
                foreach (var obj in prevBarriers)
                {
                    Destroy(obj);
                }

            Destroy(prevSection);
            spawnSection = true;
        }

        if (spawnSection && transform.position.x >= currentSection.transform.position.x)
        {
            spawnSection = false;

            prevBarriers = currentBarriers;
            prevSection = currentSection;

            currentSection = Instantiate(prevSection, prevSection.transform.parent);
            var nextSectionX = new Vector3(
                prevSection.transform.position.x + sectionWidth,
                prevSection.transform.position.y);

            currentSection.transform.position = nextSectionX;

            SpawnBarriers(barriersSize);
        }
    }

    private void SpawnBarriers(int size)
    {
        float nextSectionStartX = currentSection.transform.position.x - (sectionWidth / 2);
        float xRandomItemWidth = sectionWidth / size;

        currentBarriers = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            int randomNewSectionX = Random.Range((int) nextSectionStartX, (int) (nextSectionStartX += xRandomItemWidth));
            GameObject createdBarrier = Instantiate(barrier);

            currentBarriers.Add(createdBarrier);

            createdBarrier.transform.position = new Vector3(randomNewSectionX, yOfBarrier);
        }
    }
}