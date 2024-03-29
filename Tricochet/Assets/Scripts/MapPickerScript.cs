using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickerScript : MonoBehaviour
{

    List<int> MapPickerList;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        MapPickerList = new List<int>();
        for (int i = 2; i <= 6; ++i)
        {
            MapPickerList.Add(i);
        }

        for(int i = 0; i < MapPickerList.Count; i++)
        {
            Debug.Log(MapPickerList[i]);
        }
    }

    public int RandomMap()
    {
        //fix all this shit!!!!!!!!!!!!!!!!!!!!!!
        //zero is out of bounds for some reason???????
        int PickedCardIndex = Random.Range(0, MapPickerList.Count);
        Debug.Log("Map PickedIndex: " + PickedCardIndex);
        Debug.Log("Map PickedNum: " + MapPickerList[PickedCardIndex]);
        int PickedCard = MapPickerList[PickedCardIndex];
        MapPickerList.RemoveAt(PickedCardIndex);
        Debug.Log(PickedCard + "");
        return PickedCard;

        if (MapPickerList.Count <= 0) return 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
