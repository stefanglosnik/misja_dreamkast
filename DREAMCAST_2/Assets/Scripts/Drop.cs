using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject drop;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "Default";
        spriteRenderer.sortingOrder = 0;
        drop.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dropnelo()
    {
        drop.transform.localScale = new Vector3(1f, 1f, 1f);
        spriteRenderer.sortingLayerName = "UI";
        spriteRenderer.sortingOrder = 1;

    }
}
