using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class Spawner : MonoBehaviour
{
	public Transform spawnPoint;
 //    public GameObject p1,p2,p3,p4,p5;
	// GameObject[] p = new GameObject();
	public float spawnRate = 2f;
    string[] colour = new string[]{"RedButton","GreenButton","BlueButton","OrangeButton","PinkButton"};
	int whatToSpawn;
	List<string> list = new List<string>();
    int[] pattern1 = {1,2,1,4};
    string ans;
   
    public List<GameObject> p = new List<GameObject>();
    
    public GameObject Con;

    
    //for int i = 0 till(<) 3
    /*take k = 0 
    make(pattern1[0])
        Instantiate (p[0] , spawnPoint.position , Quaternion.identity);
        list.Add(colour[0]);
    make(pattern1[1])
    make(pattern1[2])
    k++;
    if(k=3) goto y;
    make(pattern1[3])
    //for end
    y:

    */

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ace");
    }


    IEnumerator Ace()
    {
         int k=0;
        for(int i=0;i<3;i++)
        {
            
            MakeBox(pattern1[0]);
              yield return new WaitForSeconds(spawnRate);
            MakeBox(pattern1[1]);
              yield return new WaitForSeconds(spawnRate);
            MakeBox(pattern1[2]);
              yield return new WaitForSeconds(spawnRate);
            k++;
            if(k==3)
            {
                break;//**This is where the door closes**
            }
            else
            {
                MakeBox(pattern1[3]);
                  yield return new WaitForSeconds(spawnRate);

            }
        }
        foreach(string s in list) 
        {
            Debug.Log(s);
        }

        Con.SetActive(true);


        //When Success!
            //Needs work 
        if(ans == colour[pattern1[3]])
        {
            Debug.Log("Success!");
        }

    }
    



    /*Logic Function
    Should make a series of numbers with {1,2,3} only(Or atleast the result should be these 3 no.s)
    Let's make it simple
    List = {1,2,3};

    pattern 1 = {(1214)(1214)....}
    pattern 2 = {(3124)(3124)....}
    pattern 3 = {(232)(232)....}
    pattern 4 = {(131)(131)....}
    pattern 5 = {(3212)(3212)....}
    pattern 6 = {(1231)(1231)....}
    pattern 7 = {(3121)(3121)....}
    pattern 8 = {()()....}
    pattern 9 = {()()....}
    pattern10 = {()()....}
    pattern11 = {()()....}

    */



    
    public void MakeBox(int x)
    {
        Instantiate (p[x] , spawnPoint.position , Quaternion.identity); 
        list.Add(colour[x]);
    }




    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void ToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void BtnTest()
    {
        ans = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(ans);
    }
}






   

    /*Make parttern1
    StartCoroutine("Ace");
    make1(Instas)
    yield return new WaitForSeconds(2f);
    make2(Instas)

    public void MakeP1(pattern1)
    {
        
        int k=0;
        for(int i=0;i<3;i++)
        {
            
            MakeBox(parttern1[0]);
            MakeBox(parttern1[1]);
            MakeBox(parttern1[2]);
            k++;
            if(k=3)
            {break;}
            else
            {MakeBox(parttern1[3]);}
        }
    } 


    */


    
    
      

    
    /*
    public void MakeRed()
    {
        Instantiate (p1 , spawnPoint.position , Quaternion.identity);
        list.Add("red");
    }
    public void MakeGreen()
    {
        Instantiate (p2 , spawnPoint.position , Quaternion.identity);
        list.Add("green");
    }
    public void MakeBlue()
    {
        Instantiate (p3 , spawnPoint.position , Quaternion.identity);
        list.Add("blue");
    }
    public void MakeOrange()
    {
        Instantiate (p4 , spawnPoint.position , Quaternion.identity);
        list.Add("orange");
    }
    public void MakePink()
    {
        Instantiate (p5 , spawnPoint.position , Quaternion.identity);
        list.Add("pink");
    }
    */

    // Update is called once per frame
    // void Update()
    // {
        // if(Time.time > nextSpawn)
        // {
        //     randomNum = Random.Range(1,3);//excludes 3 
        //     if(randomNum==1)
        //     {
        //         //pattern 1 = {(1214)(1214)(1214)}
        //         // create 1214 1214 121
        //         int k=0;
        //         for(int i=0;i<3;i++)
        //         {
        //             Instantiate (p1 , spawnPoint.position , Quaternion.identity);
        //             list.Add("red");
        //             //1

        //             Instantiate (p2 , spawnPoint.position , Quaternion.identity);
        //             list.Add("green");
        //             //2

        //             Instantiate (p1 , spawnPoint.position , Quaternion.identity);
        //             list.Add("red");
        //             //1
        //             if(k<2)
        //             {
        //                 Instantiate (p4 , spawnPoint.position , Quaternion.identity);
        //                 list.Add("orange");
        //                 //4
        //                 k++;
        //             }
        //         }
        //     }
        //     else if(randomNum==2)
        //     {
        //         //pattern 2 = {(3124)(3124)(3124)}
        //         //create 3124 3124 312
        //         int k=0;
        //         for(int i=0;i<3;i++)
        //         {
        //             Instantiate (p3 , spawnPoint.position , Quaternion.identity);
        //             list.Add("blue");
        //             //3

        //             Instantiate (p1 , spawnPoint.position , Quaternion.identity);
        //             list.Add("red");
        //             //1

        //             Instantiate (p2 , spawnPoint.position , Quaternion.identity);
        //             list.Add("green");
        //             //2

        //             if(k<2)
        //             {
        //                 Instantiate (p4 , spawnPoint.position , Quaternion.identity);
        //                 list.Add("orange");
        //                 //4
        //                 k++;
        //             }
        //         }
        //     }
            



        // 	whatToSpawn = Random.Range (1,6);//Need to change as i dont want random. Probably a function call(Logic Function)
        // 	Debug.Log(whatToSpawn);



        // 	switch(whatToSpawn)
        // 	{
        // 		case 1:
        // 			Instantiate (p1 , spawnPoint.position , Quaternion.identity);
        // 			list.Add("red");
        // 			break;
        // 		case 2:
        // 			Instantiate (p2 , spawnPoint.position , Quaternion.identity);
        // 			list.Add("green");
        // 			break;
        // 		case 3:
        // 			Instantiate (p3 , spawnPoint.position , Quaternion.identity);
        // 			list.Add("blue");
        // 			break;
        //         case 4:
        //             Instantiate (p4 , spawnPoint.position , Quaternion.identity);
        //             list.Add("orange");
        //             break;
        //         case 5:
        //             Instantiate (p5 , spawnPoint.position , Quaternion.identity);
        //             list.Add("pink");
        //             break;
        // 	}
        // 	nextSpawn = Time.time + spawnRate;
        // 	foreach(string s in list) 
        // 	{
        // 		Debug.Log(s);
        // 	}
        // }
    //}

    

    
//}
