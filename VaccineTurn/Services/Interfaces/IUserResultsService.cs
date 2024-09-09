using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineTurn.Data.DTOs;

namespace VaccineTurn.Services.Interfaces
{
    public interface IUserResultsService
    {
        dynamic[] findCurrentPopGroup();
        int findNumberPeopleAhead(int age);
        UserResultsDto GetUserResults(UsersDto udto, string currentOrTarget);
    }
}
