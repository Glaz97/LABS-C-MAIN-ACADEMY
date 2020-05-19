using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_X_Project.Models
{
    [Table("UsersVacancies")]
    public class UsersVacancies
    {
        [Key]
        public int UserVacancyID { get; set; }
        public int UserID { get; set; }
        public string NameOfVacancy { get; set; }

        public UsersVacancies() { }

        public UsersVacancies(int userID, string nameOfVacancy)
        {
            UserID = userID;
            NameOfVacancy = nameOfVacancy;
        }
    }
}