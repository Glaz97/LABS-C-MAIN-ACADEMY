using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_X_Project.Models
{
    [Table("UsersContactData")]
    public class UsersContactData
    {
        [Key]
        public int ContactDataID { get; set; }
        public int UserID { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public UsersContactData() { }

        public UsersContactData(int userID, string phoneNumber, string adress)
        {
            UserID = userID;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
    }
}