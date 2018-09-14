using Dynamics.Consent.Click.Data.ModelRepository;
using Dynamics.Consent.Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Services
{
    public class ClickDimensionsEmailRetriever
    {
        private IRepository<SentEmail> _sentEmailRepository { get; set; }

        public ClickDimensionsEmailRetriever(IRepository<SentEmail> sentEmailRepository)
        {
            _sentEmailRepository = sentEmailRepository;
        }

        public Guid? GetTemplateId(Guid sentEmailId)
        {
            SentEmail sentEmail = _sentEmailRepository.Get(sentEmailId);

            return sentEmail.EmailSend?.EmailTemplate;
            
        }
    }
}
