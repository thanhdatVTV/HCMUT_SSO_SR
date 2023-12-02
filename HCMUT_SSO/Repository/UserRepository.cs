using HCMUT_SSO.Interfaces;
using HCMUT_SSO.Models;
using HCMUT_SSO.ViewModels.ResultView;
using Microsoft.EntityFrameworkCore;

namespace HCMUT_SSO.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HcmutSsoContext _context;
        public UserRepository(HcmutSsoContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> CheckUser(string userName, string password)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var user = await _context.TblUsers.Where(d => d.UserName == userName && d.Password == password).FirstOrDefaultAsync();
                if (user == null)
                {
                    model.status = 0;
                    model.message = "Tài khoản không tồn tại trong hệ thống!";
                }
                else
                {
                    UserInfoViewModel userInfoViewModel = new UserInfoViewModel();
                    if(user.Type == 0)
                    {
                        var student = await (from st in _context.TblStudents.Where(d => d.UserId == user.Id)
                                       join ma in _context.TblMajors on st.MajorId equals ma.Id
                                       join fa in _context.TblFaculties on ma.FacultyId equals fa.Id
                                       select new UserInfoViewModel {
                                            LastName = st.LastName,
                                            FirstName = st.FirstName,
                                            Fullname = st.FullName,
                                            DateOfBirth = st.DateOfBirth,
                                            StudentId = st.StudentId,
                                            FacultyId = fa.Id,
                                            FacultyName = fa.FacultyName
                                        }).FirstOrDefaultAsync();

                        if (student != null)
                        {
                            userInfoViewModel.LastName = student.LastName;
                            userInfoViewModel.FirstName = student.FirstName;
                            userInfoViewModel.Fullname = student.Fullname;
                            userInfoViewModel.StudentId = student.StudentId;
                            userInfoViewModel.FacultyId = student.FacultyId;
                            userInfoViewModel.FacultyName = student.FacultyName;
                            userInfoViewModel.Type = 0;
                        }
                    }
                    else if (user.Type == 1) 
                    {
                        var teacher = await (from te in _context.TblTeachers.Where(d => d.UserId == user.Id)
                                             join co in _context.TblCourses on te.CourseId equals co.Id
                                             select new UserInfoViewModel
                                             {
                                                 LastName = te.LastName,
                                                 FirstName = te.FirstName,
                                                 Fullname = te.FullName,
                                                 DateOfBirth = te.DateOfBirth,
                                                 TeacherId = te.TeacherId,
                                                 CourseId = co.Id,
                                                 CourseName = co.CourseName
                                             }).FirstOrDefaultAsync();
                        if (teacher != null)
                        {
                            userInfoViewModel.LastName = teacher.LastName;
                            userInfoViewModel.FirstName = teacher.FirstName;
                            userInfoViewModel.Fullname = teacher.Fullname;
                            userInfoViewModel.TeacherId = teacher.TeacherId;
                            userInfoViewModel.CourseId = teacher.CourseId;
                            userInfoViewModel.CourseName = teacher.CourseName;
                            userInfoViewModel.Type = 1;
                        }
                    }
                    model.status = 1;
                    model.message = "Tài khoản chính xác!";
                    model.response = userInfoViewModel;
                }
            }
            catch(Exception ex) {
                model.status = -1;
                model.message = "Service không hoạt động " + ex.Message.ToString();
            }
            return model;
        }
    }
}
