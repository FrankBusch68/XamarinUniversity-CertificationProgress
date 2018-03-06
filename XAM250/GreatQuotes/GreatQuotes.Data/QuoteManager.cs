using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {

        public static QuoteManager Instance { get; } = new QuoteManager();

        readonly IQuoteLoader repo;
        public IList<GreatQuote> Quotes;
        
        private QuoteManager()
        {
            this.Quotes = new ObservableCollection<GreatQuote>();
            repo = QuoteLoaderFactory.Create();

            Quotes = repo.Load().ToList();

        }

        public void Save()
        {
            repo.Save(Quotes);
        }
    }
}
