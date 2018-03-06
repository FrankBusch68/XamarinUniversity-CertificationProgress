using QuickFlicks.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickFlicks.Droid
{
    public class MoviePresenter
    {
        private CancellationTokenSource cts;

        public event Action<IReadOnlyList<Movie>> FilterApplied;

        public async Task FilterMoviesAsync(string search)
        {
            cts?.Cancel();

            if (!string.IsNullOrEmpty(search))
            {
                var innerToken = cts = new CancellationTokenSource();
                var movieService = new MovieService();
                var movies = await movieService.GetMoviesForSearchAsync(search);

                if (!innerToken.IsCancellationRequested)
                {
                    FilterApplied?.Invoke(movies);
                }
            }
            else
            {
                FilterApplied?.Invoke(null);
            }

        }
    }
}