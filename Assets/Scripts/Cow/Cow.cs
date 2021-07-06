using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cow : MonoBehaviour
{
    [SerializeField] CowManager cowManager;
    public int foodLevel = 3;
    [SerializeField] float foodLevelDecreaseRate = 10f;

    int familyID;
    [SerializeField] TextMeshProUGUI familyIDText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDecrease());
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 0.1f + (foodLevel * 0.1f);
        this.transform.localScale = new Vector3(scale, scale, scale);

        if (foodLevel >= 6)
            cowManager.SpawnOffspring(this.gameObject);
            
    }

    public void IncreaseFoodLevel()
    {
        foodLevel++;
    }

    void DecreaseFoodLevel()
    {
        foodLevel--;
        if (foodLevel <= 0)
            Destroy(this.gameObject);
    }

    public void SetFamilyID(int id)
    {
        familyID = id;
        familyIDText.text = familyID.ToString();
    }

    public int GetFamilyID()
    {
        return familyID;
    }

    IEnumerator WaitToDecrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(foodLevelDecreaseRate); // waits x seconds before executing next line of code
            DecreaseFoodLevel();
        }
    }
}
