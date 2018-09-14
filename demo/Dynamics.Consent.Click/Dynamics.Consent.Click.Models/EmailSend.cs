using Chorus.Dynamics.CrmMappers;
using Dynamics.Consent.Click.Models.Constants;
using System;

namespace Dynamics.Consent.Click.Models
{
    [Serializable]
    [CrmEntity(KeyField = EmailSendAttributes.IdField)]
    public class EmailSend
    {
        [CrmField(FieldName = EmailSendAttributes.IdField)]
        public Guid Id { get; set; }

        [CrmField(FieldName = EmailSendAttributes.Templatefield)]
        public Guid? EmailTemplate { get; set; }
        
    }
}