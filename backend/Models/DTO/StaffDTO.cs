using AngularBigbang.Models.DTO;

namespace AngularBigBang.Models.DTO
{
    public class StaffDTO
    {
        public   List<UserRegisterDTO> staffList { get; set; }
        public object GlobalObject { get; set; }
        public StaffDTO()
        {
            staffList = new List<UserRegisterDTO>();
        }
        /*public void AddStaff(UserRegisterDTO staff)
        {
            staffList.Add(staff);
        }
        */
        public void get(StaffDTO dto) 
        {
            GlobalObject = dto;
        }
        public object GetStaffList()
        {
            return GlobalObject;
        }
    }
}
