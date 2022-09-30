using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMenu : MonoBehaviour
{
    [Range(-1f, 2f)]
    [SerializeField] private float scrollSpeed;
    private float scrollOffset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        scrollOffset += (scrollSpeed * Time.deltaTime) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(scrollOffset, 0f));
    }
}
