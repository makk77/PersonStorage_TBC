using PersonStorage.Core.Application.Commons.Paging;
using PersonStorage.Core.Application.DTOs.Attributes;
using PersonStorage.Core.Application.DTOs.Filtering;
using PersonStorage.Core.Domain.Models;

namespace PersonStorage.Infrastructure.Persistence.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<Person> ApplyFilterParameters(this IQueryable<Person> source, PeopleFilter peopleFilter)
    {
        if (peopleFilter == null)
        {
            return source;
        }

        if (!string.IsNullOrEmpty(peopleFilter.FirstName?.Trim()))
        {
            source = source.Where(x => x.FirstName.StartsWith(peopleFilter.FirstName));
        }

        if (!string.IsNullOrEmpty(peopleFilter.LastName?.Trim()))
        {
            source = source.Where(x => x.LastName.StartsWith(peopleFilter.LastName));
        }

        if (!string.IsNullOrEmpty(peopleFilter.PeronalNumber?.Trim()))
        {
            source = source.Where(x => x.PersonalNumber.StartsWith(peopleFilter.PeronalNumber));
        }

        if (peopleFilter.BirthDate.HasValue)
        {
            source = source.Where(x => x.BirthDate.Date == peopleFilter.BirthDate.Value.Date);
        }

        if (peopleFilter.CityId > 0)
        {
            source = source.Where(x => x.CityId == peopleFilter.CityId);
        }

        if (peopleFilter.HasPhoto.HasValue)
        {
            if (peopleFilter.HasPhoto.Value)
            {
                source = source.Where(x => (x.PhotoPath == null || x.PhotoPath == ""));
            }
            else
            {
                source = source.Where(x => !(x.PhotoPath == null || x.PhotoPath == ""));
            }

        }

        if (!string.IsNullOrEmpty(peopleFilter.City?.Trim()))
        {
            source = source
                .Where(x => x.City.Name.StartsWith(peopleFilter.City));
        }

        if (!string.IsNullOrEmpty(peopleFilter.RelatedPersonFirstName?.Trim()))
        {
            source = source
                .Where(r => r.RelatedPeople.Any(x => x.RelatedPerson.FirstName.StartsWith(peopleFilter.RelatedPersonFirstName)));
        }

        if (!string.IsNullOrEmpty(peopleFilter.RelatedPersonLastName?.Trim()))
        {
            source = source
                .Where(r => r.RelatedPeople.Any(x => x.RelatedPerson.LastName.StartsWith(peopleFilter.RelatedPersonLastName)));
        }

        if (!string.IsNullOrEmpty(peopleFilter.RelatedPersonPn?.Trim()))
        {
            source = source
                .Where(r => r.RelatedPeople.Any(x => x.RelatedPerson.PersonalNumber.StartsWith(peopleFilter.RelatedPersonPn)));
        }

        return source;
    }

    public static IQueryable<Person> GetQuickSearchData(this IQueryable<Person> source, PeopleQuickFilter peopleFilter = null)
    {
        if (peopleFilter == null)
        {
            return source;
        }
        source = source.Where(x =>
            (string.IsNullOrEmpty(peopleFilter.FirstName) || x.FirstName.Contains(peopleFilter.FirstName)) &&
            (string.IsNullOrEmpty(peopleFilter.LastName) || x.LastName.Contains(peopleFilter.LastName)) &&
            (string.IsNullOrEmpty(peopleFilter.PeronalNumber) || x.PersonalNumber.StartsWith(peopleFilter.PeronalNumber))
            );
        return source;
    }
}
