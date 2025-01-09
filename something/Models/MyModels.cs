using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;

namespace something.Models
{
    public class Gifted_grant
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public string? grant_name { get; set; }

        public int grant_value { get; set; }
    }
    public class Faculty
    {
        public string? faculty_name { get; set; }
        public string? group_name { get; set; }
        public int year_of_admission { get; set; }
        [Key] public int group_id { get; set; }

    }
    public class Grade
    {
        public int id { get; set; }
        public string? Subject { get; set; }
        public int grade_ { get; set; }
        public bool Iscredit { get; set; }
        public int lecturer_id { get; set; }
    }
    public class Grant_info
    {
        [Key] public int grant_name_id { get; set; }
        public string? grant_name { get; set; }
        public int banch_grant_value { get; set; }
        public int master_grant_value { get; set; }
        public int aspirant_grant_value { get; set; }
    }

    public class Lecturer
    {
        [Key]public int id { get; set; }
        public string? name { get; set; }

        public string? surname { get; set; }
        public string? father_name { get; set; }
        public string? department { get; set; }
    }
    public class Student
    {
        [Key]public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? father_name { get; set; }

        public int semester { get; set; }
        public string? degree { get; set; }
        public int group { get; set; }
    }
}

