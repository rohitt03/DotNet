using MySql.Data.MySqlClient;
//using inbuilt, external Object Models


public class Connected{

    public static string conString=@"server=localhost;port=3306;user=root; password=7030524554;database=dotnet";       
    public  static List<User> Display(){
            List<User> allUsers=new List<User>();
            MySqlConnection con=new MySqlConnection(conString);
            try{
                con.Open();
                string query="SELECT * FROM User";
                MySqlCommand cmd=new MySqlCommand(query,con);
                MySqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read()){
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string email = reader["email"].ToString();
                    // DateOnly date;
                    // DateOnly.TryParse( reader["datee"].ToString(),out date);

                    User users=new User(id,name,email);
                    allUsers.Add(users);
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                    con.Close();
            }
            return allUsers;
    }
     public static bool Insert(User u){
        bool status=false;
        string query = "INSERT INTO User(name,email) VALUES('"+u.Name+"','"+u.Email+"')";
                            // Console.WriteLine(query);

        MySqlConnection con = new MySqlConnection(conString);
        try{
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();  //DML
            status = true;
        } 
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }               
        return status;
     }

    public static bool Update(User u)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            string query = "UPDATE User SET name='" + u.Name + "', email='" + u.Email + "' WHERE id=" + u.Id;
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool Delete(int id){
        bool status=false;
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            string query = "DELETE FROM User WHERE id=" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
      return status;
    }

     public  static List<User> GetByName(String nm){
            List<User> allUsers=new List<User>();
            MySqlConnection con=new MySqlConnection(conString);
            try{
                con.Open();
                string query="SELECT * FROM User where name = '"+nm+"'";
                MySqlCommand cmd=new MySqlCommand(query,con);
                MySqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read()){
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string email = reader["email"].ToString();
                    // DateOnly date;
                    // DateOnly.TryParse( reader["datee"].ToString(),out date);

                    User users=new User(id,name,email);
                    allUsers.Add(users);
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                    con.Close();
            }
            return allUsers;
    }

    
    }

