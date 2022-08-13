using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererImageRandomizerBinding : MonoBehaviour
{
    [SerializeField] private Rune[] RunesList;

    private SpriteRenderer _spriteRenderer; 

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Randomize Rune
        Rune rune = RunesList[Random.Range(0, RunesList.Length - 1)];

        _spriteRenderer.sprite = rune.Sprite;
    }
}
