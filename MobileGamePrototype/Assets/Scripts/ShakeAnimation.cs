using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAnimation : MonoBehaviour
{
    public Animator camAnim;

    public void ShakeCam()
    {
        camAnim.SetTrigger("Shake");
    }
}
