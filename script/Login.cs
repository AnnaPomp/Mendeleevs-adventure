using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
[SerializeField] private string LoginEndpint="http://localhost:13756/auth/login";
[SerializeField] private string CreateEndpoint="http://localhost:13756/auth/create";

   [SerializeField] private TMPro.TMP_InputField usernameInputField;
   [SerializeField] private TMPro.TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;
        [SerializeField] private Button createButton;
        [SerializeField] private string targetSceneName = "Login";
    
       

    public void LoadTargetScene()
    {
        if(targetSceneName=="Login")
        SceneManager.LoadScene(targetSceneName);
        else 
        SceneManager.LoadScene("Tutorial");
    }
   public void OnLoginClick()
   {
        alertText.text="Signing in...";
          ActivateButtons(false);
   StartCoroutine(TryLogin());

   }
  public void aidja()
   {
    SceneManager.LoadScene("Login");
   }
 public void OnCreateClick()
   {
        alertText.text="Creare cont...";
      ActivateButtons(false);
   StartCoroutine(TryCreate());
   }
private IEnumerator TryLogin(){

    string username=usernameInputField.text;
    string password=passwordInputField.text;
    if(username.Length<3||username.Length>24)
    {
        alertText.text="Username invalid";
        loginButton.interactable=true;

        yield break;
    }
     if(password.Length<4||password.Length>24)
    {
        alertText.text="Parolă invalidă";
        loginButton.interactable=true;
        
        yield break;
    }
WWWForm form =new WWWForm();
form.AddField("rUsername", username);
form.AddField("rPassword", password);

UnityWebRequest request = UnityWebRequest.Post(LoginEndpint,form);
var handler=request.SendWebRequest();
float startTime=0.0f;
while(!handler.isDone)
{
    startTime+=Time.deltaTime;
    if(startTime>10.0f)
    {
        break;
    }
    yield return null;
}

if(request.result==UnityWebRequest.Result.Success)
{
    if(request.downloadHandler.text!="Invalid credentials")
    {

      ActivateButtons(false);
       GameAccount returnAccount= JsonUtility.FromJson<GameAccount>(request.downloadHandler.text);
       alertText.text= "Bine ai venit "+ returnAccount.username;
       LoadTargetScene();
    }
    else 
    {
     alertText.text="Invalid credentials";
 ActivateButtons(true);  
    }
    
}
else 
{
      alertText.text="Eroare conectare la server..";
    ActivateButtons(true);
}

  
    yield return null;
}

private void ActivateButtons(bool toggle){
 createButton.interactable=toggle;
    loginButton.interactable=toggle;
}
private IEnumerator TryCreate(){

    string username=usernameInputField.text;
    string password=passwordInputField.text;
    if(username.Length<3||username.Length>24)
    {
        alertText.text="Username invalid";
       ActivateButtons(true);
        yield break;
    }
     if(password.Length<4||password.Length>24)
    {
        alertText.text="Parolă invalidă";
      ActivateButtons(true);
        yield break;
    }
WWWForm form =new WWWForm();
form.AddField("rUsername", username);
form.AddField("rPassword", password);

UnityWebRequest request = UnityWebRequest.Post(CreateEndpoint,form);
var handler=request.SendWebRequest();
float startTime=0.0f;
while(!handler.isDone)
{
    startTime+=Time.deltaTime;
    if(startTime>10.0f)
    {
        break;
    }
    yield return null;
}

if(request.result==UnityWebRequest.Result.Success)
{
    if(request.downloadHandler.text!="Invalid credentials"&&request.downloadHandler.text!="Username deja luat!")
    {

      
       GameAccount returnAccount= JsonUtility.FromJson<GameAccount>(request.downloadHandler.text);
       alertText.text= "Contul a fost creat";
       LoadTargetScene();
      
    }
    else 
    {
     alertText.text="Username deja luat!";
       

    }
    
}
else 
{
      alertText.text="Eroare conectare la server..";
  
  
}
ActivateButtons(true);
    yield return null;
}
}
