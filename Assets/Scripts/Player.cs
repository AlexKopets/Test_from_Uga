using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Player : MonoBehaviour
{
    public Text out_print;
    public InputField height_In;
    public InputField width_In;
    private string[] str = new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    private int width;
    private int height;
    private int ramd;
    private string[,] pr_mat;
    private string[,] mix_mat;


    //перемешивание
    public void Mix()
    { 
        mix_mat = new string[height,width];
        mix_mat = pr_mat;
        for (int i = 0; i <= height-1; i++)//цикл рандомной перемешки
        {
            int randIndex_h = Random.Range(i,height);
            for (int j = 0; j <= width-1; j++)
            {
                int randIndex_w = Random.Range(j,width);
                string carVaol = mix_mat[i,j];
                mix_mat[i,j] = mix_mat[randIndex_h,randIndex_w];
                mix_mat[randIndex_h, randIndex_w] = carVaol;
            }
        }
        out_print.text = "";//очищаем поле Text UI
        StartCoroutine(TextCoroutine());

    }

    //генерация сетки
    public void Generetion()

    {
        out_print.text = "";//очищаем поле Text UI
        width = int.Parse(width_In.text);//получаем введенные значение
        height = int.Parse(height_In.text);
        pr_mat = new string[height, width];//создаем матрицу
       
                
        if (width > 0 & height > 0)//наполняем матрицу
        {
            for(int i=0; i <= height-1; i++)
            {
                for (int j = 0; j <= width-1; j++)
                { ramd = Random.Range(0, 25);
                    pr_mat[i,j] = str[ramd];
                } 
            }
        }
        else
        {
           out_print.text = "Введи параметры сетки!";
        }
        for (int i = 0; i <= height-1; i++)//вывод в Text UI
        {
            for (int j = 0; j <= width-1; j++)
            {
                if (j != width-1)
                {
                    out_print.text += pr_mat[i,j]+" ";
                }
                else
                { if (i!= height-1)
                    {
                        out_print.text += pr_mat[i, j] + "\n";
                    }
                    else
                    {
                        out_print.text += pr_mat[i, j];
                    }
                    
                }
                
                
            }
        }

    }
    IEnumerator TextCoroutine()
    {
        float second_ind=0.0f;
        if (height * width <= 15)
        {
            second_ind = 0.1f;
        }
        if(height * width > 15 & height * width <= 30)
        {
            second_ind = 0.07f;
        }
        if (height * width > 30)
        {
            second_ind = 0.01f;
        }
        for (int i = 0; i <= height - 1; i++)//вывод в Text UI с анимацией
        {
            for (int j = 0; j <= width - 1; j++)
            {
                if (j != width - 1)
                {
                    out_print.text += mix_mat[i, j] + " ";
                    yield return new WaitForSeconds(second_ind);
                }
                else
                {
                    if (i != height - 1)
                    {
                        out_print.text += mix_mat[i, j] + "\n";
                        yield return new WaitForSeconds(second_ind);
                    }
                    else
                    {
                        out_print.text += mix_mat[i, j];
                        yield return new WaitForSeconds(second_ind);
                    }

                }


            }
        }
    }
}
