using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private Rune _selectedRune = null;

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
        print($"New rune selected with id {rune.Id}");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Rune rune = other.GetComponent<SpriteRendererImageRandomizerBinding>().GetRune();
            Destroy(other.gameObject);
            OnPickup(rune);
        }
    }
}
