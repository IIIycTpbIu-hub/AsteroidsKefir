using UnityEngine;

/// <summary>
/// Переключает режимы визуальных представлений
/// </summary>
public class VisualRegimeChanger : MonoBehaviour
{
    public Sprite Sprite;
    public Material spriteMaterial;
    public Mesh mesh;
    public Material poligonMaterial;
    public Collider2D col;


    bool _isSpriteMode = true;
    void Start()
    {
        GameManager.Instanse.GameEventSystem.SwitchDisplayMode += OnSwitchDisplayMode;
    }

    private void OnBecameVisible() {
        bool newIsSpriteMode = GameManager.Instanse.GetPoligonalView();
        if(_isSpriteMode != newIsSpriteMode)
        {
            OnSwitchDisplayMode(newIsSpriteMode);
        }
    }

    private void PoliginVisualization()
    {
       DestroyImmediate(gameObject.GetComponent<SpriteRenderer>());
       MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
       meshRenderer.material = poligonMaterial;
       MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
       meshFilter.mesh = mesh;
    }

    private void SpriteVisualization()
    {
        DestroyImmediate(gameObject.GetComponent<MeshRenderer>());
        DestroyImmediate(gameObject.GetComponent<MeshFilter>());
        gameObject.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Sprite;
    }

      private void OnSwitchDisplayMode(bool isSpriteMode)
    {
        if(isSpriteMode)
        {
            SpriteVisualization();
        }
        else
        {
            PoliginVisualization();
        }
        _isSpriteMode = isSpriteMode;
    }
}

