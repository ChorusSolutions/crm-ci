using Dynamics.Consent.Click.Models.Constants;
using System;
using Chorus.Dynamics.CrmMappers;

namespace Dynamics.Consent.Click.Models
{
    [Serializable]
    [CrmEntity(KeyField = SentEmailAttributes.IdField)]
    public class SentEmail
    {
        [CrmField(FieldName = SentEmailAttributes.AccountField)]
        public Guid? Account { get; set; }
        [CrmField(FieldName = SentEmailAttributes.LeadField)]
        public Guid? Lead { get; set; }
        [CrmField(FieldName = SentEmailAttributes.ContactField)]
        public Guid? Contact { get; set; }
        [CrmEntity(JoinName = EmailSendAttributes.Alias, KeyField = SentEmailAttributes.EmailSendField)]
        public EmailSend EmailSend { get; set; }
        [CrmField(FieldName = SentEmailAttributes.IdField)]
        public Guid Id { get; set; }
    }

}
