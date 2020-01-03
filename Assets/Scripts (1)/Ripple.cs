using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    public Material RippleMaterial;
    public static float MaxAmount = 30f;

    public float amount = MaxAmount;
    private SpaceShip mH;
    public static bool check = false;
    [Range(0, 1)]
    public float Friction = .9f;

    private float Amount = 0f;

    void Update()
    {
        if (check)
        {
            this.Amount = this.amount;
            Vector3 pos = Input.mousePosition;
            this.RippleMaterial.SetFloat("_CenterX", pos.x);
            this.RippleMaterial.SetFloat("_CenterY", pos.y);
        }

        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
        check = false;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }

    public void ripple()
    {
        check = true;
    }
}
