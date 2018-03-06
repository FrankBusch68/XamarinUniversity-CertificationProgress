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
