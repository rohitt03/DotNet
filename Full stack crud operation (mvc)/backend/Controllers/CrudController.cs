using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

public class CrudController : Controller
{
    private readonly ILogger<CrudController> _logger;

    public CrudController(ILogger<CrudController> logger)
    {
        _logger = logger;
    }
   

    public static Boolean flag=false;
    public static List<User> temp;
    public IActionResult Display()
    {
        if(flag==false){
             List<User> users=Logic.GetUser();
             ViewData["display"]=users;
        }else{
            ViewData["display"]=temp;
            flag=false;
        }
       
        return View();
    }

       public IActionResult insert()
    {   
        return View();
    }

     

    public IActionResult insert2(String name,String email)
    {
        // Console.WriteLine("------------------------------------");
        //             Console.WriteLine("------------------------------------");
        //             Console.WriteLine("------------------------------------");
        //             Console.WriteLine("------------------------------------");
        //             Console.WriteLine(name+" "+email);
            Logic.SendUser(new User(name,email));
            return Redirect("/Home/Index");
    }
  public IActionResult delete()
    {   
        return View();
    }
    public IActionResult delete2(int id)
    {   
        Logic.DeleteUser(id);
        return Redirect("/Home/Index");
    }
      public IActionResult update()
    {   
        return View();
    }
      public IActionResult update2(int id,string name,string email)
    {   
        Logic.UpdateUser(new User(id,name,email));
        return Redirect("/Home/Index");
    }
        public IActionResult getbyname()
    {   
        return View();
    }
         public IActionResult getbyname2(String name)
    {   
        
        flag=true;
        temp=Logic.GetUserByName(name);
        return Redirect("/crud/display");
    }
   
}
