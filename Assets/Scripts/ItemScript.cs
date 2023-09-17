using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject item;
    public float duration;
    void Start()
    {
        duration = 7;
        
    }

    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            float xPos = Random.Range(-5, 5);
            this.transform.position = new Vector3(xPos, 11, 0);
            duration = 12;
            Instantiate(item, this.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
