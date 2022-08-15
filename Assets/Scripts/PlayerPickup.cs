using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private Rune _selectedRune = null;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public PlayerRuneSelection playerRuneSelectionScript;

    private void Start()
    {
        playerRuneSelectionScript = GetComponent<PlayerRuneSelection>();
    }

    public Rune GetSelectedRune()
    {
        return _selectedRune;
    }

    public void ClearSelectedRune()
    {
        _selectedRune = null;
    }
    
    private void OnPickup(Rune rune)
    {
        _selectedRune = rune;
        _spriteRenderer.sprite = _selectedRune.Sprite;
        playerRuneSelectionScript.playerRune = _selectedRune.Id;
        //print($"New rune selected with id {rune.Id}");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            ClearSelectedRune();
            Rune rune = other.GetComponent<SpriteRendererImageRandomizerBinding>().GetRune();
            Destroy(other.gameObject);
            OnPickup(rune);
        }
    }
}
