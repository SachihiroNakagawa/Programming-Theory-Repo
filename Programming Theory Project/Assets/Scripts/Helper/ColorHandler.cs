using UnityEngine;


// Handles setting a color to a given renderer and material slot. Used to simplify coloring our Unit.
// (This can be added on the visual prefab and the Unit code can just query if that component exists to set color)
public class ColorHandler : MonoBehaviour
{
    public Renderer objRenderer;
    
    public Color GetColor()
    {
        return objRenderer.material.GetColor("_Color");
        //var prop = new MaterialPropertyBlock();
        //return prop.GetColor("_BaseColor");
    }

    public void SetColor(Color newColor)
    {
        //var prop = new MaterialPropertyBlock();
        //prop.SetColor("_BaseColor", c);
        objRenderer.material.SetColor("_Color", newColor);
    }
}
