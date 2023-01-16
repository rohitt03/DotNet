public class Logic{

    public static List<User> GetUser(){
        return Connected.Display();
    }
    public static void SendUser(User U){
        Connected.Insert(U);
    }

    public static void DeleteUser(int id){
        Connected.Delete(id);
    }

    public static void UpdateUser(User u){
        Connected.Update(u);
    }

    public static List<User> GetUserByName(String name){
        return Connected.GetByName(name);

    }
}