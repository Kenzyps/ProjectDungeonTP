using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // diferença entre a posição da camera e a posição do objeto no eixo x
        // isso dara um resultado de meio termo entre a posição x da camera e a posição x do objeto
        float deltaX = lookAt.position.x - transform.position.x;


        // se essa diferença for maior do que um limite (ou menor do que um limite)
        if (deltaX > boundX || deltaX < -boundX)
        {
            // se a camera estiver para a esquerda do objeto
            if (transform.position.x < lookAt.position.x)
            {
                // a minha camera na posicao x (delta.x) recebe (a diferença do eixo x da camera e o eixo x do objeto) - (limite de movimento)
                // sem a subtração de deltax - boundX, a posição x da minha camera pode ultrapassar o limite causando travamentos
                // com a subtração, posso garantir que a posição x vai sempre ficar um pouco atrás do limite exato
                delta.x = deltaX - boundX;
            }
            // mesma coisa so que se a camera estiver para a direita
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        // atribuindo o valor para a posição da minha camera
        transform.position += new Vector3(delta.x, delta.y, 0);
    }

}
