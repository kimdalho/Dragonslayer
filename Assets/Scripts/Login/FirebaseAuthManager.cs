using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;   
    }

    public TMP_Text email;
    public TMP_Text userName;
    public TMP_Text password;
    public GameObject notFoundLabel;
    private bool isLogin;
    private bool isFaultedAuth;
  
    public void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(t =>
        {
            if (t.IsCanceled)
            {
                Debug.Log("Cancle");
                return;
            }
            if (t.IsFaulted)
            {
              
            }
            Debug.Log("계정 생성");

            this.gameObject.SetActive(false);
        });
    }

    public void Login()
    {

        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(t =>
        {
            

            if (t.IsCanceled)
            {
                Debug.Log("Cancle");
                
                return;
            }
            else if (t.IsFaulted)
            {
                Debug.Log("실패");
                isFaultedAuth = true;
                
                return;
            }

            isLogin = true;
            PlayerPrefs.SetString("FirstLoginID", email.text);
            PlayerPrefs.SetString("FirstLoginPWD", password.text);
            FirebaseUser newUser = t.Result;
            
        });
        
    }
    
    private void Update() 
    {
        if (isLogin)
        {
            SceneContianer.Instance.LoadScene(eScenes.LobbyScene);
        }
        else if(isFaultedAuth)
        {
            notFoundLabel.gameObject.SetActive(true);
            isFaultedAuth = false;
        }
    }   

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
    }

}
