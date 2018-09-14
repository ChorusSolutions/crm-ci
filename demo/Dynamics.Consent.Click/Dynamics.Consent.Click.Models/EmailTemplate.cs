using Chorus.Dynamics.CrmMappers;
using Dynamics.Consent.Click.Models.Constants;
using System;

namespace Dynamics.Consent.Click.Models
{
    [Serializable]
    [CrmEntity(KeyField = EmailTemplateAttributes.IdField)]
    public class EmailTemplate
    {
        [CrmField(FieldName = EmailTemplateAttributes.IdField)]
        public Guid Id{ get; set; }

        [CrmField(FieldName = EmailTemplateAttributes.NameField)]
        public string Name { get; set; }
    }
}