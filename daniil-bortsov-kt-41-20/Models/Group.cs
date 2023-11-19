using System.Text.RegularExpressions;

namespace daniil_bortsov_kt_41_20.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"^[А-Я]*-[0-9]{2}-[0-9]{2}$").Success;
        }
    }
}
