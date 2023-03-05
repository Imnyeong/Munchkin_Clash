using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update() => transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 7.0f, 0.0f));
}
