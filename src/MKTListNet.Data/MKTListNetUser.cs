using Microsoft.AspNetCore.Identity;

namespace MKTListNet.Infra
{
    // Add profile data for application users by adding properties to the MKTListNetUser class
    public class MKTListNetUser : IdentityUser
    {
        /// <summary>
        /// Full name.
        /// </summary>
        [ProtectedPersonalData]
        public string? FullName { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Date on create record.
        /// </summary>
        public DateTime? CreateOn { get; set; }
    }
}
