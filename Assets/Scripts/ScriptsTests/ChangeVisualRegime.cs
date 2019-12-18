using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisualRegime : MonoBehaviour
{
    public Sprite Sprite;
    public Material spriteMaterial;
    public Mesh mesh;
    public Material poligonMaterial;
    public Collider2D col;

    bool _spriteMode = true;
    void Start()
    {

    }

    private void Update() {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(!_spriteMode)
            {
                SpriteVisualization();
            }
            else
            {
                PoliginVisualization();
            }  
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10f);
        }
        //transform.Rotate(Vector3.left);   
    }

    private void PoliginVisualization()
    {
       DestroyImmediate(gameObject.GetComponent<SpriteRenderer>());
       MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
       meshRenderer.material = poligonMaterial;
       MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
       meshFilter.mesh = mesh;
       transform.localScale = new Vector3(0.3f,0.3f,0.3f);
       transform.Rotate(new Vector3(0, 0, 0));
       _spriteMode = false;
    }

    private void SpriteVisualization()
    {
        DestroyImmediate(gameObject.GetComponent<MeshRenderer>());
        DestroyImmediate(gameObject.GetComponent<MeshFilter>());
        gameObject.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Sprite;
        transform.localScale = new Vector3(10, 10, 10);
        transform.Rotate(new Vector3(0, 0, 180));
        _spriteMode = true;
    }

    private void ReactivateObject()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}



        //gameObject.AddComponent<SpriteRenderer>();
        //SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        //sr.sprite = sprite;
        //Destroy(gameObject.GetComponent<SpriteRenderer>());
       // gameObject.SetActive(false);
        //gameObject.SetActive(true);

