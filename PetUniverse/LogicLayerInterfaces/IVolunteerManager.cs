using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Gabi L, Ethan H
    /// This is an inteface for Volunteer logic methods
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 03/12/2020
    /// WHAT WAS CHANGED: Added ChangeVolunteerActiveStatus() method definition
    /// </remarks>
    public interface IVolunteerManager
    {
        bool AddVolunteer(Volunteer volunteer);
        bool UpdateVolunteer(Volunteer oldVolunteer, Volunteer newVolunteer);
        List<string> GetAllSkills();
        List<string> GetVolunteerSkillsByID(int volunteerID);
        List<Volunteer> GetVolunteerByName(string firstName, string lastName);
        List<Volunteer> RetrieveVolunteerListByActive(bool active = true);
        bool AddVolunteerSkill(int volunteerID, string skill);
        bool DeleteVolunteerSkill(int volunteerID, string skill);
        List<Volunteer> GetVolunteerByFirstName(string wholeName);
        bool ChangeVolunteerActiveStatus(bool isChecked, int volunteerID);
        List<Volunteer> GetVolunteersBySkill(string skill);
        bool CreateFoster(Volunteer volunteer, Foster newFoster);
        Foster GetFosterDetailsByVolunteerID(int volunteerID);
        bool UpdateFoster(Foster foster, Foster newFoster);

        bool FindVolunteer(string email);
        int RetrieveVolunteerIDFromEmail(string email);
    }
}
