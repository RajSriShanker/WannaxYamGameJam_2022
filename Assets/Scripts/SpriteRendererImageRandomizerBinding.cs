using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererImageRandomizerBinding : MonoBehaviour
{
    [SerializeField] private Rune[] RunesList;

    private Rune _rune;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Randomize Rune
        _rune = RunesList[Random.Range(0, RunesList.Length - 1)];

        _spriteRenderer.sprite = _rune.Sprite;
    }

    public Rune GetRune()
    {
        return _rune;
    }
}
