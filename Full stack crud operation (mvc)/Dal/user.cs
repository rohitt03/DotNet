
public class User{
    public int Id{set;get;}
    public string Name{set;get;}
    public string Email{set;get;}
    // public DateOnly Date{set;get;}
    public static int tempid=1;
    
    public User(String name,String email){
        this.Id=tempid;
        this.Email=email;
        this.Name=name;
       // this.Date=date;
        tempid++;
    }
      public User(int id,String name,String email){
        this.Id=id;
        this.Email=email;
        this.Name=name;
        //this.Date=date;
        tempid++;
    }
    public User(){

    }
    public override string ToString()
    {
        return Id+"  "+Name+" "+Email;
    }


}