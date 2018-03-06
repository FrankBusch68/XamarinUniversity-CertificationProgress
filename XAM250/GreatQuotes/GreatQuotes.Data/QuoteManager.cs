using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {
        public static QuoteManager Instance { get; private set; }

        readonly IQuoteLoader repo;
        public IList<GreatQuote> Quotes;
        
        private QuoteManager()
        {
            this.Quotes = new ObservableCollection<GreatQuote>();
            repo = QuoteLoaderFactory.Create();

            Quotes = repo.Load().ToList();

        }

        public QuoteManager(IQuoteLoader loader)
        {
            if (Instance != null)
                throw new Exception("Can only create a single QuoteManager.");
            Instance = this;
            this.repo = loader;
            Quotes = new ObservableCollection<GreatQuote>(loader.Load());
        }


        public void SayQuote(GreatQuote quote)
        {
            if (quote == null)
                throw new ArgumentNullException("quote");

            ITextToSpeech tts = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            var text = quote.QuoteText;

            if (!string.IsNullOrWhiteSpace(quote.Author))
                text += $" by {quote.Author}";

            tts.Speak(text);

        }

        public void Save()
        {
            repo.Save(Quotes);
        }
    }
}
