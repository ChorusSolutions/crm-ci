using Dynamics.Consent.Click.Models.Constants;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Dynamics.Consent.Click.Data.Queries
{
    internal class SentEmailQuery
    {
        private readonly Guid _sentEmailId;
        public SentEmailQuery(Guid sentEmailId)
        {
            if (sentEmailId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(sentEmailId)} must have a value.");
            }
            _sentEmailId = sentEmailId;
        }
        public QueryExpression GetEntityQuery()
        {
            QueryExpression query = new QueryExpression(SentEmailAttributes.EntityName);
            query.Criteria.AddCondition(SentEmailAttributes.IdField, ConditionOperator.Equal, _sentEmailId);

            query.ColumnSet.AddColumns(
                 SentEmailAttributes.IdField,
                 SentEmailAttributes.LeadField,
                 SentEmailAttributes.AccountField,
                 SentEmailAttributes.ContactField,
                 SentEmailAttributes.EmailSendField
                );

            AddEmailSend(query);

            return query;
        }

        private void AddEmailSend(QueryExpression query)
        {
            var emailSend = query.AddLink(EmailSendAttributes.EntityName, SentEmailAttributes.EmailSendField, EmailSendAttributes.IdField, JoinOperator.Inner);
            emailSend.EntityAlias = EmailSendAttributes.Alias;
            emailSend.Columns.AddColumns(EmailSendAttributes.IdField,
                EmailSendAttributes.Templatefield
               );

            AddEmailTemplate(emailSend);
        }


        private void AddEmailTemplate(LinkEntity linkEntity)
        {
            var emailTemplate = linkEntity.AddLink(EmailTemplateAttributes.EntityName, EmailSendAttributes.Templatefield, EmailTemplateAttributes.IdField, JoinOperator.Inner);
            emailTemplate.EntityAlias = EmailTemplateAttributes.Alias;
            emailTemplate.Columns.AddColumns(
                EmailTemplateAttributes.IdField,
                EmailTemplateAttributes.NameField
               );
        }

    }
}
