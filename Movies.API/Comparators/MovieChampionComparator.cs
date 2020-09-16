using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Movies.API.Models;

namespace Movies.API.Comparators
{
    public class MovieChampionComparator : IComparer<Movie>
    {
        public int Compare([AllowNull] Movie movie1, [AllowNull] Movie movie2)
        {
            int compare1 = movie2.Nota.CompareTo(movie1.Nota);

            if(compare1 == 0)
            {
                return movie1.Titulo.CompareTo(movie2.Titulo);
            }

            return compare1;
        }

        public static MovieChampionComparator sortChampion()
        {
            return new MovieChampionComparator();
        }
    }
}
