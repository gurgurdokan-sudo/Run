using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 30;
    int currentChipIndex = 0;

    public Transform character;
    public GameObject stageChips;
    public int startChipIndex;
    const int preInstantiate = 5;
    public List<GameObject> generatedStageList = new List<GameObject>();

    void Update()
    {
        int charaPositionIndex = (int)(character.position.z / StageChipSize);
        if (charaPositionIndex + preInstantiate > currentChipIndex)
        {
            GameObject stageObject = (GameObject)Instantiate(
            stageChips,
            new Vector3(0, 0, charaPositionIndex * StageChipSize),
            Quaternion.identity
            );
            generatedStageList.Add(stageObject);
            currentChipIndex++;
            GameObject oldStage = generatedStageList[0];
            generatedStageList.RemoveAt(0);
            Destroy(oldStage);
        }
    }
}
