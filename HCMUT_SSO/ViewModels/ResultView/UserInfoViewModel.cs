namespace HCMUT_SSO.ViewModels.ResultView
{
    public class UserInfoViewModel
    {
        public UserInfoViewModel() { 
            
        }

        public string LastName {  get; set; }
        public string FirstName { get; set; }
        public string Fullname {  get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Type { get; set; }
        //Teacher
        public string TeacherId {  get; set; }
        public string CourseName {  get; set; }
        //Sudent
        public string FacultyName {  get; set; }
        public string StudentId { get; set; }
    }
}
