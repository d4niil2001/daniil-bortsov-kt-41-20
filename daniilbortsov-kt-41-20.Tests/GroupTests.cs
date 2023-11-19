using daniil_bortsov_kt_41_20.Models;
namespace daniilbortsov_kt_41_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4120_True()
        {
            var testGroup = new Group
            {
                GroupName ="สา-41-20"
            };
            
            var reesult = testGroup.IsValidGroupName();

            Assert.True(reesult);
           

        }
    }
}